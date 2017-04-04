package com.bv.eidss;

import java.io.File;
import java.util.Formatter;
import java.util.List;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class FileAdapter extends BaseAdapter {

	private List<File> items;
    private Activity context;
    
    public FileAdapter(Activity context, List<File> items)
    {
    	super();
        this.context = context;
        this.items = items;
    }
    
/*    public FileAdapter(Activity context, File[] items)
    {
    	super();    	
        this.context = context;
        ArrayList<File> files = new ArrayList<File>();        
        for(int i = 0; i < items.length; i++){
        	files.add(items[i]);
        }        
        this.items = files;
    }*/
	
	@Override
	public int getCount() {
		return items.size();
	}

	@Override
	public Object getItem(int position) {
		return items.get(position);
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		File file = items.get(position);
        View view;
        if (convertView != null) view = convertView;
        else view = context.getLayoutInflater().inflate(R.layout.file_layout, null);
        
        //
        TextView tvFilename = (TextView)view.findViewById(R.id.tvFileName);
        ImageView img = (ImageView)view.findViewById(R.id.imgIcon);
        boolean isFakeFile = file.getPath().equals(context.getResources().getString(R.string.FILE_TO_UPPER_DIR));
        if (isFakeFile)
        {
        	tvFilename.setText(context.getResources().getString(R.string.FILE_TO_UPPER_DIR));
        	img.setImageDrawable(null);
        }
        else
        {        	
        	if (file.isDirectory()){
        		img.setImageResource(R.drawable.eidss_ic_dir);
        		Formatter f = new Formatter();
        		tvFilename.setText(f.format("[%s]", file.getName()).toString());
        		f.close();
        	}
        	else
        	{
        		img.setImageResource(R.drawable.eidss_ic_file);
        		tvFilename.setText(file.getName());
        	}
        }
        
        return view;
	}
}
