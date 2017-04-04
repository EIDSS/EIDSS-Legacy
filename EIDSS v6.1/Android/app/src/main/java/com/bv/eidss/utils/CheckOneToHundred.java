package com.bv.eidss.utils;

import android.text.Editable;
import android.text.TextWatcher;

public class CheckOneToHundred implements TextWatcher{
    public void afterTextChanged(Editable s) {
        try {
            if(Integer.parseInt(s.toString())>100)
                s.replace(0, s.length(), "100");
            else if(Integer.parseInt(s.toString())==0)
                s.replace(0, s.length(), "1");
        }
        catch(NumberFormatException nfe){}
    }
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {
        // Not used, details on text just before it changed
	// used to track in detail changes made to text, e.g. implement an undo
    }
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        // Not used, details on text at the point change made
    }
}

