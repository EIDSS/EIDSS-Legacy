package com.bv.eidss;

import java.util.ArrayList;
import java.util.Formatter;
import java.util.List;

import com.bv.eidss.model.interfaces.ICase;

import android.app.Activity;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.ActionBar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewParent;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

public abstract class CaseListAdapter<T extends ICase>  extends BaseAdapter{

    final private List<T> items;
    final protected Activity context;
    final private int maxItemsCount;
    final private Menu menu;

    public CaseListAdapter(Activity context, Menu menu, List<T> items, int maxCount)
    {
        super();
        this.context = context;
        this.menu = menu;
        this.items = items;
        this.maxItemsCount = maxCount;
    }

    protected abstract void dbCaseDelete();

    protected abstract void setHolderProperties(ListItemViewHolder holder, T item);

    protected abstract int getLayoutId();

    protected abstract int getActionBarIconId();

    protected abstract boolean isNew(T item);


    @Override
    public int getCount() {
        return Math.min(maxItemsCount, items.size());
    }

    @Override
    public Object getItem(int position) {
        return items.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    public int getCheckItemsCount()
    {
        int ret = 0;
        for(Integer i = 0; i < items.size(); i++) {
            if(items.get(i).isChecked())
            {
                ret++;
            }
        }
        return ret;
    }

    protected Long[] getCheckItemIds()
    {
        int[] ret = getCheckItems();
        Long[] result = new Long[ret.length];
        int i = 0;
        for(int pos:ret) {
            T hc = items.get(pos);
            result[i++] = hc.getId();
        }
        return result;
    }

    private int[] getCheckItems()
    {
        List<Integer> ret = new ArrayList<>();
        for(int i = items.size()-1; i >=0; i--) {
            if(items.get(i).isChecked())
            {
                ret.add(i);
            }
        }
        int[] result = new int[ret.size()];
        int i = 0;
        for (int l : ret)
            result[i++] = l;
        return result;
    }

    public void deleteCases()
    {
        dbCaseDelete();

        for(int pos:getCheckItems()) {
            items.remove(pos);
        }

        notifyDataSetChanged();
        updateMenuVisibility();
    }


    public boolean isNewChecked(){
        int[] ret = getCheckItems();
        int i = 0;
        for(int pos:ret) {
            T hc = items.get(pos);
            if (isNew(hc))  return true;
        }
        return false;
    }


    @Override
    public View getView(final int position, View convertView, final ViewGroup parent) {
        ListItemViewHolder holder;
        if (convertView == null)
        {
            convertView = context.getLayoutInflater().inflate(getLayoutId(), null);
            holder = new ListItemViewHolder(convertView);
            convertView.setTag(holder);
        }
        else{
            holder = (ListItemViewHolder) convertView.getTag();
        }

        final T item = items.get(position);
        int colorId = item.isChecked() ? R.color.ListSelectedColor : R.color.TransparentColor;
        convertView.setBackgroundColor(ContextCompat.getColor(context, colorId));

        View.OnClickListener clickListener = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ((ListView) parent).performItemClick(((ListView) parent).getAdapter().getView(position, null, null), position, position);

            }
        };
        View.OnLongClickListener longClickListener = new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                boolean checked = !item.isChecked();
                item.setChecked(checked);

                int colorId = checked ? R.color.ListSelectedColor : R.color.TransparentColor;
                setParentListItemColor(v, ContextCompat.getColor(context, colorId));

                updateMenuVisibility();

                return true;
            }
        };
        View.OnClickListener unSelectListener = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                for (ICase c:items) {
                    c.setChecked(false);
                }
                updateMenuVisibility();
                setChildListItemsColor(v.getRootView(),ContextCompat.getColor(context, R.color.TransparentColor));
            }
        };

        setOnClickListener(convertView, clickListener);
        setOnLongClickListener(convertView, longClickListener);

        ImageButton unSelectButton = (ImageButton)context.findViewById(R.id.unSelect);
        if (unSelectButton !=null){
            unSelectButton.setOnClickListener(unSelectListener);
        }

        setHolderProperties(holder, item);

        return convertView;
    }

    public void updateMenuVisibility() {
        if (context!=null && context instanceof EidssBaseActivity) {
            EidssBaseActivity act = (EidssBaseActivity) context;
            boolean drawerOpen = act.isDrawerOpen();
            int checkedCount = getCheckItemsCount();
            boolean showListMenuItems = !(checkedCount > 0 || drawerOpen);
            boolean showSelected = checkedCount > 0 && !drawerOpen;

            if (menu !=null) {
                MenuItem addButton = menu.findItem(R.id.Add);
                if (addButton != null) {
                    addButton.setVisible(showListMenuItems);
                }
                MenuItem refreshButton = menu.findItem(R.id.Refresh);
                if (refreshButton != null) {
                    refreshButton.setVisible(showListMenuItems);
                }
                MenuItem removeButton = menu.findItem(R.id.Remove);
                if (removeButton != null) {
                    removeButton.setVisible(showSelected);
                }
            }

            View filter = context.findViewById(R.id.spinner_list_filter);
            if (filter != null) {
                filter.setVisibility(showListMenuItems ? View.VISIBLE : View.GONE);
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

            final ActionBar ab = act.getSupportActionBar();
            if(ab != null)
                ab.setIcon(showSelected ? android.R.color.transparent : getActionBarIconId());
        }
    }

    public void setOnClickListener(View v, View.OnClickListener clickListener) {
        v.setOnClickListener(clickListener);
        if (v instanceof ViewGroup)
        {
            ViewGroup group = (ViewGroup) v;
            for (int i = 0; i < group.getChildCount(); i++) {
                View child = group.getChildAt(i);
                setOnClickListener(child, clickListener);
            }
        }
    }

    public void setOnLongClickListener(View v, View.OnLongClickListener longClickListener) {
        v.setOnLongClickListener(longClickListener);
        if (v instanceof ViewGroup)
        {
            ViewGroup group = (ViewGroup) v;
            for (int i = 0; i < group.getChildCount(); i++) {
                View child = group.getChildAt(i);
                setOnLongClickListener(child, longClickListener);
            }
        }
    }
    public static void setChildListItemsColor(View control, int color) {
        if (control != null) {
            if (control.getTag() instanceof ListItemViewHolder) {
                control.setBackgroundColor(color);
            }
            else if (control instanceof ViewGroup) {
                ViewGroup group = (ViewGroup) control;
                for (int i = 0; i < group.getChildCount(); i++) {
                    View child = group.getChildAt(i);
                    setChildListItemsColor(child, color);
                }
            }
        }
    }
    public static Boolean setParentListItemColor(View control, int color)
    {
        View v = getParentListItem(control);
        if (v !=null) {
            v.setBackgroundColor(color);
            return true;
        }
        return false;
    }

    public static View getParentListItem(View control)
    {
        if (control == null)        {
            return null;
        }
        if (control.getTag() instanceof ListItemViewHolder) {
            return control;
        }
        ViewParent parent = control.getParent();
        while (parent != null){
            if (parent instanceof View) {
                View v = (View) parent;
                if (v.getTag() instanceof ListItemViewHolder) {
                    return v;
                }
            }
            parent = parent.getParent();
        }
        return null;
    }
}
