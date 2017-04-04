package com.bv.eidss.utils;

import android.content.Context;
import android.widget.ArrayAdapter;
import android.widget.Filter;

import java.util.List;

/**
 * Created by avdovin on 28.04.2016.
 */
public class ArrayAdapterNoFilter<T> extends ArrayAdapter<T> {
    private Filter filter = new NoFilter();
    public List<T> items;

    public ArrayAdapterNoFilter(Context context, int resource, List<T> objects) {
        super(context, resource, objects);
        items = objects;
    }

    @Override
    public Filter getFilter() {
        return filter;
    }

    private class NoFilter extends Filter {

        @Override
        protected FilterResults performFiltering(CharSequence constraint) {
            FilterResults result = new FilterResults();
            result.values = items;
            result.count = items.size();
            return result;
        }

        @Override
        protected void publishResults(CharSequence constraint, FilterResults results) {
            notifyDataSetChanged();
        }
    }
}
