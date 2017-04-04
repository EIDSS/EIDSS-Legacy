package com.bv.eidss;
import java.util.ArrayList;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class CustomDrawerAdapter extends BaseAdapter {
    public static final int TYPE_TITLE = 0;
    public static final int TYPE_HEADER = 1;
    public static final int TYPE_ITEM = 2;
    public static final int TYPE_ITEM_FIRST = 3;
    private static final int TYPE_MAX_COUNT = TYPE_ITEM_FIRST + 1;

    private ArrayList<DrawerItem> mData = new ArrayList<>();
    private LayoutInflater mInflater;

    public CustomDrawerAdapter(Context context) {
        mInflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

    public void addItem(final DrawerItem item) {
        mData.add(item);
        //notifyDataSetChanged();
    }

    @Override
    public int getItemViewType(int position) {
        return mData.get(position).getItemType();
        //return mSeparatorsSet.contains(position) ? TYPE_TITLE : TYPE_ITEM;
    }

    @Override
    public int getViewTypeCount() {
        return TYPE_MAX_COUNT;
    }

    @Override
    public int getCount() {
        return mData.size();
    }

    @Override
    public DrawerItem getItem(int position) {
        return mData.get(position);
    }

    @Override
    public long getItemId(int position) {
        return mData.get(position).getItemID();
    }

    @Override
	public View getView(int position, View convertView, ViewGroup parent) {
        int type = getItemViewType(position);
        System.out.println("getView " + position + " " + convertView + " type = " + type);

        TextView drawerItem;
        if (convertView == null) {
            switch (type) {
                case TYPE_TITLE:
                    convertView = mInflater.inflate(R.layout.custom_drawer_title, null);
                    break;
                case TYPE_HEADER:
                    convertView = mInflater.inflate(R.layout.custom_drawer_subtitle, null);
                    break;
                case TYPE_ITEM_FIRST:
                    convertView = mInflater.inflate(R.layout.custom_drawer_item_first, null);
                    break;
                case TYPE_ITEM:
                    convertView = mInflater.inflate(R.layout.custom_drawer_item, null);
                    break;
            }
            drawerItem = (TextView)convertView.findViewById(R.id.drawerTitle);
            convertView.setTag(drawerItem);
        } else {
            drawerItem = (TextView)convertView.getTag();
        }


        switch (type) {
            case TYPE_TITLE:
                convertView.setEnabled(false);
                break;
            case TYPE_HEADER:
                drawerItem.setText(mData.get(position).getTitle());
                convertView.setEnabled(false);
                break;
            case TYPE_ITEM_FIRST:
            case TYPE_ITEM:
                drawerItem.setText(mData.get(position).getTitle());
                drawerItem.setCompoundDrawablesWithIntrinsicBounds(mData.get(position).getImgResID(), 0, 0, 0);
                break;
        }
        return convertView;
    }


}