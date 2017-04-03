package com.bv.eidss;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.widget.ListView;

public class ExpandedListView extends ListView {

    private android.view.ViewGroup.LayoutParams params;
    private int old_count = 0;

    public ExpandedListView(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        if (getCount() != old_count) {
            old_count = getCount();
            params = getLayoutParams();
            if(old_count > 0 && getCount() > 0)
                params.height = getCount()
                              * (getChildAt(0).getHeight() + getDividerHeight())
                              - getDividerHeight();
            else
                params.height = 0;            setLayoutParams(params);
        }

        super.onDraw(canvas);
    }

}