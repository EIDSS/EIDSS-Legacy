package com.bv.eidss.web;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;

import java.security.KeyManagementException;
import java.security.KeyStore;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.security.UnrecoverableKeyException;
import java.security.cert.CertificateException;
import java.text.ParseException;

import org.apache.http.Header;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpVersion;
import org.apache.http.StatusLine;
import org.apache.http.auth.AuthScope;
import org.apache.http.auth.Credentials;
import org.apache.http.auth.UsernamePasswordCredentials;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.impl.client.AbstractHttpClient;
import org.apache.http.client.HttpResponseException;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.scheme.PlainSocketFactory;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.ssl.SSLSocketFactory;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.conn.tsccm.ThreadSafeClientConnManager;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.params.HttpProtocolParams;
import org.apache.http.protocol.HTTP;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;


import android.util.Base64;

import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReferenceType;


// http://www.vogella.com/articles/AndroidJSON/article.html

public class WebApiClient {
	private String _url; 
	private HttpClient _client;
	int _timeout;

	public WebApiClient(String url, String Organization, String User, String Password, int timeout) throws KeyManagementException, UnrecoverableKeyException, KeyStoreException, NoSuchAlgorithmException, CertificateException, IOException	{
		_url = url;
		_timeout = timeout;
		_client = getNewHttpClient(); //new DefaultHttpClient();
		Credentials creds = new UsernamePasswordCredentials(Organization + "@" + User, Password);
		((AbstractHttpClient)_client).getCredentialsProvider().setCredentials(new AuthScope(AuthScope.ANY_HOST, AuthScope.ANY_PORT), creds);
	}

	private HttpClient getNewHttpClient() throws KeyStoreException, NoSuchAlgorithmException, CertificateException, IOException, KeyManagementException, UnrecoverableKeyException {
        KeyStore trustStore = KeyStore.getInstance(KeyStore.getDefaultType());
        trustStore.load(null, null);

        SSLSocketFactory sf = new MySSLSocketFactory(trustStore);
        sf.setHostnameVerifier(SSLSocketFactory.ALLOW_ALL_HOSTNAME_VERIFIER);

        HttpParams params = new BasicHttpParams();
        HttpProtocolParams.setVersion(params, HttpVersion.HTTP_1_1);
        HttpProtocolParams.setContentCharset(params, HTTP.UTF_8);
		HttpConnectionParams.setConnectionTimeout(params, _timeout * 60 * 1000);
		HttpConnectionParams.setSoTimeout(params, _timeout * 60 * 1000);        

        SchemeRegistry registry = new SchemeRegistry();
        registry.register(new Scheme("http", PlainSocketFactory.getSocketFactory(), 80));
        registry.register(new Scheme("https", sf, 443));

        ClientConnectionManager ccm = new ThreadSafeClientConnManager(params, registry);

        DefaultHttpClient client = new DefaultHttpClient(ccm, params);
        return client;
	}        

	private static String Decode(String content){
	    byte[] data = Base64.decode(content, Base64.DEFAULT);
	    try {
			return new String(data, "UTF-8");
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}
	
	private String postJson(String url, JSONObject data) throws ClientProtocolException, IOException{
	    StringBuilder builder = new StringBuilder();

	    HttpPost httpPost = new HttpPost(url);
	    StringEntity entity = new StringEntity(data.toString());
	    httpPost.setEntity(entity);
	    httpPost.setHeader("Accept", "application/json");
		httpPost.setHeader("Content-type", "application/json");
	    
	    HttpResponse response = _client.execute(httpPost);
	    StatusLine statusLine = response.getStatusLine();
	    int statusCode = statusLine.getStatusCode();
	    if (statusCode == 200) {
	    	HttpEntity entityOut = response.getEntity();
	    	InputStream content = entityOut.getContent();
	    	BufferedReader reader = new BufferedReader(new InputStreamReader(content));
	    	String line;
	    	while ((line = reader.readLine()) != null) {
	    		builder.append(line);
	    	}
			return builder.toString();
	    }
	    String errorMessage = "";
	    Header errorHeader = response.getFirstHeader("ErrorMessage");
	    if (errorHeader != null)
	    	errorMessage = Decode(errorHeader.getValue());

	    throw new HttpResponseException(statusCode, errorMessage);
	}
	
	private byte[] getBytes(String url) throws ClientProtocolException, IOException{
	    HttpGet httpGet = new HttpGet(url);
	    HttpResponse response = _client.execute(httpGet);
	    StatusLine statusLine = response.getStatusLine();
	    int statusCode = statusLine.getStatusCode();
	    if (statusCode == 200) {
	    	HttpEntity entity = response.getEntity();
	    	InputStream content = entity.getContent();
	    	byte[] buffer = new byte[1000000];
	    	byte[] buffer1 = new byte[1024];
	    	int alllen = 0;
	    	int len = content.read(buffer1);
	    	while(len >= 0){
		    	System.arraycopy(buffer1, 0, buffer, alllen, len);
	    		alllen += len;
		    	len = content.read(buffer1);
	    	}
	    	byte[] ret = new byte[alllen];
	    	System.arraycopy(buffer, 0, ret, 0, alllen);
			return ret;
	    }
	    throw new HttpResponseException(statusCode, "");
	}
	
	private String getJson(String url) throws ClientProtocolException, IOException{
	    StringBuilder builder = new StringBuilder();

	    HttpGet httpGet = new HttpGet(url);
	    
	    HttpResponse response = _client.execute(httpGet);
	    StatusLine statusLine = response.getStatusLine();
	    int statusCode = statusLine.getStatusCode();
	    if (statusCode == 200) {
	    	HttpEntity entity = response.getEntity();
	    	InputStream content = entity.getContent();
	    	BufferedReader reader = new BufferedReader(new InputStreamReader(content));
	    	String line;
	    	while ((line = reader.readLine()) != null) {
	    		builder.append(line);
	    	}
			return builder.toString();
	    }
	    String errorMessage = "";
	    Header errorHeader = response.getFirstHeader("ErrorMessage");
	    if (errorHeader != null)
	    	errorMessage = Decode(errorHeader.getValue());

	    throw new HttpResponseException(statusCode, errorMessage);
	}
	
	private void AddRefType(VectorBaseReferenceRaw ref, long type)	{
        BaseReferenceRaw r = new BaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.intHACode = -1;
        r.strDefault = "";
        ref.add(r);
	}
	private void AddGisRefType(VectorGisBaseReferenceRaw ref, long type)	{
		GisBaseReferenceRaw r = new GisBaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.strDefault = "";
        ref.add(r);
	}

	private void AddRef(VectorBaseReferenceRaw ref, long type) throws ClientProtocolException, JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/BaseReferenceRaw/" + type));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new BaseReferenceRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddRefTranslation(VectorBaseReferenceTranslationRaw ref, long type, String lang) throws ClientProtocolException, JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/BaseReferenceTranslationRaw/" + type + "?lang=" + lang));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new BaseReferenceTranslationRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddGisRef(VectorGisBaseReferenceRaw ref) throws ClientProtocolException, JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/GisBaseReferenceRaw"));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new GisBaseReferenceRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddGisRefTranslation(VectorGisBaseReferenceTranslationRaw ref, String lang) throws ClientProtocolException, JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/GisBaseReferenceTranslationRaw?lang=" + lang));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new GisBaseReferenceTranslationRaw(jsonArray.getJSONObject(i)));
		}
	}


	public String Version() throws ClientProtocolException, IOException{
		return getJson(_url + "/api/AndroidVersion");
	}
	
	public byte[] App() throws ClientProtocolException, IOException{
		return getBytes(_url + "/api/AndroidApp");
	}
	
	public String Check() throws ClientProtocolException, IOException{
		return getJson(_url + "/api/check");
	}
	
	public HumanCaseInfoOut HumanCaseSave(HumanCaseInfoIn hc) throws JSONException, ParseException, ClientProtocolException, IOException{
		JSONObject in = hc.json();
		JSONObject out = new JSONObject(postJson(_url + "/api/HumanCase", in));
		return new HumanCaseInfoOut(out);
	}
	
	public VetCaseInfoOut VetCaseSave(VetCaseInfoIn vc) throws JSONException, ParseException, ClientProtocolException, IOException{
		JSONObject in = vc.json();
		JSONObject out = new JSONObject(postJson(_url + "/api/VetCase", in));
		return new VetCaseInfoOut(out);
	}
	
	public VectorBaseReferenceRaw LoadReferences() throws Exception{
        VectorBaseReferenceRaw allref = new VectorBaseReferenceRaw();
        AddRefType(allref, BaseReferenceType.rftDiagnosis);
        AddRefType(allref, BaseReferenceType.rftHumanAgeType);
        AddRefType(allref, BaseReferenceType.rftHumanGender);
        AddRefType(allref, BaseReferenceType.rftFinalState);
        AddRefType(allref, BaseReferenceType.rftHospStatus);
        AddRefType(allref, BaseReferenceType.rftCaseType);
        AddRefType(allref, BaseReferenceType.rftCaseReportType);
        AddRefType(allref, BaseReferenceType.rftSpeciesList);
        AddRef(allref, BaseReferenceType.rftDiagnosis);
        AddRef(allref, BaseReferenceType.rftHumanAgeType);
        AddRef(allref, BaseReferenceType.rftHumanGender);
        AddRef(allref, BaseReferenceType.rftFinalState);
        AddRef(allref, BaseReferenceType.rftHospStatus);
        AddRef(allref, BaseReferenceType.rftCaseType);
        AddRef(allref, BaseReferenceType.rftCaseReportType);
        AddRef(allref, BaseReferenceType.rftSpeciesList);
        
        int find = -1;
        for(int i = 0; i < allref.size(); i++){
        	if (allref.get(i).idfsBaseReference == 50815490000000L){ // CaseReportType.Both
        		find = i;
        		break;
        	}
        }
        if (find > 0){
            allref.remove(find);
        }

        return allref;
    }
	
	public VectorBaseReferenceTranslationRaw LoadReferenceTranslations() throws Exception{
		VectorBaseReferenceTranslationRaw allref = new VectorBaseReferenceTranslationRaw();
		AddRefTranslation(allref, BaseReferenceType.rftDiagnosis, "en");
		AddRefTranslation(allref, BaseReferenceType.rftDiagnosis, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftDiagnosis, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftHumanAgeType, "en");
		AddRefTranslation(allref, BaseReferenceType.rftHumanAgeType, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftHumanAgeType, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftHumanGender, "en");
		AddRefTranslation(allref, BaseReferenceType.rftHumanGender, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftHumanGender, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftFinalState, "en");
		AddRefTranslation(allref, BaseReferenceType.rftFinalState, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftFinalState, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftHospStatus, "en");
		AddRefTranslation(allref, BaseReferenceType.rftHospStatus, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftHospStatus, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftCaseType, "en");
		AddRefTranslation(allref, BaseReferenceType.rftCaseType, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftCaseType, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftCaseReportType, "en");
		AddRefTranslation(allref, BaseReferenceType.rftCaseReportType, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftCaseReportType, "ka");
		AddRefTranslation(allref, BaseReferenceType.rftSpeciesList, "en");
		AddRefTranslation(allref, BaseReferenceType.rftSpeciesList, "ru");
		AddRefTranslation(allref, BaseReferenceType.rftSpeciesList, "ka");
        return allref;
	}
	
	public VectorGisBaseReferenceRaw LoadGisReferences() throws Exception{
		VectorGisBaseReferenceRaw allref = new VectorGisBaseReferenceRaw();
		AddGisRefType(allref, GisBaseReferenceType.rftCountry);
		AddGisRefType(allref, GisBaseReferenceType.rftRegion);
		AddGisRefType(allref, GisBaseReferenceType.rftRayon);
		AddGisRefType(allref, GisBaseReferenceType.rftSettlement);
		AddGisRef(allref);
        return allref;
	}

	public VectorGisBaseReferenceTranslationRaw LoadGisReferenceTranslations() throws Exception{
		VectorGisBaseReferenceTranslationRaw allref = new VectorGisBaseReferenceTranslationRaw();
		AddGisRefTranslation(allref, "en");
		AddGisRefTranslation(allref, "ru");
		AddGisRefTranslation(allref, "ka");
        return allref;
	}
	
}

