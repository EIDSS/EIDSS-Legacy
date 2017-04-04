package com.bv.eidss.generated;

import android.content.Context;
import android.database.Cursor;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.view.View;
import android.widget.CompoundButton;
import android.widget.AdapterView;

import com.bv.eidss.EidssBaseBindableFragment;
import com.bv.eidss.HumanCaseFragment;
import com.bv.eidss.VetCaseFragment;
import com.bv.eidss.AnimalFragment;
import com.bv.eidss.ASDiseaseFragment;
import com.bv.eidss.ASSampleFragment;
import com.bv.eidss.FarmFragment;
import com.bv.eidss.HumanCaseSampleFragment;
import com.bv.eidss.VetCaseSampleFragment;
import com.bv.eidss.ASSessionFragment;
import com.bv.eidss.R;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.ASSession;
import android.content.Intent;
import android.widget.Spinner;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.Animal;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;

public class ASSession_binding
{
    public static final int NO_ACTION_ID = 1030;
    public static final int datStartDate_DialogID = 1031;
    public static final int datEndDate_DialogID = 1032;


    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final ASSession mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        fragment.EditTextBind(R.id.strMonitoringSessionID, v, mCase.getMonitoringSessionID(), null, false, null, mandatoryFields, invisibleFields);
        
        
        fragment.DateBind(R.id.datStartDate, v, R.id.datStartDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datStartDate_DialogID, null, mCase.getStartDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setStartDate(null);
                    DateHelpers.DisplayDate(R.id.datStartDate, v, mCase.getStartDate());
                }
            }, mCase.getStartDate(), ASSession.eidss_StartDate, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datEndDate, v, R.id.datEndDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datEndDate_DialogID, null, mCase.getEndDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setEndDate(null);
                    DateHelpers.DisplayDate(R.id.datEndDate, v, mCase.getEndDate());
                }
            }, mCase.getEndDate(), ASSession.eidss_EndDate, mandatoryFields, invisibleFields);
        
        
        fragment.LookupBindReadonly(R.id.idfsCampaignType, v, ReferenciesProvider.CONTENT_URI, mCase.getCampaignType(), ASSession.eidss_CampaignType, mandatoryFields, invisibleFields);
        
        }
        if (page == 1)
        {
        
        
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final ASSession mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final ASSession mCase)
    {
        switch (id)
        {
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
            default:
                break;
        }
    }

}
