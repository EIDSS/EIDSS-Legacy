package com.bv.eidss;


import android.annotation.TargetApi;
import android.content.ContentUris;
import android.database.Cursor;
import android.net.Uri;
import android.os.Build;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SimpleCursorAdapter;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;

import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.utils.ArrayAdapterNoFilter;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.text.DateFormat;
import java.util.Date;
import java.util.List;
import java.util.NoSuchElementException;


public class EidssBaseBindableFragment extends Fragment {


    public EidssBaseBindableFragment() {
        // Required empty public constructor
    }

    protected void DisplayDateTime(final int id, final View v, final Date dt)
    {
        final TextView ed = (TextView)(v.findViewById(id));
        if (ed == null)
            throw new NoSuchElementException("TextView with id " + id + " not found.");
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(dt));
    }

    public void LookupBind(final int id, final View v, final long def, final long rft, final int ha, final AdapterView.OnItemSelectedListener listener, boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final Spinner sp = (Spinner)(v.findViewById(id));
        if (sp == null)
            throw new NoSuchElementException("Spinner with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(sp, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        EidssDatabase mDb = new EidssDatabase(getActivity());
        final List<BaseReference> list = mDb.Reference(rft, EidssUtils.getCurrentLanguage(), ha, def);
        mDb.close();

        BaseReferenceAdapter adapter = new BaseReferenceAdapter(getActivity(), list);
        sp.setAdapter(adapter);
        Boolean bFound = false;
        for(int i = 0; i < list.size(); i++){
            if (list.get(i).idfsBaseReference == def){
                sp.setSelection(i);
                bFound = true;
                break;
            }
        }
        if (listener != null)
            sp.setOnItemSelectedListener(listener);

        final ScrollView scroller = (ScrollView)(v.findViewById(R.id.Scroll));
        if (scroller != null) {
            sp.setOnTouchListener(new View.OnTouchListener() {
                public boolean onTouch(View arg0, MotionEvent arg1) {
                    scroller.requestChildFocus(sp, sp);
                    return false;
                }
            });
        }

        if (def != 0 && !bFound) {
            bEnabled = false;
        }
        sp.setEnabled(bEnabled);
    }

    public void LookupBind(final int id, final View v, final long def, final long f1, final long f2, final long rft, final int ha, final AdapterView.OnItemSelectedListener listener, boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final Spinner sp = (Spinner)(v.findViewById(id));
        if (sp == null)
            throw new NoSuchElementException("Spinner with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(sp, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        EidssDatabase mDb = new EidssDatabase(getActivity());
        final List<BaseReference> list = mDb.Reference(rft, EidssUtils.getCurrentLanguage(), ha, def, f1, f2);
        mDb.close();

        LookupBind(sp, list, listener, def, bEnabled);
    }

    public void LookupBind(final int id, final View v, final List<BaseReference> list, final AdapterView.OnItemSelectedListener listener, long selectedItem, boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields) {
        final Spinner sp = (Spinner) (v.findViewById(id));
        if (sp == null)
            throw new NoSuchElementException("Spinner with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(sp, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;
        LookupBind(sp, list, listener, selectedItem, bEnabled);
    }

    public void LookupBind(final View sp, final List<BaseReference> list, final AdapterView.OnItemSelectedListener listener, long selectedItem, boolean bEnabled, final Boolean isMandatory, final Boolean isInvisible) {
        EidssUtils.SetMandatoryAndInvisible(sp, isMandatory, isInvisible, !bEnabled);

        if(!isInvisible)
            LookupBind((Spinner) sp, list, listener, selectedItem, bEnabled);
    }


    public void LookupBind(final Spinner sp, final List<BaseReference> list, final AdapterView.OnItemSelectedListener listener, long selectedItem, boolean bEnabled)
    {
        if (listener != null)
            sp.setOnItemSelectedListener(listener);

        BaseReferenceAdapter adapter = new BaseReferenceAdapter(getActivity(), list);
        sp.setAdapter(adapter);
        Boolean bFound = false;
        if (selectedItem != 0)
            for (int i = 0; i < list.size(); i++) {
                if (list.get(i).idfsBaseReference == selectedItem) {
                    sp.setSelection(i);
                    bFound = true;
                    break;
                }
            }

        if (selectedItem != 0 && !bFound) {
            bEnabled = false;
        }
        sp.setEnabled(bEnabled);
    }

    public void LookupBindBefore(final Spinner sp, final View v, final AdapterView.OnItemSelectedListener listener, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        if (!EidssUtils.SetMandatoryAndInvisible(sp, fldName, mandatoryFields, invisibleFields, !sp.isEnabled()))
            return;

        if (listener != null)
            sp.setOnItemSelectedListener(listener);

/*      can't remember what for is this - so commented
        final ScrollView scroller = (ScrollView)(v.findViewById(R.id.Scroll));
        sp.setOnTouchListener(new View.OnTouchListener(){
            public boolean onTouch(View arg0, MotionEvent arg1) {
                scroller.requestChildFocus(sp, sp);
                return false;
            }});*/

        sp.setEnabled(false);
    }
    public boolean LookupBindAfter(final Spinner sp, List<GisBaseReference> list, final long def, final boolean bEnabled, final Uri uri)
    {
        GisBaseReferenceAdapter adapter = new GisBaseReferenceAdapter(getActivity(), list);
        sp.setAdapter(adapter);
        boolean ret = true;

        if (def != 0) {
            Boolean bFound = false;
            for (int i = 0; i < list.size(); i++) {
                if (list.get(i).idfsBaseReference == def) {
                    sp.setSelection(i);
                    bFound = true;
                    break;
                }
            }

            // not found - add historic or filtered data
            if (!bFound) {
                GisBaseReference item = new GisBaseReference();
                item.idfsBaseReference = def;
                item.name = EidssUtils.getStringFromDB(getActivity(), uri, def);
                if(item.name == null)
                    ret = false;
                else{
                    list.add(item);
                    adapter = new GisBaseReferenceAdapter(getActivity(), list);
                    sp.setAdapter(adapter);
                    adapter.notifyDataSetChanged();
                    sp.setSelection(list.size() - 1);
                }
            }
        }

        sp.setEnabled(bEnabled);
        return ret;//false - nothing found to select
    }

    public void LookupBindAuto(final AutoCompleteTextView ac, final AdapterView.OnItemClickListener listener, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        if (!EidssUtils.SetMandatoryAndInvisible(ac, fldName, mandatoryFields, invisibleFields, !ac.isEnabled()))
            return;


        ac.setOnItemClickListener(listener);

        ac.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                // show all values
                ac.showDropDown();
                // hide soft keyboard
                getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
            }
        });
    }


    @SuppressWarnings("unchecked")
    public void LookupBindAutoAfter(final AutoCompleteTextView ac, List<BaseReference> list, final long def, boolean bEnabled) {
        ArrayAdapter<BaseReference> adapter = new ArrayAdapter(getActivity(), R.layout.custom_autocomplete_item, list);
        ac.setAdapter(adapter);

        if (def != 0) {
            Boolean bFound = false;
            for (int i = 0; i < list.size(); i++) {
                BaseReference item = list.get(i);
                if (item.idfsBaseReference == def) {
                    ac.setListSelection(i);
                    ac.setText(item.name);
                    bFound = true;
                    break;
                }
            }

            // not found - add historic data
            if (!bFound) {
                BaseReference item = new BaseReference(def, EidssUtils.getStringFromDB(getActivity(), ReferenciesProvider.CONTENT_URI, def));
                list.add(item);
                adapter = new ArrayAdapter(getActivity(), R.layout.custom_autocomplete_item, list);
                ac.setAdapter(adapter);
                adapter.notifyDataSetChanged();
                ac.setListSelection(list.size() - 1);
                ac.setText(item.name);
            }
        }
        ac.setEnabled(bEnabled);
    }

    public void LookupBind(final int id, final View v, final long def, final List<BaseReference> list,
                           final AdapterView.OnItemClickListener listener,
                           final OnEditTextChangeListener textListener,
                           boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final AutoCompleteTextView ac = (AutoCompleteTextView)(v.findViewById(id));
        if (ac == null)
            throw new NoSuchElementException("AutoCompleteTextView with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ac, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        //todo: create Adapter class for AutoCompleteTextView
        @SuppressWarnings("unchecked")
        //ArrayAdapter<BaseReference> adapter = new ArrayAdapter(getActivity(), R.layout.custom_autocomplete_item, list);
        ArrayAdapterNoFilter<BaseReference> adapter = new ArrayAdapterNoFilter(getActivity(), R.layout.custom_autocomplete_item, list);
        ac.setAdapter(adapter);

        Boolean bFound = false;
        for(int i = 0; i < list.size(); i++){
            BaseReference item = list.get(i);
            if (item.idfsBaseReference == def){
                // todo: check if it correct?
                ac.setListSelection(i);
                String[] parts = item.name.split(" / ");
                if (parts.length > 1){
                    ac.setText(parts[0]);
                } else {
                    ac.setText(item.name);
                }
                bFound = true;
                break;
            }
        }

        if (def != 0 && !bFound) {
            bEnabled = false;
        }
        ac.setEnabled(bEnabled);

        ac.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                listener.onItemClick(parent, view, position, id);
            }
        });

        ac.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                textListener.onEditTextChanged(s.toString());
            }
        });

        ac.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                // show all values
                ac.showDropDown();
                // hide soft keyboard
                getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
            }
        });
    }


    public void LookupBind(final int id, final View v, final long def, final long rft, final int ha, final AdapterView.OnItemClickListener listener, boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final AutoCompleteTextView ac = (AutoCompleteTextView)(v.findViewById(id));
        if (ac == null)
            throw new NoSuchElementException("AutoCompleteTextView with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ac, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        EidssDatabase mDb = new EidssDatabase(getActivity());
        List<BaseReference> list = mDb.Reference(rft, EidssUtils.getCurrentLanguage(), ha, def);
        mDb.close();

        //todo: create Adapter class for AutoCompleteTextView
        @SuppressWarnings("unchecked")
        ArrayAdapter<BaseReference> adapter = new ArrayAdapter(getActivity(), R.layout.custom_autocomplete_item, list);
        ac.setAdapter(adapter);

        Boolean bFound = false;
        for(int i = 0; i < list.size(); i++){
            BaseReference item = list.get(i);
            if (item.idfsBaseReference == def){
                // todo: check if it correct?
                ac.setListSelection(i);
                ac.setText(item.name);
                bFound = true;
                break;
            }
        }

        if (def != 0 && !bFound) {
            bEnabled = false;
        }
        ac.setEnabled(bEnabled);

        ac.setOnItemClickListener(listener);

        ac.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                // show all values
                ac.showDropDown();
                // hide soft keyboard
                getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
            }
        });
    }

    // for cursorloader
    public SimpleCursorAdapter LookupBind(final Spinner sp, final View v, final String field, final AdapterView.OnItemSelectedListener listener, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields){
        if (!EidssUtils.SetMandatoryAndInvisible(sp, fldName, mandatoryFields, invisibleFields, !sp.isEnabled()))
            return null;

        sp.setEnabled(false); // Spinners remain disabled while they don't have data

        // Data for spinner
        SimpleCursorAdapter arrayAdapter=new SimpleCursorAdapter(getActivity(), R.layout.custom_spinner, null, new String[]{field}, new int[]{android.R.id.text1}, 0);
        arrayAdapter.setDropDownViewResource(R.layout.custom_spinner_item);
        sp.setAdapter(arrayAdapter);

        if (listener != null)
            sp.setOnItemSelectedListener(listener);

        final ScrollView mScroller = (ScrollView)(v.findViewById(R.id.Scroll));
        sp.setOnTouchListener(new View.OnTouchListener() {
            public boolean onTouch(View arg0, MotionEvent arg1) {
                mScroller.requestChildFocus(sp, sp);
                return false;
            }
        });
        return arrayAdapter;
    }

    public void LookupBindReadonly(final int id, final View v, final Uri uri, final long def, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields){
        final TextView ed = (TextView)(v.findViewById(id));
        if (ed == null)
            throw new NoSuchElementException("TextView with id " + id + " not found.");

        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, true))
            return;

        // Data for TextView
        ed.setText(EidssUtils.getStringFromDB(getActivity(), uri, def));
    }

    public long getLongFromDB(final Uri uri, final long def, final String[] args, final String field) {
        long ret = 0;
        Uri uri_sel = ContentUris.withAppendedId(uri, def);
        Cursor c = getActivity().getContentResolver().query(uri_sel, null, null, args, null);
        try {
            c.moveToFirst();
            if(!c.isAfterLast())
                ret = c.getLong(c.getColumnIndex(field));
        }
        catch(Exception e){
            Log.d("getLongFromDB", e.getMessage());
        }
        c.close();
        return ret;
    }


    public void EditTextBind(final int id, final View v, final String def, final OnEditTextChangeListener listener, final boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields) {
        final EditText ed = (EditText) (v.findViewById(id));
        if (ed == null)
            throw new NoSuchElementException("EditText with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        EditTextBind(ed, def, listener, bEnabled);
    }

    public void EditTextBind(final View ed, final String def, final OnEditTextChangeListener listener, final boolean bEnabled, final Boolean isMandatory, final Boolean isInvisible) {
        EidssUtils.SetMandatoryAndInvisible(ed, isMandatory, isInvisible, !bEnabled);

        if(!isInvisible)
            EditTextBind((EditText)ed, def, listener, bEnabled);
    }

    public void EditTextBind(final EditText ed, final String def, final OnEditTextChangeListener listener, final boolean bEnabled)
    {
        ed.setText(def);
        ed.setEnabled(bEnabled);
        if (listener != null){
            ed.addTextChangedListener(new TextWatcher() {
                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after) {
                }

                @Override
                public void onTextChanged(CharSequence s, int start, int before, int count) {
                }

                @Override
                public void afterTextChanged(Editable s) {
                    listener.onEditTextChanged(s.toString());
                }
            });

            /*
            InputFilter[] f = ed.getEditableText().getFilters();
            int length = f == null ? 0 : f.length;
            InputFilter f1 = new InputFilter(){
                @Override
                public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend)  {
                    String text = dest.toString();
                    text = text.substring(0, dstart) + source.toString() + text.substring(dend, text.length());
                    listener.onEditTextChanged(text);
                    return source;
                }};
            InputFilter[] f2 = new InputFilter[length + 1];
            int i = 0;
            for(; i < length; i++){
                f2[i] = f[i];
            }
            f2[i] = f1;
            ed.getEditableText().setFilters(f2);
            */
        	/*ed.setOnFocusChangeListener(new OnFocusChangeListener(){
        		public void onFocusChange(View v, boolean hasFocus) {
        			if (!hasFocus)
        				listener.onEditTextChanged(ed.getText().toString());
        		}});*/
        }
    }

    public void BooleanBind(final int id, final View v, final Boolean def, final CompoundButton.OnCheckedChangeListener listener, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final CheckBox ed = (CheckBox)(v.findViewById(id));
        if (ed == null)
            throw new NoSuchElementException("CheckBox with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, !ed.isEnabled()))
            return;

        if (def != null)
            ed.setChecked(def);
        ed.setEnabled(true);
        if (listener != null){
            ed.setOnCheckedChangeListener(listener);
        }
    }

    public void BooleanBind(final View ed, final Boolean def, final CompoundButton.OnCheckedChangeListener listener, final Boolean isMandatory, final Boolean isInvisible)
    {
        EidssUtils.SetMandatoryAndInvisible(ed, isMandatory, isInvisible, false);

        if(!isInvisible) {
            if (def != null)
                ((CheckBox) ed).setChecked(def);
            ed.setEnabled(true);
            if (listener != null)
                ((CheckBox) ed).setOnCheckedChangeListener(listener);
        }
    }

    public void BooleanBindReadOnly(final int id, final View v, final Boolean def, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        final CheckBox ed = (CheckBox)(v.findViewById(id));
        if (ed == null)
            throw new NoSuchElementException("CheckBox with id " + id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, true))
            return;

        if (def != null)
            ed.setChecked(def);
        ed.setEnabled(false);
    }

    public void DateBind(final int edit_id, final View v, final int btn_clr, final View.OnClickListener act_edt, final View.OnClickListener act_clr, final Date def, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields) {
        final TextView ed = (TextView) (v.findViewById(edit_id));
        if (ed == null)
            throw new NoSuchElementException("TextView with id " + edit_id + " not found.");
        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, btn_clr == 0))
            return;

        DateBind(ed, v, btn_clr, act_edt, act_clr, def);
    }

    public void DateBind(final View ed, final View v, final int btn_clr, final View.OnClickListener act_edt, final View.OnClickListener act_clr, final Date def, final Boolean isMandatory, final Boolean isInvisible) {
        EidssUtils.SetMandatoryAndInvisible(ed, isMandatory, isInvisible, btn_clr == 0);

        if(!isInvisible)
            DateBind((TextView)ed, v, btn_clr, act_edt, act_clr, def);
    }

    private void DateBind(final TextView ed, final View v, final int btn_clr, final View.OnClickListener act_edt, final View.OnClickListener act_clr, final Date def)
    {
        DateHelpers.DisplayDate(ed, def);
        ed.setOnClickListener(act_edt);
        if (btn_clr != 0)
        {
            View button = v.findViewById(btn_clr);
            if (button != null){
                final Button bt = (Button)(button);
                bt.setOnClickListener(act_clr);
            }
        }
    }
}
