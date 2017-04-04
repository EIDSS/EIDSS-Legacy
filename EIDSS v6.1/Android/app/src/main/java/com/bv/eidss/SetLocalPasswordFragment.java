package com.bv.eidss;
import android.graphics.Typeface;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;


/**
 * A simple {@link Fragment} subclass.
 */
public class SetLocalPasswordFragment extends Fragment {


    public SetLocalPasswordFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.set_local_password_layout, container, false);

        final Button btnContinue = (Button)v.findViewById(R.id.OkButton);
        btnContinue.setEnabled(false);
        final EditText pwd = (EditText)v.findViewById(R.id.LoginPassword);
        final EditText pwd2 = (EditText)v.findViewById(R.id.LoginPassword2);
        pwd.setTypeface( Typeface.DEFAULT );
        pwd2.setTypeface( Typeface.DEFAULT );

        pwd.addTextChangedListener(new TextWatcher(){
            public void afterTextChanged(Editable s) {
                if(s.length() >= getResources().getInteger(R.integer.PASSWORD_MIN_LENGTH) & pwd2.length() >= getResources().getInteger(R.integer.PASSWORD_MIN_LENGTH))
                    btnContinue.setEnabled(true);
                else
                    btnContinue.setEnabled(false);
            }
            public void beforeTextChanged(CharSequence s, int start, int count, int after){}
            public void onTextChanged(CharSequence s, int start, int before, int count){}
        });
        pwd2.addTextChangedListener(new TextWatcher(){
            public void afterTextChanged(Editable s) {
                if(s.length() >= getResources().getInteger(R.integer.PASSWORD_MIN_LENGTH) & pwd.length() >= getResources().getInteger(R.integer.PASSWORD_MIN_LENGTH))
                    btnContinue.setEnabled(true);
                else
                    btnContinue.setEnabled(false);
            }
            public void beforeTextChanged(CharSequence s, int start, int count, int after){}
            public void onTextChanged(CharSequence s, int start, int before, int count){}
        });
        btnContinue.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                if (pwd.getText().toString().compareTo(pwd2.getText().toString()) != 0)
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.PasswordNotSame);
                    return;
                }
                EidssDatabase db = new EidssDatabase(getActivity());
                Options opt = db.Options();
                opt.setLocalPassword(pwd.getText().toString());
                db.OptionsUpdate(opt);
                db.close();

                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), ((SetLocalPasswordActivity)getActivity()).REFLOAD_DIALOG_ID, R.string.LoadRefOnStart);
            }
        });

        return v;
    }


}
