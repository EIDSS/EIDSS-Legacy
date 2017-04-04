package com.bv.eidss;

import android.content.Intent;
import android.content.res.Resources;
import android.support.v4.app.FragmentActivity;
import android.support.v4.content.ContextCompat;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.ImageButton;

import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSession;

import java.util.ArrayList;
import java.util.List;

public class ASDiseasesListAdapter extends ArrayAdapter<ASDisease> {
    private final FragmentActivity context;
    private final ASSession mCase;
    private Menu menu;
    private ASDiseasesFragment fragment;

    public ASDiseasesListAdapter(ASDiseasesFragment fragment, ASSession cs)
    {
        super(fragment.getActivity(), R.layout.list_item_layout, cs.asDiseases);
        this.context = fragment.getActivity();
        this.mCase = cs;
        this.fragment = fragment;
    }

    @Override
    public int getCount() {
        return mCase.asDiseases.size();
    }

    @Override
    public ASDisease getItem(int position) {
        return mCase.asDiseases.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    public int getCheckItemsCount()
    {
        int ret = 0;
        for(Integer i = 0; i < mCase.asDiseases.size(); i++) {
            if(mCase.asDiseases.get(i).isChecked())
            {
                ret++;
            }
        }
        return ret;
    }

    public void DeleteASDiseases()
    {
        int[] poss = getCheckItemIds();
        for (int pos : poss)
            mCase.asDiseases.remove(pos);
        mCase.setChanged();
        notifyDataSetChanged();
        updateMenuVisibility();
    }

    public boolean CheckCanDeleteASDiseases()
    {
        int[] poss = getCheckItemIds();
        for (int pos : poss){
            ASDisease asd = mCase.asDiseases.get(pos);

            boolean isUniqueSpeciesType = true;
            if (asd.getSpeciesType() != 0) {
                for (Integer i = 0; i < mCase.asDiseases.size(); i++) {
                    if (i != pos && mCase.asDiseases.get(i).getSpeciesType() == asd.getSpeciesType()) {
                        isUniqueSpeciesType = false;
                        break;
                    }
                }
            }

            if (isUniqueSpeciesType) {
                for (Integer i = 0; i < mCase.farms.size(); i++) {
                    for (Integer j = 0; i < mCase.farms.get(i).species.size(); j++) {
                        if (mCase.farms.get(i).species.get(j).getSpeciesType() == asd.getSpeciesType()) {
                            return false;
                        }
                    }
                }
            }

        }
        return true;
    }

    private int[] getCheckItemIds()
    {
        List<Integer> ret = new ArrayList<>();
        for(int i =  mCase.asDiseases.size()-1; i >=0; i--) {
            if(mCase.asDiseases.get(i).isChecked())
            {
                ret.add(i);
            }
        }
        int[] result = new int[ret.size()];
        int i = 0;
        for (Integer l : ret)
            result[i++] = l;
        return result;
    }

    @Override
    public View getView(final int position, View convertView, final ViewGroup parent) {
        final ListItemViewHolder holder;
        final ASDisease item = mCase.asDiseases.get(position);

        if (convertView == null){
            convertView = context.getLayoutInflater().inflate(  R.layout.as_disease_item_layout, null);
            holder = new ListItemViewHolder(convertView);

            holder.CheckBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                public void onCheckedChanged(CompoundButton pCompound, boolean arg1) {
                    boolean checked = pCompound.isChecked();
                    mCase.asDiseases.get(position).setChecked(checked);

                    int colorId = checked ? R.color.ListSelectedColor : R.color.TransparentColor;
                    CaseListAdapter.setParentListItemColor(pCompound, ContextCompat.getColor(context, colorId));
                    updateMenuVisibility();
                }
            });

            View.OnClickListener cl = new View.OnClickListener() {
                public void onClick(View v) {
                    Intent intent = new Intent(fragment.getActivity(), ASDiseaseActivity.class);
                    Resources res = fragment.getResources();
                    ASDisease asdisease = getItem(position);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ITEM), asdisease);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ASSESSION), mCase);
                    intent.putExtra("position", position);
                    fragment.startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_ASDISEASE));
                }
            };

            holder.CaseID.setOnClickListener(cl);


            View.OnClickListener unSelectListener = new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    for (ASDisease s:mCase.asDiseases) {
                        s.setChecked(false);
                    }
                    updateMenuVisibility();
                    unCheckAllCheckBoxes(v.getRootView());
                }
            };
            ImageButton unSelectButton = (ImageButton)context.findViewById(R.id.unSelect);
            if (unSelectButton !=null){
                unSelectButton.setOnClickListener(unSelectListener);
            }
            convertView.setTag(holder);
        }
        else{
            holder = (ListItemViewHolder) convertView.getTag();
        }

        holder.CaseID.setText(item.GetSummary(context));

        boolean checked = item.isChecked() && !fragment.Readonly();
        holder.CheckBox.setChecked(checked);
        holder.CheckBox.setVisibility(fragment.Readonly() ? View.GONE : View.VISIBLE);
        holder.FFSummaryIcon.setVisibility(fragment.Readonly() ? View.GONE : View.VISIBLE);
        holder.CaseID.setEnabled(!fragment.Readonly());

        int colorId = checked ? R.color.ListSelectedColor : R.color.TransparentColor;
        convertView.setBackgroundColor(ContextCompat.getColor(context, colorId));

        return convertView;
    }

    public static void unCheckAllCheckBoxes(View control) {
        if (control != null) {
            if (control.getTag() instanceof ListItemViewHolder) {
                ListItemViewHolder holder = (ListItemViewHolder) control.getTag();
                holder.CheckBox.setChecked(false);
            }
            else if (control instanceof ViewGroup) {
                ViewGroup group = (ViewGroup) control;
                for (int i = 0; i < group.getChildCount(); i++) {
                    unCheckAllCheckBoxes(group.getChildAt(i));
                }
            }
        }
    }

    public void updateMenuVisibility(Menu adapterMenu) {
        this.menu = adapterMenu;
        updateMenuVisibility();
    }

    private void updateMenuVisibility() {
        int checkedCount = getCheckItemsCount();
        boolean showSelected = checkedCount > 0 && !fragment.Readonly();

        if (menu != null) {
            MenuItem addButton = menu.findItem(R.id.CreateNew);
            if (addButton != null) {
                addButton.setVisible(!showSelected && !fragment.Readonly());
            }
            MenuItem removeButton = menu.findItem(R.id.Remove);
            if (removeButton != null) {
                removeButton.setVisible(showSelected);
            }
        }
        View unSelectButton = context.findViewById(R.id.unSelect);
        if (unSelectButton != null) {
            unSelectButton.setVisibility(showSelected ? View.VISIBLE : View.GONE);
        }
        View separator = context.findViewById(R.id.toolbarSeparator);
        if (separator != null) {
            separator.setVisibility(showSelected ? View.VISIBLE : View.GONE);
        }

    }
}
