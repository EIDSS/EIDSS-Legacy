package com.bv.eidss;

import java.io.Serializable;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Formatter;
import java.util.List;


import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Species;

import com.bv.eidss.model.interfaces.ISetValue;
import com.bv.eidss.model.interfaces.ISpeciesParent;
import com.bv.eidss.utils.EidssUtils;

import android.content.Intent;
import android.content.res.Resources;
import android.support.v4.app.FragmentActivity;
import android.support.v4.content.ContextCompat;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;

public class SpeciesListAdapter extends ArrayAdapter<Species> {
    private final FragmentActivity context;
    private final ISpeciesParent mCase;
    private Menu menu;
    private SpeciesesFragment fragment;
    private ArrayList<BaseReference> _listSpeciesTypes = new ArrayList<>();

    public SpeciesListAdapter(SpeciesesFragment fragment, ISpeciesParent cs, ArrayList<BaseReference> listSpeciesTypes)
    {
        super(fragment.getActivity(), R.layout.species_layout, cs.getSpecies());
        this.context = fragment.getActivity();
        this.mCase = cs;
        this.fragment = fragment;
        this._listSpeciesTypes = listSpeciesTypes == null ? new ArrayList<BaseReference>() : listSpeciesTypes;
    }

    @Override
    public int getCount() {
        return mCase.getSpecies().size();
    }

    @Override
    public Species getItem(int position) {
        return mCase.getSpecies().get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    public int getCheckItemsCount()
    {
        int ret = 0;
        for(Integer i = 0; i < mCase.getSpecies().size(); i++) {
            if(mCase.getSpecies().get(i).isChecked())
            {
                ret++;
            }
        }
        return ret;
    }

    public void DeleteSpecies()
    {
        int[] poss = getCheckItemIds();
        for (int pos : poss)
            mCase.deleteSpecies(pos);
        mCase.setChanged();
        notifyDataSetChanged();
        updateMenuVisibility();
    }

    public boolean CheckCanDeleteSpecies(Object parent)
    {
        int[] poss = getCheckItemIds();
        for (int pos : poss){
            if (!mCase.canDeleteSpecies(pos, parent)) {
                return false;
            }
        }
        return true;
    }

    private int[] getCheckItemIds()
    {
        List<Integer> ret = new ArrayList<>();
        for(int i =  mCase.getSpecies().size()-1; i >=0; i--) {
            if(mCase.getSpecies().get(i).isChecked())
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
        final Species item = mCase.getSpecies().get(position);

        if (convertView == null){
            convertView = context.getLayoutInflater().inflate(  R.layout.list_item_layout, null);//android.R.layout.simple_list_item_multiple_choice
            holder = new ListItemViewHolder(convertView);

            holder.CheckBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                public void onCheckedChanged(CompoundButton pCompound, boolean arg1) {
                    boolean checked = pCompound.isChecked();
                    mCase.getSpecies().get(position).setChecked(checked);

                    int colorId = checked ? R.color.ListSelectedColor : R.color.TransparentColor;
                    CaseListAdapter.setParentListItemColor(pCompound, ContextCompat.getColor(context, colorId));
                    updateMenuVisibility();
                }
            });

            View.OnClickListener cl = new View.OnClickListener() {
                public void onClick(View v) {
                    Intent intent = new Intent(context, fragment.getClsForNewOrEdit());
                    Resources res = fragment.getResources();
                    Species species = getItem(position);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ITEM), species);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase.getSpeciesTypes(species.getSpeciesType()));
                    intent.putExtra(res.getString(R.string.EXTRA_ID_MODE), mCase.IsASSession() ? 0 : (mCase.IsLivestockCase() ? 1 : 2));
                    intent.putParcelableArrayListExtra(res.getString(R.string.EXTRA_ID_LIST), _listSpeciesTypes);
                    intent.putExtra("position", position);
                    fragment.startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_SPECIES));
                }
            };

            holder.CaseID.setOnClickListener(cl);
            holder.Status.setOnClickListener(cl);


            View.OnClickListener unSelectListener = new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    for (Species s:mCase.getSpecies()) {
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

        holder.CaseID.setText(EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, item.getSpeciesType()));
        holder.Status.setText(item.GetSummary(fragment.getResources()));

        boolean checked = item.isChecked() && !fragment.Readonly();
        holder.CheckBox.setChecked(checked);

        holder.CheckBox.setVisibility(fragment.Readonly() ? View.GONE : View.VISIBLE);
        holder.FFSummaryIcon.setVisibility(fragment.Readonly() ? View.GONE : View.VISIBLE);
        holder.CaseID.setEnabled(!fragment.Readonly());
        holder.Status.setEnabled(!fragment.Readonly());

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
        boolean showSelected = checkedCount > 0;

        if (menu != null) {
            MenuItem addButton = menu.findItem(R.id.CreateNew);
            if (addButton != null) {
                addButton.setVisible(!showSelected);
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
        View numberOfSelected = context.findViewById(R.id.numberOfSelected);
        if (numberOfSelected != null && numberOfSelected instanceof TextView) {
            TextView text = (TextView) numberOfSelected;
            int checkedResourceId = checkedCount == 1 ? R.string.SelectedOneCaseInList : R.string.SelectedManyCasesInList;
            text.setText((new Formatter()).format(context.getResources().getString(checkedResourceId), checkedCount).toString());
            text.setVisibility(showSelected ? View.VISIBLE : View.GONE);
        }

    }

    public void EditTextBind(final EditText ed, final int position, ISetValue<Species, Integer> set, final boolean bEnabled, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields)
    {
        if (!EidssUtils.SetMandatoryAndInvisible(ed, fldName, mandatoryFields, invisibleFields, !bEnabled))
            return;

        ed.setEnabled(bEnabled);

        ed.addTextChangedListener(new CustomTextWatcher(ed, mCase.getSpecies().get(position), set));
    }

    protected void DisplayDate(TextView ed, Date dt)
    {
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }



    private class CustomTextWatcher implements TextWatcher {

        private final EditText editText;
        private final Species species;
        private final ISetValue<Species, Integer> setValue;

        public CustomTextWatcher(final EditText e, final Species sp, ISetValue<Species, Integer> set)
        {
            editText = e;
            species = sp;
            setValue = set;
        }

        @Override
        public void afterTextChanged(Editable arg0) {
            if(arg0 != null){
                String text = arg0.toString();

                //input text - integer
                int val;

                if (text.compareTo("0") == 0){
                    editText.removeTextChangedListener(this);
                    editText.setText("");
                    editText.addTextChangedListener(this);
                }

                try
                {
                    val = Integer.parseInt(text);
                }
                catch(NumberFormatException e)
                {
                    val = 0;
                }
                setValue.set(val, species);
            }
        }

        @Override
        public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3) {
        }

        @Override
        public void onTextChanged(CharSequence arg0, int arg1, int arg2,int arg3) {
        }
    }
}
