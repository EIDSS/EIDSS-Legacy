package com.bv.eidss.web;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.json.JSONException;
import org.json.JSONObject;

import com.bv.eidss.model.Species;

public class SpeciesInfoIn {
    public String lang;
	
    public Long id;
    public Long herd;
    public Long speciesType;
    public Date startOfSignsDate;
    public int totalAnimalQty;
    public int deadAnimalQty;
    public int sickAnimalQty;
    
    public SpeciesInfoIn(){}
    
    public SpeciesInfoIn(Species s, String lng){
        lang = lng;
		id = s.getId();
		herd = s.getHerd();
		speciesType = s.getSpeciesType();
		startOfSignsDate = s.getStartOfSignsDate();
		totalAnimalQty = s.getTotalAnimalQty();
		deadAnimalQty = s.getDeadAnimalQty();
		sickAnimalQty = s.getSickAnimalQty();
    }
    
    public JSONObject json() throws JSONException{
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	JSONObject ret = new JSONObject();
    	ret.put("lang", lang);
    	ret.put("id", id);
    	ret.put("herd", herd.longValue());
    	ret.put("speciesType", speciesType.longValue());
    	if (startOfSignsDate != null)
        	ret.put("startOfSignsDate", format.format(startOfSignsDate).replace(' ', 'T'));
    	ret.put("totalAnimalQty", totalAnimalQty);
    	ret.put("deadAnimalQty", deadAnimalQty);
    	ret.put("sickAnimalQty", sickAnimalQty);
    	return ret;
    }
}
