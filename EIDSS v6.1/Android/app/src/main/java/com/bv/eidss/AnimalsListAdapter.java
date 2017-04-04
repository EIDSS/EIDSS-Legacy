package com.bv.eidss;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import com.bv.eidss.model.Animal;
import com.bv.eidss.model.VetCase;

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

public class AnimalsListAdapter extends ArrayAdapter<Animal> {
    private final FragmentActivity context;
    private final VetCase mCase;
    private Menu menu;
    private AnimalsFragment fragment;

    public AnimalsListAdapter(AnimalsFragment fragment, VetCase cs)
    {
        super(fragment.getActivity(), R.layout.list_item_layout, cs.animals);
        this.context = fragment.getActivity();
        this.mCase = cs;
        this.fragment = fragment;
    }

    @Override
    public int getCount() {
        return mCase.animals.size();
    }

    @Override
    public Animal getItem(int position) {
        return mCase.animals.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    public int getCheckItemsCount()
    {
        int ret = 0;
        for(Integer i = 0; i < mCase.animals.size(); i++) {
            if(mCase.animals.get(i).isChecked())
            {
                ret++;
            }
        }
        return ret;
    }

    public void DeleteAnimals()
    {
        int[] poss = getCheckItemIds();
        for (int pos : poss)
            mCase.animals.remove(pos);
        mCase.setChanged();
        notifyDataSetChanged();
        updateMenuVisibility();
    }

    private int[] getCheckItemIds()
    {
        List<Integer> ret = new ArrayList<>();
        for(int i =  mCase.animals.size()-1; i >=0; i--) {
            if(mCase.animals.get(i).isChecked())
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
        final Animal item = mCase.animals.get(position);

        if (convertView == null){
            convertView = context.getLayoutInflater().inflate(  R.layout.list_item_layout, null);
            holder = new ListItemViewHolder(convertView);

            holder.CheckBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                public void onCheckedChanged(CompoundButton pCompound, boolean arg1) {
                    boolean checked = pCompound.isChecked();
                    mCase.animals.get(position).setChecked(checked);

                    int colorId = checked ? R.color.ListSelectedColor : R.color.TransparentColor;
                    CaseListAdapter.setParentListItemColor(pCompound, ContextCompat.getColor(context, colorId));
                    updateMenuVisibility();
                }
            });

            View.OnClickListener cl = new View.OnClickListener() {
                public void onClick(View v) {
                    Intent intent = new Intent(context, AnimalActivity.class);
                    Resources res = fragment.getResources();
                    Animal animal = getItem(position);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ITEM), animal);
                    intent.putExtra(res.getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase.getSpecies(context));
                    intent.putExtra("position", position);
                    fragment.startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_ANIMAL));
                }
            };

            holder.CaseID.setOnClickListener(cl);
            holder.Status.setOnClickListener(cl);


            View.OnClickListener unSelectListener = new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    for (Animal s:mCase.animals) {
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

        holder.CaseID.setText(item.getAnimalCode());
        holder.Status.setText(item.GetSummary(context));

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
        boolean showSelected = getCheckItemsCount() > 0 && !fragment.Readonly();

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
