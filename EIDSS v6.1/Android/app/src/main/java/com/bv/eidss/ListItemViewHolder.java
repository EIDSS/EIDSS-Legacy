package com.bv.eidss;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

public class ListItemViewHolder{

    public TextView FarmAddress;
    public TextView FamilyName;
    public TextView Diagnosis;
    public TextView CaseID;
    public TextView StartEndDate;
    public TextView SessionStatus;
    public TextView CampaignName;
    public ImageView Image;
    public TextView Status;
    public TextView DateOfBirth;
    public TextView CreatedDate;
    public EditText LastSynError;

    public Spinner SpeciesType;
    public Button StartOfSignsDateClearButton;
    public TextView StartOfSignsDate;
    public EditText TotalAnimalQty;
    public EditText DeadAnimalQty;
    public EditText SickAnimalQty;
    public CheckBox CheckBox;

    public TextView FFSummaryText;
    //public LinearLayout FFDetailsButton;
    public TextView FFSummaryTextCaption;
    public ImageView FFSummaryIcon;

    public ListItemViewHolder(View view) {
        FarmAddress = (TextView) view.findViewById(R.id.FarmAddress);
        FamilyName = (TextView) view.findViewById(R.id.FamilyName);
        Diagnosis = (TextView) view.findViewById(R.id.Diagnosis);
        CaseID = (TextView) view.findViewById(R.id.CaseID);
        StartEndDate = (TextView) view.findViewById(R.id.StartEndDate);
        SessionStatus = (TextView) view.findViewById(R.id.SessionStatus);
        CampaignName = (TextView) view.findViewById(R.id.CampaignName);
        Image = (ImageView) view.findViewById(R.id.CaseTypeImg);
        Status = (TextView) view.findViewById(R.id.Status);
        DateOfBirth = (TextView) view.findViewById(R.id.DateofBirth);
        CreatedDate = (TextView) view.findViewById(R.id.CreatedDate);
        LastSynError = (EditText) view.findViewById(R.id.LastSynError);
        if(LastSynError != null) LastSynError.setHorizontallyScrolling(false);

        SpeciesType = (Spinner) view .findViewById(R.id.idfsSpeciesType);
        StartOfSignsDateClearButton = (Button) view .findViewById(R.id.datStartOfSignsDateClearButton);
        StartOfSignsDate = (TextView) view .findViewById(R.id.datStartOfSignsDate);
        TotalAnimalQty = (EditText) view .findViewById(R.id.intTotalAnimalQty);
        DeadAnimalQty = (EditText) view .findViewById(R.id.intDeadAnimalQty);
        SickAnimalQty = (EditText) view .findViewById(R.id.intSickAnimalQty);
        CheckBox = (CheckBox) view .findViewById(R.id.text1);
        FFSummaryText = (TextView) view .findViewById(R.id.ffSummaryText);
        FFSummaryTextCaption = (TextView) view .findViewById(R.id.ffSummaryTextCaption);
        //FFDetailsButton = (LinearLayout) view .findViewById(R.id.FFDetailsButton);
        FFSummaryIcon = (ImageView) view.findViewById(R.id.ffSummaryIcon);
    }
}
