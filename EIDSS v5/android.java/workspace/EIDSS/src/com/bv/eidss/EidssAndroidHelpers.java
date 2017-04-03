package com.bv.eidss;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.app.Dialog;
import android.content.DialogInterface;

public class EidssAndroidHelpers {
    public static Dialog ErrorDialog(Activity context, String text)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(text);
        builder.setCancelable(false);
        builder.setPositiveButton(context.getResources().getString(R.string.Ok), new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dlg, int arg) {
				dlg.dismiss();
			}
		});
        return builder.create();
    }
    
    public static Dialog MessageDialog(Activity context, String text, DialogInterface.OnClickListener handler)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(text);
        builder.setCancelable(false);
        builder.setPositiveButton(context.getResources().getString(R.string.Ok), handler);
        return builder.create();
    }

    public static Dialog QuestionDialog(Activity context, String text, DialogInterface.OnClickListener handler_yes, DialogInterface.OnClickListener handler_no)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(text);
        builder.setCancelable(false);
        builder.setNegativeButton(context.getResources().getString(R.string.No), handler_no);
        builder.setPositiveButton(context.getResources().getString(R.string.Yes), handler_yes);
        return builder.create();
    }
}
