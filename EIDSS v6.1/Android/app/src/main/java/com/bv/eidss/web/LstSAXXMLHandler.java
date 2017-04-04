package com.bv.eidss.web;

import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASCampaign;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.Farm;
import com.bv.eidss.utils.DateHelpers;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

/**
 * Created by avdovin on 18.05.2016.
 */
public class LstSAXXMLHandler extends DefaultHandler {
    private String XmlFileName;
    private Date refDate;
    private long defRg;
    private long defRn;

    private VectorASCampaign campaigns = new VectorASCampaign();
    private VectorASSession sessions = new VectorASSession();
    private VectorFarm farms = new VectorFarm();
    private List<ASDisease> asDiseases;

    private EidssDatabase eidssDb;

    public LstSAXXMLHandler(String XmlFileName, EidssDatabase eidssDb) {
        this.XmlFileName = "file://" + XmlFileName;
        this.eidssDb = eidssDb;
    }

    public int parseDocument() {
        // parse
        SAXParserFactory factory = SAXParserFactory.newInstance();
        try {
            SAXParser parser = factory.newSAXParser();
            parser.parse(XmlFileName, this);
            if (!eidssDb.LoadLists(campaigns, sessions, farms)) {
                return 4;
            }
        } catch (ParserConfigurationException e) {
            return 2;
            //System.out.println("ParserConfig error");
        } catch (SAXException e) {
            return 2;
            //System.out.println("SAXException : xml not well formed");
        } catch (IOException e) {
            //System.out.println("IO error");
            return 4;
        }finally {
        }
        return 0;
    }


    // Event Handlers
    @Override
    public void startElement(String uri, String localName, String qName,
                             Attributes attributes) throws SAXException{

        try {
            if (qName.equalsIgnoreCase("lists")) {
                String date = attributes.getValue("date");
                refDate = DateHelpers.ParseWithT(date);
                defRg = Long.parseLong(attributes.getValue("defRg"));
                defRn = Long.parseLong(attributes.getValue("defRn"));
            }
            else if (qName.equalsIgnoreCase("farm")) {
                Farm f = Farm.CreateFromAttr(attributes);
                farms.add(f);
            }
            else if (qName.equalsIgnoreCase("session")) {
                ASSession as = ASSession.CreateFromAttr(attributes);
                asDiseases = as.asDiseases;
                sessions.add(as);
            }
            else if (qName.equalsIgnoreCase("campaign")) {
                ASCampaign cm = ASCampaign.CreateFromAttr(attributes);
                asDiseases = cm.asDiseases;
                campaigns.add(cm);
            }
            else if (qName.equalsIgnoreCase("asdisease")) {
                ASDisease ds = ASDisease.CreateFromAttr(attributes);
                asDiseases.add(ds);
            }
        }
        catch (ParseException e) {
            throw new SAXException(e.getMessage());
        }
    }

    @Override
    public void characters(char[] ac, int i, int j) throws SAXException {
    }

    @Override
    public void endElement(String uri, String localName, String qName)
            throws SAXException {
        if (qName.equalsIgnoreCase("asdiseases")){
            asDiseases = null;
        }
    }
}
