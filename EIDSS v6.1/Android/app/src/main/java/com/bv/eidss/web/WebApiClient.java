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
import java.util.ArrayList;


import org.apache.http.Header;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpVersion;
import org.apache.http.StatusLine;
import org.apache.http.auth.AuthScope;
import org.apache.http.auth.Credentials;
import org.apache.http.auth.UsernamePasswordCredentials;
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

import com.bv.eidss.DeploymentCountry;
import com.bv.eidss.model.ASCampaign;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.FFReferences;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.generated.ASSession_object;


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

        return new DefaultHttpClient(ccm, params);
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
	
	private String postJson(String url, JSONObject data) throws IOException{
	    StringBuilder builder = new StringBuilder();

	    HttpPost httpPost = new HttpPost(url);
	    StringEntity entity = new StringEntity(data.toString(),"utf-8");
	    httpPost.setEntity(entity);
	    httpPost.setHeader("Accept", "application/json");
		httpPost.setHeader("Content-type", "application/json; charset=utf8");
	    
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
	
	private byte[] getBytes(String url) throws IOException{
	    HttpGet httpGet = new HttpGet(url);
	    HttpResponse response = _client.execute(httpGet);
	    StatusLine statusLine = response.getStatusLine();
	    int statusCode = statusLine.getStatusCode();
	    if (statusCode == 200) {
	    	HttpEntity entity = response.getEntity();
	    	InputStream content = entity.getContent();
	    	byte[] buffer = new byte[4000000];
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
	
	private String getJson(String url) throws IOException{
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

    private void AddMandatoryFields(VectorMandatoryFieldsRaw ref) throws JSONException, IOException	{
        JSONArray jsonArray = new JSONArray(getJson(_url + "/api/MandatoryFields"));
        for (int i = 0; i < jsonArray.length(); i++) {
            ref.add(new MandatoryFieldsRaw(jsonArray.getJSONObject(i)));
        }
    }
    private void AddInvisibleFields(VectorInvisibleFieldsRaw ref) throws JSONException, IOException	{
        JSONArray jsonArray = new JSONArray(getJson(_url + "/api/InvisibleFields"));
        for (int i = 0; i < jsonArray.length(); i++) {
            ref.add(new InvisibleFieldsRaw(jsonArray.getJSONObject(i)));
        }
    }

    private void AddCampaigns(VectorASCampaign ref) throws JSONException, IOException, ParseException	{
        JSONArray jsonArray = new JSONArray(getJson(_url + "/api/ASCampaigns"));
        for (int i = 0; i < jsonArray.length(); i++) {
            ref.add(new ASCampaign(jsonArray.getJSONObject(i)));
        }
    }

    private void AddSessions(VectorASSession ref, long idfsRegion) throws JSONException, IOException, ParseException {
        JSONArray jsonArray = new JSONArray(getJson(_url + "/api/ASSession/" + idfsRegion));
        for (int i = 0; i < jsonArray.length(); i++) {
            ref.add(ASSession.CreateFromJson(jsonArray.getJSONObject(i)));
        }
    }

    private void AddFarms(VectorFarm ref, long idfsRegion) throws JSONException, IOException, ParseException {
        JSONArray jsonArray = new JSONArray(getJson(_url + "/api/Farm/" + idfsRegion));
        for (int i = 0; i < jsonArray.length(); i++) {
            ref.add(Farm.CreateFromJson(jsonArray.getJSONObject(i)));
        }
    }

    private void AddRef(VectorBaseReferenceRaw ref, long type) throws JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/BaseReferenceRaw/" + type));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new BaseReferenceRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddRefTranslation(VectorBaseReferenceTranslationRaw ref, long type, String lang) throws JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/BaseReferenceTranslationRaw/" + type + "?lang=" + lang));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new BaseReferenceTranslationRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddGisRef(VectorGisBaseReferenceRaw ref) throws JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/GisBaseReferenceRaw"));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new GisBaseReferenceRaw(jsonArray.getJSONObject(i)));
		}
	}

	private void AddGisRefTranslation(VectorGisBaseReferenceTranslationRaw ref, String lang) throws JSONException, IOException	{
		JSONArray jsonArray = new JSONArray(getJson(_url + "/api/GisBaseReferenceTranslationRaw?lang=" + lang));
		for (int i = 0; i < jsonArray.length(); i++) {
			ref.add(new GisBaseReferenceTranslationRaw(jsonArray.getJSONObject(i)));
		}
	}


	public String Version() throws IOException{
		return getJson(_url + "/api/AndroidVersion");
	}
	
	public byte[] App() throws IOException{
		return getBytes(_url + "/api/AndroidApp");
	}
	
	public String Check() throws IOException{
		return getJson(_url + "/api/check");
	}
	
	public HumanCaseInfoOut HumanCaseSave(HumanCase hc) throws JSONException, ParseException, IOException{
		JSONObject in = hc.ToJson();
		JSONObject out = new JSONObject(postJson(_url + "/api/HumanCase", in));
		return new HumanCaseInfoOut(out);
	}
	
	public VetCaseInfoOut VetCaseSave(VetCase vc) throws JSONException, ParseException, IOException{
		JSONObject in = vc.ToJson();
		JSONObject out = new JSONObject(postJson(_url + "/api/VetCase", in));
		return new VetCaseInfoOut(out);
	}

    public ASSessionInfoOut ASSessionSave(ASSession vc) throws JSONException, ParseException, IOException{
        JSONObject in = vc.ToJson();
        JSONObject out = new JSONObject(postJson(_url + "/api/ASSession", in));
        return new ASSessionInfoOut(out);
    }

    public VectorMandatoryFieldsRaw LoadMandatoryFields() throws Exception{
		VectorMandatoryFieldsRaw ref = new VectorMandatoryFieldsRaw();
        AddMandatoryFields(ref);
        return ref;
    }
    public VectorInvisibleFieldsRaw LoadInvisibleFields() throws Exception{
		VectorInvisibleFieldsRaw ref = new VectorInvisibleFieldsRaw();
        AddInvisibleFields(ref);
        return ref;
    }
    public VectorASCampaign LoadCampaigns() throws Exception{
        VectorASCampaign ref = new VectorASCampaign();
        AddCampaigns(ref);
        return ref;
    }

    public VectorASSession LoadSessions(long idfsRegion) throws Exception{
        VectorASSession ref = new VectorASSession();
        AddSessions(ref, idfsRegion);
        return ref;
    }

    public VectorFarm LoadFarms(long idfsRegion) throws Exception{
        VectorFarm ref = new VectorFarm();
        AddFarms(ref, idfsRegion);
        return ref;
    }

    public FFReferences LoadFFReferences() throws Exception{
        JSONObject json = new JSONObject(getJson(_url + "/api/FF"));
        return new FFReferences(json);
    }

    public Options LoadOptions() throws Exception{
        JSONObject json = new JSONObject(getJson(_url + "/api/Options"));
        return new Options(json);
    }


    public VectorBaseReferenceRaw LoadReferences(ArrayList<Long> ffTypes) throws Exception{
		VectorBaseReferenceRaw allref = new VectorBaseReferenceRaw(ffTypes);

		//REF
		for(int i = 0; i < allref.brTypes.size(); i++){
			AddRef(allref, allref.brTypes.get(i));
		}
        /*
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
        */
        return allref;
    }
	
	public VectorBaseReferenceTranslationRaw LoadReferenceTranslations(ArrayList<Long> brtypes) throws Exception{
		VectorBaseReferenceTranslationRaw allref = new VectorBaseReferenceTranslationRaw();
        DeploymentCountry cnt = new DeploymentCountry();
        for (int i = 0; i < cnt.getDefSupportedLangs().length; i++){
            String lang = cnt.getDefSupportedLangs()[i];

			for(int j = 0; j < brtypes.size(); j++){
				AddRefTranslation(allref, brtypes.get(j), lang);
			}

        }
        return allref;
	}
	
	public VectorGisBaseReferenceRaw LoadGisReferences() throws Exception{
		VectorGisBaseReferenceRaw allref = new VectorGisBaseReferenceRaw();
		AddGisRef(allref);
        return allref;
	}

	public VectorGisBaseReferenceTranslationRaw LoadGisReferenceTranslations() throws Exception{
		VectorGisBaseReferenceTranslationRaw allref = new VectorGisBaseReferenceTranslationRaw();
        DeploymentCountry cnt = new DeploymentCountry();
        for (int i = 0; i < cnt.getDefSupportedLangs().length; i++) {
            String lang = cnt.getDefSupportedLangs()[i];
            AddGisRefTranslation(allref, lang);
        }
        return allref;
	}

}

