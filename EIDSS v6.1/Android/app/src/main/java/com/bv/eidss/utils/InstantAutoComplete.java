package com.bv.eidss.utils;

import android.content.Context;
import android.graphics.Rect;
import android.util.AttributeSet;
import android.widget.AutoCompleteTextView;

/**
 * Created by avdovin on 28.04.2016.
 */
public class InstantAutoComplete extends AutoCompleteTextView {
    public InstantAutoComplete(Context context) {
        super(context);
    }
    public InstantAutoComplete(Context context, AttributeSet arg1) {
        super(context, arg1);
    }
    public InstantAutoComplete(Context context, AttributeSet arg1, int arg2) {
        super(context, arg1, arg2);
    }
/*
    @Override
    public boolean enoughToFilter(){
        return true;
    }

    @Override
    protected void onFocusChanged(boolean focused, int direction, Rect previouslyFocusedRect){
        super.onFocusChanged(focused, direction, previouslyFocusedRect);
        if (focused && getAdapter() != null) {
            performFiltering(getText(), 0);
        }
    }
*/
}
