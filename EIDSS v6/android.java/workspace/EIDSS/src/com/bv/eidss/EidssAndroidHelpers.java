package com.bv.eidss;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.app.AlertDialog.Builder;
import android.app.Dialog;
import android.content.DialogInterface;
import android.view.View;

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
    
    public static Dialog ErrorDialogAndFinishActivity(final Activity context, String text)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(text);
        builder.setCancelable(false);
        builder.setPositiveButton(context.getResources().getString(R.string.Ok), new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dlg, int arg) {
				dlg.dismiss();
				context.finish();
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

    public static Dialog MessageDialog(Activity context, String text)
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

    public static Dialog MessageDialogAndFinishActivity(final Activity context, String text)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(text);
        builder.setCancelable(false);
        builder.setPositiveButton(context.getResources().getString(R.string.Ok), new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dlg, int arg) {
				dlg.dismiss();
				context.finish();
			}
		});
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
    
    public static Dialog InputTextDialog(Activity context, String title, View view, DialogInterface.OnClickListener handler_yes, DialogInterface.OnClickListener handler_no)
    {
    	Builder builder = new AlertDialog.Builder(context);
        builder.setTitle(title);
        builder.setView(view);
        //builder.setCancelable(false);
        //builder.setNegativeButton(context.getResources().getString(R.string.Cancel), handler_no);
        builder.setPositiveButton(context.getResources().getString(R.string.Ok), handler_yes);
        return builder.create();
    }
    
    public static ProgressDialog ProgressDialog(final Activity context, int messageId, DialogInterface.OnClickListener handler){
    	final ProgressDialog mDialog = new ProgressDialog(context, ProgressDialog.STYLE_SPINNER);
		mDialog.setMessage(context.getResources().getString(messageId));
		mDialog.setCancelable(false);
		mDialog.setCanceledOnTouchOutside(false);
		mDialog.setButton(ProgressDialog.BUTTON_NEGATIVE, context.getResources().getString(R.string.Abort), handler);
		mDialog.show();
		return mDialog;
    }
}
