package com.bv.eidss.barcode;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Rect;
import android.util.AttributeSet;
import android.util.TypedValue;

import com.bv.eidss.barcode.core.ViewFinderView;
import com.bv.eidss.R;

/**
 * Created by Ivan on 3/2/2016.
 */
public  class CustomViewFinderView extends ViewFinderView {

        public final Paint PAINT = new Paint();

        public CustomViewFinderView(Context context) {
            super(context);
            init();
        }

        public CustomViewFinderView(Context context, AttributeSet attrs) {
            super(context, attrs);
            init();
        }

        private void init() {
            PAINT.setColor(Color.WHITE);
            PAINT.setAntiAlias(true);
            float textPixelSize = TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_SP,
                    getResources().getDimension(R.dimen.barcode_hint_size), getResources().getDisplayMetrics());
            PAINT.setTextSize(textPixelSize);
        }

        @Override
        public void onDraw(Canvas canvas) {
            super.onDraw(canvas);

            Rect framingRect = getFramingRect();
            float hintTop;
            float hintLeft;
            if (framingRect != null) {
                hintTop = framingRect.bottom + PAINT.getTextSize() + 10;
                hintLeft = framingRect.left;
            } else {
                hintTop = 10;
                hintLeft = canvas.getHeight() - PAINT.getTextSize() - 10;
            }

            String hint = getResources().getString(R.string.BarcodeScannerHint);
            canvas.drawText(hint, hintLeft, hintTop, PAINT);
        }


    }


