package com.bv.eidss.web;

import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.DeploymentCountry;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.DateHelpers;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

//
// Created by Gorodentseva on 15.12.2015.
//
class BreakParsingException extends Exception {
}

public class RefSAXXMLHandler  extends DefaultHandler {

    private String XmlFileName;
    private ArrayList<String> langs;

    private Date lastUpdate;
    private Date refDate;
    private long defRg;
    private long defRn;

    private String tempLang;

    private EidssDatabase eidssDb;
    private SQLiteDatabase db;

    private SQLiteStatement stmt;
    private SQLiteStatement stmtf;

    public RefSAXXMLHandler(String XmlFileName, Date lastUpdate, EidssDatabase eidssDb) {
        this.XmlFileName = "file://" + XmlFileName;
        this.lastUpdate = lastUpdate;
        this.eidssDb = eidssDb;
        db = eidssDb.BeginLoadReferences();

        DeploymentCountry cnt = new DeploymentCountry();
        langs = new ArrayList<>();
        Collections.addAll(langs, cnt.getDefSupportedLangs());

        //parseDocument();
    }

    public int parseDocument() {
        // parse
        SAXParserFactory factory = SAXParserFactory.newInstance();
        try {
            SAXParser parser = factory.newSAXParser();
            parser.parse(XmlFileName, this);
            db.setTransactionSuccessful();
        } catch (ParserConfigurationException e) {
            return 2;
            //System.out.println("ParserConfig error");
        } catch (SAXException e) {
            if (e.getException() instanceof BreakParsingException) {
                // we have broken the parsing process
                return 1;
            }
            else
                return 2;
                //System.out.println("SAXException : xml not well formed");
        } catch (IOException e) {
            //System.out.println("IO error");
            return 3;
        }finally {
            db.endTransaction();
        }
        Options opt = eidssDb.Options();
        opt.setLastRefUpdt(refDate);
        opt.setRegionDef(defRg);
        opt.setRayonDef(defRn);
        eidssDb.OptionsUpdate(opt);
        return 0;
    }

    // Event Handlers
    @Override
    public void startElement(String uri, String localName, String qName,
                             Attributes attributes) throws SAXException{

        if (qName.equalsIgnoreCase("references")) {
            String date = attributes.getValue("date");
            try {
                refDate = DateHelpers.ParseWithT(date);
                if (lastUpdate != null && refDate.before(lastUpdate)){
                    throw new SAXException(new BreakParsingException());//finish parsing here
                }
                defRg = Long.parseLong(attributes.getValue("defRg"));
                defRn = Long.parseLong(attributes.getValue("defRn"));
            }
            catch (ParseException e) {
                throw new SAXException(e.getMessage());
            }

        }
        else if (qName.equalsIgnoreCase("mandatory")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_mandatory_fields);
        }
        else if (qName.equalsIgnoreCase("invisible")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_invisible_fields);
        }
        else if (qName.equalsIgnoreCase("refs")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_references);
            stmtf = db.compileStatement(EidssDatabase.insert_sql_references_wf);
        }
        else if (qName.equalsIgnoreCase("refsLang")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_references_trans);
        }
        else if (qName.equalsIgnoreCase("giss")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_gisreferences);
        }
        else if (qName.equalsIgnoreCase("gissLang")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_gisreferences_trans);
        }
        else if (qName.equalsIgnoreCase("field")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("id")));
            stmt.bindString(2, attributes.getValue("fn"));
            stmt.executeInsert();
        }
        //else if (qName.equalsIgnoreCase("ref")) {
        else if (qName.equalsIgnoreCase("r")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("id")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("tp")));
            stmt.bindLong(3, Integer.parseInt(attributes.getValue("ha")));
            stmt.bindString(4, attributes.getValue("df"));
            stmt.bindLong(5, Integer.parseInt(attributes.getValue("rs")));
            stmt.bindLong(6, Integer.parseInt(attributes.getValue("rd")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("rf")) {
            stmtf.clearBindings();
            stmtf.bindLong(1, Long.parseLong(attributes.getValue("id")));
            stmtf.bindLong(2, Long.parseLong(attributes.getValue("tp")));
            stmtf.bindLong(3, Integer.parseInt(attributes.getValue("ha")));
            stmtf.bindString(4, attributes.getValue("df"));
            stmtf.bindLong(5, Integer.parseInt(attributes.getValue("rs")));
            stmtf.bindLong(6, Integer.parseInt(attributes.getValue("rd")));
            stmtf.bindLong(7, Long.parseLong(attributes.getValue("f1")));
            stmtf.bindLong(8, Long.parseLong(attributes.getValue("f2")));
            stmtf.executeInsert();
        }
        else if (qName.equalsIgnoreCase("lang")){
            tempLang = attributes.getValue("lang");
            if(!langs.contains(tempLang))
                tempLang = null;
        }
        else if (qName.equalsIgnoreCase("rl") || qName.equalsIgnoreCase("gl")) {
            if(tempLang != null) {
                stmt.clearBindings();
                stmt.bindLong(1, Long.parseLong(attributes.getValue("id")));
                stmt.bindString(2, attributes.getValue("tr"));
                stmt.bindString(3, tempLang);
                stmt.executeInsert();
            }
        }
        else if (qName.equalsIgnoreCase("gis")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("id")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("tp")));
            stmt.bindLong(3,Long.parseLong(attributes.getValue("cn")));
            stmt.bindLong(4, Long.parseLong(attributes.getValue("rg")));
            stmt.bindLong(5, Long.parseLong(attributes.getValue("rn")));
            stmt.bindString(6, attributes.getValue("df"));
            stmt.bindLong(7, Integer.parseInt(attributes.getValue("rs")));
            stmt.bindLong(8, Integer.parseInt(attributes.getValue("rd")));
            stmt.executeInsert();
        }
        //ff
        else if (qName.equalsIgnoreCase("tems")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_template_elements);
        }
        else if (qName.equalsIgnoreCase("dets")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_determinants);
        }
        else if (qName.equalsIgnoreCase("ruls")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_rules);
        }
        else if (qName.equalsIgnoreCase("cons")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_constants);
        }
        else if (qName.equalsIgnoreCase("funs")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsforf);
        }
        else if (qName.equalsIgnoreCase("acts")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsfora);
        }
        else if (qName.equalsIgnoreCase("pfps")) {
            stmt = db.compileStatement(EidssDatabase.insert_sql_ff_parsprefixed);
        }
        else if (qName.equalsIgnoreCase("tem")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("br")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("ft")));
            stmt.bindLong(3, Long.parseLong(attributes.getValue("brp")));
            stmt.bindLong(4, Integer.parseInt(attributes.getValue("et")));
            stmt.bindLong(5, Long.parseLong(attributes.getValue("ed")));
            stmt.bindLong(6, Integer.parseInt(attributes.getValue("rd")));
            stmt.bindLong(7, Integer.parseInt(attributes.getValue("md")));
            stmt.bindLong(8, Long.parseLong(attributes.getValue("pt")));
            stmt.bindLong(9, Integer.parseInt(attributes.getValue("od")));
            stmt.bindLong(10, Long.parseLong(attributes.getValue("ptt")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("det")) {
            stmt.clearBindings();
            stmt.bindLong(1,  Long.parseLong(attributes.getValue("dv")));
            stmt.bindLong(2,  Long.parseLong(attributes.getValue("tp")));
            stmt.bindLong(3, Long.parseLong(attributes.getValue("ft")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("rul")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("rl")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("ft")));
            stmt.bindLong(3, Long.parseLong(attributes.getValue("cp")));
            stmt.bindLong(4, Long.parseLong(attributes.getValue("rm")));
            stmt.bindLong(5, Long.parseLong(attributes.getValue("rf")));
            stmt.bindLong(6, Integer.parseInt(attributes.getValue("nt")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("con")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("rl")));
            stmt.bindString(2, attributes.getValue("cn"));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("fun")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("pr")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("rl")));
            stmt.bindLong(3, Integer.parseInt(attributes.getValue("rd")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("act")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("pr")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("rl")));
            stmt.bindLong(3, Long.parseLong(attributes.getValue("ra")));
            stmt.executeInsert();
        }
        else if (qName.equalsIgnoreCase("pfp")) {
            stmt.clearBindings();
            stmt.bindLong(1, Long.parseLong(attributes.getValue("pv")));
            stmt.bindLong(2, Long.parseLong(attributes.getValue("pt")));
            stmt.executeInsert();
        }
    }

    @Override
    public void characters(char[] ac, int i, int j) throws SAXException {
    }

    @Override
    public void endElement(String uri, String localName, String qName)
            throws SAXException {
        if (qName.equalsIgnoreCase("mandatory") || qName.equalsIgnoreCase("invisible")
                || qName.equalsIgnoreCase("refsLang") || qName.equalsIgnoreCase("giss") || qName.equalsIgnoreCase("gissLang")
                || qName.equalsIgnoreCase("tems") || qName.equalsIgnoreCase("dets") || qName.equalsIgnoreCase("ruls") || qName.equalsIgnoreCase("cons")
                || qName.equalsIgnoreCase("funs") || qName.equalsIgnoreCase("acts") || qName.equalsIgnoreCase("pfps"))
            stmt.close();
        else if (qName.equalsIgnoreCase("refs")){
            stmt.close();
            stmtf.close();
        }
    }
}
