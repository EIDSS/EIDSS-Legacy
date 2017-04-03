package com.bv.eidss.web;

import java.io.IOException;
import java.io.InputStream;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Locale;

import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.util.Xml;

import com.bv.eidss.web.BaseReferenceRaw;
import com.bv.eidss.web.BaseReferenceTranslationRaw;
import com.bv.eidss.web.GisBaseReferenceRaw;
import com.bv.eidss.web.GisBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorBaseReferenceRaw;
import com.bv.eidss.web.VectorBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorGisBaseReferenceRaw;
import com.bv.eidss.web.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReferenceType;

public class RefDeserializer {
	public static Object[] parseAll(InputStream input) throws XmlPullParserException, IOException, ParseException{
		Object[] ret = new Object[5];
        XmlPullParser parser = Xml.newPullParser();
        parser.setInput(input, null);
        int eventType = parser.getEventType();
        boolean done = false;
        while (eventType != XmlPullParser.END_DOCUMENT && !done){
            switch (eventType){
	            case XmlPullParser.START_DOCUMENT:
	                break;
	            case XmlPullParser.START_TAG:
	                String name = parser.getName();
	                if (name.equalsIgnoreCase("references")){
	                    SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
	                	ret[0] = format.parse(parser.getAttributeValue("", "date").replace('T', ' '));
	                }
	                if (name.equalsIgnoreCase("refs")){
	                	ret[1] = parseReferences(parser);
	                }
	                else if (name.equalsIgnoreCase("refsLang")){
	                	ret[2] = parseReferenceTranslations(parser);
	                }
	                else if (name.equalsIgnoreCase("giss")){
	                	ret[3] = parseGisReferences(parser);
	                }
	                else if (name.equalsIgnoreCase("gissLang")){
	                	ret[4] = parseGisReferenceTranslations(parser);
	                }
	                break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("references")){
                        done = true;
                    }
                    break;
            }
            eventType = parser.next();
        }
		return ret;
	}
	
	private static VectorBaseReferenceRaw parseReferences(XmlPullParser parser) throws XmlPullParserException, IOException{
        VectorBaseReferenceRaw allref = new VectorBaseReferenceRaw();
        AddRefType(allref, BaseReferenceType.rftDiagnosis);
        AddRefType(allref, BaseReferenceType.rftHumanAgeType);
        AddRefType(allref, BaseReferenceType.rftHumanGender);
        AddRefType(allref, BaseReferenceType.rftFinalState);
        AddRefType(allref, BaseReferenceType.rftHospStatus);
        AddRefType(allref, BaseReferenceType.rftCaseType);
        AddRefType(allref, BaseReferenceType.rftCaseReportType);
        AddRefType(allref, BaseReferenceType.rftSpeciesList);
        
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
	            case XmlPullParser.START_TAG:
	                String name = parser.getName();
	                if (name.equalsIgnoreCase("ref")){
	                    BaseReferenceRaw r = new BaseReferenceRaw();
	                    r.idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
	                    r.idfsReferenceType = Long.parseLong(parser.getAttributeValue("", "type"));
	                    r.intHACode = Integer.parseInt(parser.getAttributeValue("", "ha"));
	                    r.strDefault = parser.getAttributeValue("", "val");
	                    allref.add(r);
	                }
	                break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("refs")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
    }

	public static VectorBaseReferenceTranslationRaw parseReferenceTranslations(XmlPullParser parser)  throws XmlPullParserException, IOException{
		VectorBaseReferenceTranslationRaw allref = new VectorBaseReferenceTranslationRaw();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
	            case XmlPullParser.START_TAG:
	                String name = parser.getName();
	                if (name.equalsIgnoreCase("refLang")){
	                	BaseReferenceTranslationRaw r = new BaseReferenceTranslationRaw();
	                    r.idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
	                    r.strLanguage = parser.getAttributeValue("", "lang");
	                    r.strTranslation = parser.getAttributeValue("", "val");
	                    allref.add(r);
	                }
	                break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("refsLang")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
	}
	
	public static VectorGisBaseReferenceRaw parseGisReferences(XmlPullParser parser) throws XmlPullParserException, IOException{
		VectorGisBaseReferenceRaw allref = new VectorGisBaseReferenceRaw();
		AddGisRefType(allref, GisBaseReferenceType.rftCountry);
		AddGisRefType(allref, GisBaseReferenceType.rftRegion);
		AddGisRefType(allref, GisBaseReferenceType.rftRayon);
		AddGisRefType(allref, GisBaseReferenceType.rftSettlement);
		
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
	            case XmlPullParser.START_TAG:
	                String name = parser.getName();
	                if (name.equalsIgnoreCase("gis")){
	                	GisBaseReferenceRaw r = new GisBaseReferenceRaw();
	                    r.idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
	                    r.idfsReferenceType = Long.parseLong(parser.getAttributeValue("", "type"));
	                    r.idfsCountry = Long.parseLong(parser.getAttributeValue("", "cn"));
	                    r.idfsRegion = Long.parseLong(parser.getAttributeValue("", "rg"));
	                    r.idfsRayon = Long.parseLong(parser.getAttributeValue("", "rn"));
	                    r.strDefault = parser.getAttributeValue("", "val");
	                    allref.add(r);
	                }
	                break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("giss")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
	}

	public static VectorGisBaseReferenceTranslationRaw parseGisReferenceTranslations(XmlPullParser parser) throws XmlPullParserException, IOException{
		VectorGisBaseReferenceTranslationRaw allref = new VectorGisBaseReferenceTranslationRaw();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
	            case XmlPullParser.START_TAG:
	                String name = parser.getName();
	                if (name.equalsIgnoreCase("gisLang")){
	                	GisBaseReferenceTranslationRaw r = new GisBaseReferenceTranslationRaw();
	                    r.idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
	                    r.strLanguage = parser.getAttributeValue("", "lang");
	                    r.strTranslation = parser.getAttributeValue("", "val");
	                    allref.add(r);
	                }
	                break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("gissLang")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
	}

	private static void AddRefType(VectorBaseReferenceRaw ref, long type)	{
        BaseReferenceRaw r = new BaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.intHACode = -1;
        r.strDefault = "";
        ref.add(r);
	}

	private static void AddGisRefType(VectorGisBaseReferenceRaw ref, long type)	{
		GisBaseReferenceRaw r = new GisBaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.strDefault = "";
        ref.add(r);
	}
	
}
