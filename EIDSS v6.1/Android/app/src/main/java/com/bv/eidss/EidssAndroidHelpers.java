package com.bv.eidss;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewParent;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.LanguageItem;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.utils.EidssContextUtils;
import com.bv.eidss.utils.EidssUtils;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;


public class EidssAndroidHelpers {

    // dialog for input date
    public static class DatePickerFragment extends DialogFragment implements DatePickerDialog.OnDateSetListener {
        private long idfFormType;
        private int idDialog;
        private DialogDoneDateListener mListener;

        public static void Show(FragmentManager fm, final int idDialog, final Date date) {
            EidssAndroidHelpers.DatePickerFragment.Show(fm, idDialog, 0, null, date, 0);
        }

        public static void Show(FragmentManager fm, final int idDialog, final String titleS, final Date date) {
            EidssAndroidHelpers.DatePickerFragment.Show(fm, idDialog, 0, titleS, date, 0);
        }

        public static void Show(FragmentManager fm, final int idDialog, final int title, final Date date) {
            EidssAndroidHelpers.DatePickerFragment.Show(fm, idDialog, title, null, date, 0);
        }

        public static void Show(FragmentManager fm, final int idDialog, final int title, final String titleS, final Date date, long idFormType) {
            final Calendar c = Calendar.getInstance();
            if(date != null)
                c.setTime(date);
            final int year = c.get(Calendar.YEAR);
            final int month = c.get(Calendar.MONTH);
            final int day = c.get(Calendar.DAY_OF_MONTH);

            DialogFragment df = EidssAndroidHelpers.DatePickerFragment.newInstance(idDialog, title, titleS, year, month, day, idFormType);
            df.show(fm, "datePicker");
        }

        public static void Show(FragmentManager fm, final int idDialog, final int title, final String titleS) {
            final Calendar c = Calendar.getInstance();
            final int year = c.get(Calendar.YEAR);
            final int month = c.get(Calendar.MONTH);
            final int day = c.get(Calendar.DAY_OF_MONTH);

            DialogFragment df = EidssAndroidHelpers.DatePickerFragment.newInstance(idDialog, title, titleS, year, month, day, 0);
            df.show(fm, "datePicker");
        }

        public static void Show(FragmentManager fm, final int idDialog, final int title, final String titleS, final int year, final int month, final int day) {
            DialogFragment df = EidssAndroidHelpers.DatePickerFragment.newInstance(idDialog, title, titleS, year, month, day, 0);
            df.show(fm, "datePicker");
        }

        public static DatePickerFragment newInstance(final int idDialog, final int title, final String titleS, final int year, final int month, final int day, long idFormType) {
            DatePickerFragment frag = new DatePickerFragment();
            Bundle args = new Bundle();

            args.putInt("idDialog", idDialog);

            if(title > 0)
                args.putInt("title", title);
            if(titleS != null)
                args.putString("titleS", titleS);

            args.putInt("year", year);
            args.putInt("month", month);
            args.putInt("day", day);
            args.putLong("idFormType", idFormType);

            frag.setArguments(args);
            return frag;
        }

        @Override
        @NonNull
        public Dialog onCreateDialog( Bundle savedInstanceState)
        {

            idDialog = getArguments().getInt("idDialog");
            final int title = getArguments().getInt("title", 0);
            final String titleS = getArguments().getString("titleS");
            final int year = getArguments().getInt("year");
            final int month = getArguments().getInt("month");
            final int day = getArguments().getInt("day");
            idfFormType = getArguments().getLong("idFormType");
            if (idfFormType > 0 &&  mListener instanceof IFFModel){
                mListener = ((IFFModel)mListener).getFFFragment(idfFormType);
            }

            DatePickerDialog dpd = new DatePickerDialog(getActivity(), this, year, month, day);
            if(title > 0)
                dpd.setTitle(title);
            else if(titleS != null)
                dpd.setTitle(titleS);
            return dpd;
        }

        public void onDateSet(DatePicker view, int year, int month, int day) {
            mListener.onDone(idDialog, year, month, day);
        }

        @Override
        public void onAttach(Activity activity) {
            super.onAttach(activity);
            try {
                mListener = (DialogDoneDateListener) activity;
            } catch (ClassCastException e) {
                throw new ClassCastException(activity.toString()
                        + " must implement DialogDoneDateListener interface");
            }
        }

        @Override
        public void onDetach() {
            super.onDetach();
            mListener = null;
        }
    }

    // dialog for input text
    public static class AlertInputDialog extends DialogFragment {
        private DialogDoneTextListener mListener;

        public static AlertInputDialog newInstance(int idDialog, int title, int message, int positiveButtonText, String messageS, String text) {
            AlertInputDialog frag = new AlertInputDialog();
            Bundle args = new Bundle();

            args.putInt("idDialog", idDialog);

            if(title > 0)
                args.putInt("title", title);
            if(message > 0)
                args.putInt("message", message);
            if(messageS != null)
                args.putString("messageS", messageS);
            if(text != null)
                args.putString("text", text);
            if(positiveButtonText > 0)
                args.putInt("positiveButtonText", positiveButtonText);

            frag.setArguments(args);
            return frag;
        }

        public static void Show(FragmentManager fm, int idDialog, int title) {
            DialogFragment df = EidssAndroidHelpers.AlertInputDialog.newInstance(idDialog, title, 0, 0, null, null);
            df.show(fm, "dialog");
        }

        public static void Rename(FragmentManager fm, int idDialog, int title, String text) {
            DialogFragment df = EidssAndroidHelpers.AlertInputDialog.newInstance(idDialog, title, 0, 0, null, text);
            df.show(fm, "dialog");
        }

        @Override
        @NonNull
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            final int idDialog = getArguments().getInt("idDialog");
            final int title = getArguments().getInt("title", 0);
            final int mess = getArguments().getInt("message", 0);
            final String messageS = getArguments().getString("messageS");
            final String text = getArguments().getString("text");
            final int positiveButtonText = getArguments().getInt("positiveButtonText", R.string.Ok);

            AlertDialog.Builder adb = new AlertDialog.Builder(getActivity());//.setIcon(iconId);
            if(title > 0)
                adb.setTitle(title);
            if(mess > 0)
                adb.setMessage(mess);
            if(messageS != null)
                adb.setMessage(messageS);

            LayoutInflater inflater = getActivity().getLayoutInflater();
            View view = inflater.inflate(R.layout.input_text, null);
            adb.setView(view);
            final EditText edName = (EditText)view.findViewById(R.id.edText);
            if(text != null)
                edName.setText(text);

            adb.setPositiveButton(positiveButtonText,
                    new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int whichButton) {
                            String value = edName.getText().toString();
                            dialog.dismiss();
                            mListener.onDone(idDialog, true, value);
                        }
                    });
            adb.setNegativeButton(R.string.Cancel,
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int whichButton) {
                                dialog.dismiss();
                                mListener.onDone(idDialog, false, "");
                            }
                        });
            return adb.create();
        }

        @Override
        public void onAttach(Activity activity) {
            super.onAttach(activity);
            try {
                mListener = (DialogDoneTextListener) activity;
            } catch (ClassCastException e) {
                throw new ClassCastException(activity.toString()
                        + " must implement DialogClickListener interface");
            }
        }

        @Override
        public void onDetach() {
            super.onDetach();
            mListener = null;
        }
    }

    // dialog without listener
    public static class AlertOkDialog extends DialogFragment {

        public static void Show(FragmentManager fm, int title) {
            DialogFragment df = AlertOkDialog.newInstance(title, 0, 0, null, null);
            df.show(fm,"dialog");
        }

        public static DialogFragment Show(int title) {
            return AlertOkDialog.newInstance(title, 0, 0, null, null);
        }

        public static void Warning(FragmentManager fm, int message) {
            DialogFragment df = AlertOkDialog.newInstance(0, message, R.drawable.eidss_ic_important, null, null);
            df.show(fm,"dialog");
        }

        public static DialogFragment Warning(int message) {
            return AlertOkDialog.newInstance(0, message, R.drawable.eidss_ic_important, null, null);
        }

        public static void Show(FragmentManager fm, String title) {
            DialogFragment df = AlertOkDialog.newInstance(0, 0, 0, title, null);
            df.show(fm,"dialog");
        }
        public static void Warning(FragmentManager fm, String message) {
            DialogFragment df = AlertOkDialog.newInstance(0, 0, R.drawable.eidss_ic_important, null, message);
            df.show(fm,"dialog");
        }

        private static AlertOkDialog newInstance(int title, int message, int iconId, String titleS, String messageS) {
            AlertOkDialog frag = new AlertOkDialog();
            Bundle args = new Bundle();
            if(title > 0)
                args.putInt("title", title);
            if(message > 0)
                args.putInt("message", message);
            if(titleS != null)
                args.putString("titleS", titleS);
            if(messageS != null)
                args.putString("messageS", messageS);
            if(iconId > 0)
                args.putInt("iconId", iconId);
            frag.setArguments(args);
            return frag;
        }


        @Override
        @NonNull
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            final String titleS = getArguments().getString("titleS");
            final String messageS = getArguments().getString("messageS");
            final int title = getArguments().getInt("title", R.string.Information);
            final int mess = getArguments().getInt("message", 0);
            final int iconId = getArguments().getInt("iconId", 0);

            AlertDialog.Builder adb = new AlertDialog.Builder(getActivity());
            if(iconId > 0)
                adb.setIcon(iconId);
            if(titleS == null)
                adb.setTitle(title);
            else
                adb.setTitle(titleS);
            adb.setPositiveButton(R.string.Ok,
                    new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int whichButton) { }
                    });
            if(mess > 0)
                adb.setMessage(mess);
            if(messageS != null)
                adb.setMessage(messageS);
            return adb.create();
        }
    }

    // dialog with listener
    public static class AlertOkResultDialog extends DialogFragment {
        private DialogDoneListener mListener;

        public static void ShowOk(FragmentManager fm, int idDialog, String title) {
            DialogFragment df = EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, 0, R.string.Ok, 0, 0, title);
            df.show(fm, "dialog");
        }

        public static void ShowOk(FragmentManager fm, int idDialog, int title) {
            DialogFragment df = EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, title, R.string.Ok, 0, 0, null);
            df.show(fm, "dialog");
        }

        public static DialogFragment ShowOk(int idDialog, int title) {
            return EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, title, R.string.Ok, 0, 0, null);
         }

        public static void ShowWarning(FragmentManager fm, int idDialog, int title) {
            DialogFragment df = EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, title, R.string.Ok, 0, R.drawable.eidss_ic_important, null);
            df.show(fm, "dialog");
        }

        public static void ShowQuestion(FragmentManager fm, int idDialog, int title) {
            DialogFragment df = EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, title, R.string.Yes, R.string.No, R.drawable.question, null);
            df.show(fm, "dialog");
        }

        public static void ShowQuestion(FragmentManager fm, int idDialog, String title) {
            DialogFragment df = EidssAndroidHelpers.AlertOkResultDialog.newInstance(idDialog, 0, 0, R.string.Yes, R.string.No, R.drawable.question, title);
            df.show(fm, "dialog");
        }

        public static AlertOkResultDialog newInstance(int idDialog, int title) {
            return newInstance(idDialog, title, 0, 0, 0, 0, null);
        }

        public static AlertOkResultDialog newInstance(int idDialog, int title, int message, int positiveButtonText, int negativeButtonText, int iconId, String messageS) {
            AlertOkResultDialog frag = new AlertOkResultDialog();
            Bundle args = new Bundle();

            args.putInt("idDialog", idDialog);

            if(title > 0)
                args.putInt("title", title);
            if(message > 0)
                args.putInt("message", message);
            if(messageS != null)
                args.putString("messageS", messageS);
            if(positiveButtonText > 0)
                args.putInt("positiveButtonText", positiveButtonText);
            if(negativeButtonText > 0)
                args.putInt("negativeButtonText", negativeButtonText);
            if(iconId > 0)
                args.putInt("iconId", iconId);

            frag.setArguments(args);
            return frag;
        }


         @Override
         @NonNull
        public Dialog onCreateDialog(Bundle savedInstanceState) {
             final int idDialog = getArguments().getInt("idDialog");
             final int title = getArguments().getInt("title", 0);
             final int mess = getArguments().getInt("message", 0);
             final String messageS = getArguments().getString("messageS");
             final int positiveButtonText = getArguments().getInt("positiveButtonText", R.string.Ok);
             final int negativeButtonText = getArguments().getInt("negativeButtonText", 0);
             final int iconId = getArguments().getInt("iconId", 0);

            AlertDialog.Builder adb = new AlertDialog.Builder(getActivity());
             if(iconId > 0)
                 adb.setIcon(iconId);
             if(title > 0)
                 adb.setTitle(title);
             if(mess > 0)
                 adb.setMessage(mess);
             if(messageS != null)
                 adb.setMessage(messageS);

            adb.setPositiveButton(positiveButtonText,
                    new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int whichButton) {
                            dialog.dismiss();
                            mListener.onDone(idDialog, true);
                        }
                    });
            if(negativeButtonText > 0)
                adb.setNegativeButton(negativeButtonText,
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int whichButton) {
                                dialog.dismiss();
                                mListener.onDone(idDialog, false);
                            }
                        });
            return adb.create();
        }
        @Override
        public void onAttach(Activity activity) {
            super.onAttach(activity);
            try {
                mListener = (DialogDoneListener) activity;
            } catch (ClassCastException e) {
                throw new ClassCastException(activity.toString()
                        + " must implement DialogClickListener interface");
            }
        }

        @Override
        public void onDetach() {
            super.onDetach();
            mListener = null;
        }
    }

    public static ProgressDialog ProgressDialog(final Activity context, int messageId, DialogInterface.OnClickListener handler){
    	final ProgressDialog mDialog = new ProgressDialog(context, ProgressDialog.STYLE_SPINNER);
        mDialog.setTitle(messageId);
        mDialog.setMessage(context.getResources().getString(R.string.WaitPlease));
		mDialog.setCancelable(false);
		mDialog.setCanceledOnTouchOutside(false);
		mDialog.setButton(ProgressDialog.BUTTON_NEGATIVE, context.getResources().getString(R.string.Abort), handler);
		mDialog.show();
		return mDialog;
    }


// interfaces
    public interface DialogDoneListener {
        void onDone(int idDialog, boolean isPositive);
    }

    public interface DialogDoneTextListener {
        void onDone(int idDialog, boolean isPositive, String text);
    }

    public interface DialogDoneDateListener {
        void onDone(int idDialog, int year, int month, int day);
    }

    public interface AsyncResponse {
        void onTaskStarted();
        void onTaskFinished(String result);    }

    public interface AsyncResponseI {
        void onTaskStarted();
        void onTaskFinished(Integer result);    }

    public interface AsyncResponseH {
        void onTaskStarted();
        void onTaskFinished(HumanCase result);    }

    public interface AsyncResponseV {
        void onTaskStarted();
        void onTaskFinished(VetCase result);    }

    public interface AsyncResponseA {
        void onTaskStarted();
        void onTaskFinished(ASSession result);    }

    public static String SetLocale()
    {
        String lang = EidssDatabase.GetOptions().getDefLang();
        Locale locale;
        if (lang != null && lang.compareTo("def") != 0){
            locale = new Locale(lang);
        }
        else{
            locale = Resources.getSystem().getConfiguration().locale;
        }
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;
        App.getResourcesStatic().updateConfiguration(config, App.getResourcesStatic().getDisplayMetrics());

        return lang;
    }

    public static ArrayList<LanguageItem> GetSupportedLanguagesList(){
        ArrayList<LanguageItem> ret = new ArrayList<>();
        ret.add(new LanguageItem("def"));
        DeploymentCountry country = new DeploymentCountry();
        for (int i = 0; i < country.getDefSupportedLangs().length; i++) {
            String lang = country.getDefSupportedLangs()[i];
            LanguageItem item = new LanguageItem(lang);
            ret.add(item);
        }
        return ret;
    }

    public static View findViewById(int id, Object a) {
        if (a instanceof Activity)
            return (((Activity)a).findViewById(id));
        else
            return (((View)a).findViewById(id));
    }

    public static void EnableSpinner(int idSpin, Object a, boolean bSetMandatory){
        Spinner ed = (Spinner)findViewById(idSpin, a);
        if (ed.getAdapter().getCount() > 0)
            EidssUtils.setEnabled(ed, true);
        if (bSetMandatory)
            EidssUtils.SetMandatoryHeader(ed);
    }
    public static void DisableSpinner(int idSpin, Object a){
        Spinner ed = (Spinner)findViewById(idSpin, a);
        ed.setSelection(0);
        EidssUtils.setEnabled(ed, false);
    }

    public static void EnableAutoCompleteTextView(int idSpin, Object a){
        AutoCompleteTextView ed = (AutoCompleteTextView)(findViewById(idSpin, a));
        EidssUtils.setEnabled(ed, true);
    }
    public static void DisableAutoCompleteTextView(int idSpin, Object a){
        AutoCompleteTextView ed = (AutoCompleteTextView)(findViewById(idSpin, a));
        ed.setText("");
        EidssUtils.setEnabled(ed, false);
    }




    public static void EnableDate(int idDate, int idBtn, Object a){
        final TextView ed = (TextView)(findViewById(idDate, a));
        final Button bt = (Button)(findViewById(idBtn, a));
        EidssUtils.setEnabled(ed, true);
        bt.setEnabled(true);
    }
    public static void DisableDate(int idDate, int idBtn, Object a){
        final TextView ed = (TextView)(findViewById(idDate, a));
        final Button bt = (Button)(findViewById(idBtn, a));
        EidssUtils.setEnabled(ed, false);
        bt.setEnabled(false);
    }

    public static void EnableTextbox(int idText, Object a){
        final TextView ed = (TextView)(findViewById(idText, a));
        EidssUtils.setEnabled(ed, true);
    }
    public static void DisableTextbox(int idText, Object a){
        final TextView ed = (TextView) (findViewById(idText, a));
        ed.setText("");
        EidssUtils.setEnabled(ed, false);
    }
    public static void EnableTextbox(int idText, Object a, boolean bSetMandatory){
        final TextView ed = (TextView)(findViewById(idText, a));
        EidssUtils.setEnabled(ed, true);
        if (bSetMandatory)
            EidssUtils.SetMandatoryHeader(ed);
    }

    public static void DisableAddress(Boolean state, View v)
    {
        if (state) {
            EidssAndroidHelpers.DisableTextbox(R.id.strStreetName, v);
            EidssAndroidHelpers.DisableTextbox(R.id.strBuilding, v);
            EidssAndroidHelpers.DisableTextbox(R.id.strHouse, v);
            EidssAndroidHelpers.DisableTextbox(R.id.strApartment, v);
            EidssAndroidHelpers.DisableTextbox(R.id.strPostCode, v);
        } else {
            EidssAndroidHelpers.EnableTextbox(R.id.strStreetName, v);
            EidssAndroidHelpers.EnableTextbox(R.id.strBuilding, v);
            EidssAndroidHelpers.EnableTextbox(R.id.strHouse, v);
            EidssAndroidHelpers.EnableTextbox(R.id.strApartment, v);
            EidssAndroidHelpers.EnableTextbox(R.id.strPostCode, v);
        }
    }
}
