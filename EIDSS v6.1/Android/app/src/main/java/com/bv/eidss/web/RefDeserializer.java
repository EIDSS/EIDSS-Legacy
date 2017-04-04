package com.bv.eidss.web;

import java.io.IOException;
import java.io.InputStream;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;

import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.util.Xml;

import com.bv.eidss.DeploymentCountry;
import com.bv.eidss.model.FFReferences;
import com.bv.eidss.utils.DateHelpers;

public class RefDeserializer {
	public static Object[] parseAll(InputStream input, Date lastUpdate) throws XmlPullParserException, IOException, ParseException{
		Object[] ret = new Object[8];

        DeploymentCountry cnt = new DeploymentCountry();
        ArrayList<String> langs = new ArrayList<>();
        Collections.addAll(langs, cnt.getDefSupportedLangs());

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
                        Date refDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "date"));
                        if (lastUpdate == null || refDate.after(lastUpdate))
                            ret[0] = refDate;
                        else {
                            ret[0] = null;
                            done = true;//finish parsing here
                        }
                    }
                    else if (name.equalsIgnoreCase("mandatory")){
	                	ret[1] = MandatoryFieldsRaw.FromXml(parser);
	                }
                    else if (name.equalsIgnoreCase("invisible")){
                        ret[2] = InvisibleFieldsRaw.FromXml(parser);
                    }
                    else if (name.equalsIgnoreCase("refs")){
                        ret[3] = BaseReferenceRaw.FromXml(parser);
                    }
	                else if (name.equalsIgnoreCase("refsLang")){
	                	ret[4] = BaseReferenceTranslationRaw.FromXml(parser, langs);
	                }
	                else if (name.equalsIgnoreCase("giss")){
	                	ret[5] = GisBaseReferenceRaw.FromXml(parser);
	                }
                    else if (name.equalsIgnoreCase("gissLang")){
                        ret[6] = GisBaseReferenceTranslationRaw.FromXml(parser, langs);
                    }
                    else if (name.equalsIgnoreCase("ff")){
                        ret[7] = new FFReferences(parser);
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
}
