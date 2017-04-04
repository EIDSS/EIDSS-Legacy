package com.bv.eidss;

public class DeploymentCountry {
	private static String defCountry = "ka";
	public static String getDefCountry() { return defCountry; }
	private String defServerUrl = "";
	private String defLoginOrganization = "";
	private String defLoginUser = "";
	public String getDefServerUrl() { return defServerUrl; } 
	public String getDefLoginOrganization() { return defLoginOrganization; } 
	public String getDefLoginUser() { return defLoginUser; }

    private String[] defSupportedLangs;
    public String[] getDefSupportedLangs() { return defSupportedLangs; }

	public DeploymentCountry(){
        defServerUrl = "http://sp.test.dtra.t.eidss.info"; //"http://sp.dev.dtra.t.eidss.info/";
        defSupportedLangs = new String[]{
                "en",
                "ru",
                "ka"
        };
	}
	
}
