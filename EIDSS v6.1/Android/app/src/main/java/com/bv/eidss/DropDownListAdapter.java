package com.bv.eidss;

import java.util.ArrayList;

import android.content.Context;
import android.content.res.Resources;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.TextView;
import android.view.View.OnClickListener;

public class DropDownListAdapter extends BaseAdapter {

	private ArrayList<String> mListItems;
	private LayoutInflater mInflater;
	private TextView mSelectedItems;
	private static int intSelected;
	private ViewHolder holder;
	private boolean[] checkSelected;	// store select/unselect information about the values in the list

	public int getSelected() {
		return intSelected;
	}
	private void setSelected(int selection){
		intSelected = selection;
		for (int i = 0; i < checkSelected.length; i++) {
			checkSelected[i] = (intSelected & (1 << i)) > 0;
		}
	}


	public DropDownListAdapter(Context context, final CharSequence[] items,
							   TextView tv, int selection) {
		mListItems = new ArrayList<>();
		for(CharSequence it : items)
			mListItems.add(it.toString());
		mInflater = LayoutInflater.from(context);
		mSelectedItems = tv;
		checkSelected = new boolean[items.length];

		setSelected(selection);
	}

	@Override
	public int getCount() {
		return mListItems.size();
	}

	@Override
	public Object getItem(int arg0) {
		return null;
	}

	@Override
	public long getItemId(int arg0) {
		return 0;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		if (convertView == null) {
			convertView = mInflater.inflate(R.layout.list_popup_item, null);
			holder = new ViewHolder();
			holder.tv = (TextView) convertView.findViewById(R.id.SelectOption);
			holder.chkbox = (CheckBox) convertView.findViewById(R.id.checkbox);
			int id = Resources.getSystem().getIdentifier("btn_check_holo_dark", "drawable", "android");
			holder.chkbox.setButtonDrawable(id);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}

		holder.tv.setText(mListItems.get(position));

		final int position1 = position;
		
		//whenever the checkbox is clicked the selected values textview is updated with new selected values
		holder.chkbox.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				setText(position1);
			}
		});

		if(checkSelected[position])
			holder.chkbox.setChecked(true);
		else
			holder.chkbox.setChecked(false);	 
		return convertView;
	}


	/*
	 * Function which updates the selected values display and information(checkSelected[])
	 * */
	private void setText(int position1){
		if (!checkSelected[position1]) {
			checkSelected[position1] = true;
			intSelected += (1 << position1);
		} else {
			checkSelected[position1] = false;
			intSelected -= (1 << position1);
		}

		getSelectionText();
	}

    private String getSelectionText() {
		String strSelected = "";
        for (int i = 0; i < checkSelected.length; i++) {
            if (checkSelected[i]) {
                if(strSelected.length() > 0)
                    strSelected += ", ";
                strSelected += mListItems.get(i);
            }
        }
        mSelectedItems.setText(strSelected);
        return strSelected;
    }

    public String putSelected(int selection) {
		setSelected(selection);
        return getSelectionText();
    }

	private class ViewHolder {
		TextView tv;
		CheckBox chkbox;
	}
}
