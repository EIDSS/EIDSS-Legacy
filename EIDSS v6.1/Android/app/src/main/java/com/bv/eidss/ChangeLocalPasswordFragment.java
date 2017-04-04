package com.bv.eidss;


import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.NavUtils;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;


public class ChangeLocalPasswordFragment extends Fragment {
    public static ChangeLocalPasswordFragment newInstance() {
        return new ChangeLocalPasswordFragment();
    }

    public ChangeLocalPasswordFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.change_local_password_layout, container, false);

        Toolbar toolbar = (Toolbar) v.findViewById(R.id.toolbar);
        ((ActionBarActivity)getActivity()).setSupportActionBar(toolbar);
        ((ActionBarActivity)getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        final EditText pwdold = (EditText)v.findViewById(R.id.OldPassword);
        final EditText pwd = (EditText)v.findViewById(R.id.LoginPassword);
        final EditText pwd2 = (EditText)v.findViewById(R.id.LoginPassword2);

        v.findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                EidssDatabase db = new EidssDatabase(getActivity());
                String oldpwd = db.Options().getLocalPassword();
                db.close();

                if (oldpwd.compareTo(pwdold.getText().toString()) != 0)
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(),R.string.PasswordOldInvalid);
                    return;
                }
                if (pwd.getText().toString().compareTo(pwd2.getText().toString()) != 0)
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(),R.string.PasswordNotSame);
                    return;
                }
                if (pwd.getText().length() < getResources().getInteger(R.integer.PASSWORD_MIN_LENGTH))
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.PasswordNotSet);
                    return;
                }

                db = new EidssDatabase(getActivity());
                Options opt = db.Options();
                opt.setLocalPassword(pwd.getText().toString());
                db.OptionsUpdate(opt);
                db.close();

                Intent intent = NavUtils.getParentActivityIntent(getActivity());
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(intent);
            }
        });

        return v;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            // Respond to the action bar's Up/Home button
            case android.R.id.home:
                Intent intent = NavUtils.getParentActivityIntent(getActivity());
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(intent);
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
