package com.bv.eidss.model;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringWriter;
import java.io.UnsupportedEncodingException;
import java.text.ParseException;
import java.util.Date;
import java.util.List;

import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlSerializer;

import android.util.Base64;
import android.util.Xml;

import com.bv.eidss.utils.DateHelpers;

public class CaseSerializer {
	private static void writeHead(XmlSerializer serializer, long country, String name) throws IllegalArgumentException, IllegalStateException, IOException{
		Date dateOfUpload = new Date();
        serializer.startDocument("UTF-8", true);
        serializer.startTag("", name);
    	serializer.attribute("", "version", "1");
        serializer.attribute("", "date", DateHelpers.FormatWithT(dateOfUpload));
        serializer.attribute("", "country", String.valueOf(country));
	}
	
	private static void writeTile(XmlSerializer serializer, String name) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.endTag("", name);
        serializer.endDocument();
	}
	
	private static String Encode(String content){
	    byte[] data = null;
	    try {
	        data = content.getBytes("UTF-8");
	    } catch (UnsupportedEncodingException e1) {
	    	e1.printStackTrace();
	    }
	    String base64 = Base64.encodeToString(data, Base64.DEFAULT);
	    return base64;
	}
	
	public static String writeXml(List<HumanCase> hcs, List<VetCase> vcs, List<ASSession> ass, long country, Boolean bEncode) throws IllegalArgumentException, IllegalStateException, IOException{
		XmlSerializer serializer = Xml.newSerializer();
	    StringWriter writer = new StringWriter();
        serializer.setOutput(writer);
        writeHead(serializer, country, "cases");
        if(hcs != null && hcs.size() > 0)
            HumanCase.ToXml(hcs, country, serializer, false);
        if(vcs != null && vcs.size() > 0)
            VetCase.ToXml(vcs, country, serializer, false);
        if(ass != null && ass.size() > 0)
            ASSession.ToXml(ass, country, serializer, false);
        writeTile(serializer, "cases");
        String content = writer.toString();
        return bEncode ? Encode(content) : content;
	}

    public static String writeAllXml(Options options, List<HumanCase> hcs, List<VetCase> vcs, long country, Boolean bEncode) throws IllegalArgumentException, IllegalStateException, IOException{
        XmlSerializer serializer = Xml.newSerializer();
        StringWriter writer = new StringWriter();
        serializer.setOutput(writer);
        writeHead(serializer, country, "database");
        options.writeXml(serializer);
        if(hcs != null && hcs.size() > 0)
            HumanCase.ToXml(hcs, country, serializer, true);
        if(vcs != null && vcs.size() > 0)
            VetCase.ToXml(vcs, country, serializer, true);
        writeTile(serializer, "database");
        String content = writer.toString();
        return bEncode ? Encode(content) : content;
    }

/*    public static void parseAllXml(String data, Options options, List<HumanCase> hcs, List<VetCase> vcs) throws XmlPullParserException, IOException, ParseException {
        InputStream input = new ByteArrayInputStream(data.getBytes());
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
                    if (name.equalsIgnoreCase("database")){
                    }
                    if (name.equalsIgnoreCase("options")){
                        options.FromXml(parser);
                    }
                    if (name.equalsIgnoreCase("human")){
                        HumanCase.FromXml(hcs, parser);
                    }
                    if (name.equalsIgnoreCase("vet")){
                        VetCase.FromXml(vcs, parser);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("database")){
                        done = true;
                    }
                    break;
            }
            eventType = parser.next();
        }
    }
*/
}
