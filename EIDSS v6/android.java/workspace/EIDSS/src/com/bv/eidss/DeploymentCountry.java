package com.bv.eidss;

public class DeploymentCountry {
	private static final int DEPLOYMENT_COUNTRY = DeploymentCountry.deployDebug;
	//private static final int DEPLOYMENT_COUNTRY = DeploymentCountry.deployDebug2;
	//private static final int DEPLOYMENT_COUNTRY = DeploymentCountry.deployTestStend;
	//private static final int DEPLOYMENT_COUNTRY = DeploymentCountry.deployGat;

	
	private static final int deployDebug = 1;
	private static final int deployDebugSsl = 2;
	private static final int deployTestStend = 3;
	private static final int deployGat = 4;
	private static final int deployDebug2 = 5;
	private static final int deployTz = 11; // Танзания
	
	private String defServerUrl = "";
	private String defLoginOrganization = "";
	private String defLoginUser = "";
	public String getDefServerUrl() { return defServerUrl; } 
	public String getDefLoginOrganization() { return defLoginOrganization; } 
	public String getDefLoginUser() { return defLoginUser; } 
	
	@SuppressWarnings("unused")
	public DeploymentCountry(){
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployDebug){
			defServerUrl = "http://192.168.10.34:8086/";
			defLoginOrganization = "NCDC&PH";
			defLoginUser = "test_admin";
		}
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployDebug2){
			defServerUrl = "http://192.168.10.23:8080/";
			defLoginOrganization = "qqq";
			defLoginUser = "test_admin";
		}
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployDebugSsl){
			defServerUrl = "https://192.168.10.34:2443/";
			defLoginOrganization = "NCDC&PH";
			defLoginUser = "test_admin";
		}
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployTestStend){
			defServerUrl = "http://192.168.3.171:8810/";
		}
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployGat){
			defServerUrl = "http://smartphone.eidss6gat.net/";
		}
		if (DEPLOYMENT_COUNTRY == DeploymentCountry.deployTz){
			defServerUrl = "http://oa.eidss.or.tz/";
		}
	}
	
}
