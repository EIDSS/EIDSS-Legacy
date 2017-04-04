package com.bv.eidss.barcode;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.view.View;
import android.widget.Toast;

import com.bv.eidss.EidssBaseBlockTimeoutActivity;
import com.bv.eidss.R;

public class BarcodeTestActivity extends EidssBaseBlockTimeoutActivity {
    private static final int ZXING_CAMERA_PERMISSION = 1;


    @Override
    protected void onCreate(Bundle state) {
        super.onCreate(state);
        //setContentView(R.layout.activity_barcode_test);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode,  String permissions[], int[] grantResults) {
        switch (requestCode) {
            case ZXING_CAMERA_PERMISSION:
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    Intent intent = new Intent(this, BarcodeScannerActivity.class);
                    startActivityForResult(intent, 90);
                } else {
                    Toast.makeText(this, "Please grant camera permission to use the QR Scanner", Toast.LENGTH_SHORT).show();
                }
                return;
        }
    }

    public void launchSimpleActivity(View v) {
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.CAMERA}, ZXING_CAMERA_PERMISSION);
        } else {
            Intent intent = new Intent(this, BarcodeScannerActivity.class);
            startActivityForResult(intent, getResources().getInteger(R.integer.REQUEST_BARCODE));
        }
    }

/*    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode == RESULT_OK) {
            String result = data.getStringExtra("barcode");
            TextView barcodeContent = (TextView) findViewById(R.id.barcode_content);
            if(barcodeContent != null) {
                barcodeContent.setEnabled(true);
                barcodeContent.setText(result);
            }
        }
    }*/
}