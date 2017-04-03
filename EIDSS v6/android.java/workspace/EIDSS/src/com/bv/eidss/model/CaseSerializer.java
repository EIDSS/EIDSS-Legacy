package com.bv.eidss.model;

import java.io.IOException;
import java.io.StringWriter;
import java.io.UnsupportedEncodingException;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.xmlpull.v1.XmlSerializer;

import android.util.Base64;
import android.util.Xml;

public class CaseSerializer {
	private static void writeHead(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
		Date dateOfUpload = new Date();
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        serializer.startDocument("UTF-8", true);
        serializer.startTag("", "cases");
    	serializer.attribute("", "version", "1");
        serializer.attribute("", "date", formatterDateTime.format(dateOfUpload).replace(' ', 'T'));
	}
	
	private static void writeTile(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.endTag("", "cases");
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
	
	public static String writeXml(List<HumanCase> hcs, List<VetCase> vcs, long country) throws IllegalArgumentException, IllegalStateException, IOException{
		XmlSerializer serializer = Xml.newSerializer();
	    StringWriter writer = new StringWriter();
        serializer.setOutput(writer);
        writeHead(serializer);
        HumanCase.writeXml(hcs, country, serializer);
        VetCase.writeXml(vcs, country, serializer);
        writeTile(serializer);
        return Encode(writer.toString());
	}
	
	public static String writeHumanXml(List<HumanCase> hcs, long country) throws IllegalArgumentException, IllegalStateException, IOException{
		XmlSerializer serializer = Xml.newSerializer();
	    StringWriter writer = new StringWriter();
        serializer.setOutput(writer);
        writeHead(serializer);
        HumanCase.writeXml(hcs, country, serializer);
        writeTile(serializer);
        return Encode(writer.toString());
	}
	
	public static String writeVetXml(List<VetCase> vcs, long country) throws IllegalArgumentException, IllegalStateException, IOException{
		XmlSerializer serializer = Xml.newSerializer();
	    StringWriter writer = new StringWriter();
        serializer.setOutput(writer);
        writeHead(serializer);
        VetCase.writeXml(vcs, country, serializer);
        writeTile(serializer);
        return Encode(writer.toString());
	}
}
