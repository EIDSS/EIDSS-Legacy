package com.bv.eidss;

import java.io.File;
import java.util.ArrayList;

import android.content.Intent;
import android.os.Bundle;
import android.os.Environment;
import android.support.v7.widget.PopupMenu;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

public class FileBrowser extends EidssBaseBlockTimeoutActivity implements EidssAndroidHelpers.DialogDoneTextListener {
	
	private int workMode; //save/load
	private String mask; //*.txt
	private String fixedFilename; //
	private File rootDir; //

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);        
        setContentView(R.layout.file_browser);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Bundle extras = getIntent().getExtras();
        
        workMode = extras.getInt(getResources().getString(R.string.EXTRA_ID_MODE), -1);
        mask = extras.getString("mask");
        if (mask == null) mask = "";
        fixedFilename = "";
		if (mask.length() > 0)
		{
			boolean hasFixedFilename = !mask.contains("*.");
			if (hasFixedFilename){
				fixedFilename = mask;
				final EditText edSelectedFile = (EditText)this.findViewById(R.id.idSelectedFile);
				edSelectedFile.setText(mask);
				edSelectedFile.setEnabled(false);
			}
			else
			{
				int pos = mask.lastIndexOf(".");
				if (pos > 0) mask = mask.substring(pos);								
			}			
		}
        
        if (workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_LOAD)) {
        	setTitle(R.string.TitleLoadRefFile);
        }
        else if (workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_LIST)){
            setTitle(R.string.TitleLoadListFile);
        }
        else if (workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE)){
        	setTitle(R.string.TitleSaveFile);
        }
        else {
        	finish();
        }
        
        lstExplorer = (ListView)this.findViewById(R.id.lstExplorer);
        lstExplorer.setOnItemClickListener(OnItemClickListenerHandler);
        lstExplorer.setOnItemLongClickListener(OnItemLongClickListenerHandler);
        
        ShowRootLevel();

        // hide soft keyboard
        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
    }
	
	private ListView lstExplorer;
	
	private static final int IDM_NEWFOLDER = 1;
	private static final int IDM_RENAME = 2;


	@Override
	public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.filesystem_menu, menu);
		return super.onCreateOptionsMenu(menu);
	}

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        menu.findItem(R.id.Save).setVisible(workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE));
        menu.findItem(R.id.Load).setVisible(workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_LOAD));
        return super.onPrepareOptionsMenu(menu);
    }

	private File currentDir;
	private File selectedFile;
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){

		switch(item.getItemId()){
            case android.R.id.home:
                goUp();
                return true;
            case R.id.Save:
                if (selectedFile != null)
                {
                    if (selectedFile.isDirectory()){
                        EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.MsgWrongFileSelected);
                        return false;
                    }
                    else
                        goFinish();
                }
                else
                {
                    if (fixedFilename.length() == 0)
                    {
                        final EditText edSelectedFile = (EditText)this.findViewById(R.id.idSelectedFile);
                        String filename = edSelectedFile.getText().toString();
                        if (filename.length() == 0){
                            EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.MsgWrongFileSelected);
                            return false;
                        }
                        if (mask.length() > 0) filename += mask;
                        Intent intent = new Intent();
                        intent.putExtra(getResources().getString(R.string.EXTRA_ID_FILENAME), currentDir.getAbsolutePath() + "/" + filename);
                        setResult(RESULT_OK, intent);
                        finish();
                    }
                    else
                    {
                        Intent intent = new Intent();
                        intent.putExtra(getResources().getString(R.string.EXTRA_ID_FILENAME), currentDir.getAbsolutePath() + "/" + fixedFilename);
                        setResult(RESULT_OK, intent);
                        finish();
                    }
                }
                break;
            case R.id.Load:
                if (selectedFile != null)
                {
                    if (selectedFile.isDirectory()){
                        EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.MsgWrongFileSelected);
                        return false;
                    }
                    else
                        goFinish();

                }
                else
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.MsgMustSelectFile);
                }
                break;
            case R.id.Folder:
                final View menuItemView = findViewById(item.getItemId());
                PopupMenu popupMenu = new PopupMenu(this, menuItemView);//, R.style.PopupMenu
                if (workMode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE))
                    popupMenu.getMenu().add(0, IDM_NEWFOLDER, 1, R.string.NewFolder);
                popupMenu.getMenu().add(0, IDM_RENAME, 2, R.string.RenameFolder);
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener()
                {
                    @Override
                    public boolean onMenuItemClick(MenuItem item)
                    {
                        onFolderMenuItemClick(item);
                        return true;
                    }
                });
                popupMenu.show();
                return true;
		}
		
		return false;
	}

    public boolean onFolderMenuItemClick(android.view.MenuItem item) {
        switch(item.getItemId()){
            case IDM_NEWFOLDER:
                if (currentDir != null) {
                    EidssAndroidHelpers.AlertInputDialog.Show(getSupportFragmentManager(), IDM_NEWFOLDER, R.string.TitleNewFolder);
                }
                break;
            case IDM_RENAME:
                if (selectedFile != null){
                    EidssAndroidHelpers.AlertInputDialog.Rename(getSupportFragmentManager(), IDM_RENAME, R.string.RenameFolder, selectedFile.getName());
                }
                break;
            default:
                return super.onContextItemSelected(item);
        }
        return true;

    }

    @Override
    public void onDone(int idDialog, boolean isPositive, String text) {
        switch (idDialog) {
            case IDM_NEWFOLDER:
                if(isPositive) {
                    File newDir = new File(currentDir.getAbsolutePath() + "/" + text);
                    if (newDir.mkdir())
                        ShowFileChildren(currentDir);
                    else
                        EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.ErrorNewFolder);
                }
                break;
            case IDM_RENAME:
                if(isPositive) {
                    String absolutePath = selectedFile.getAbsolutePath();
                    String filePath = absolutePath.substring(0,absolutePath.lastIndexOf(File.separator));
                    File newDir = new File(filePath + "/" + text);
                    if (selectedFile.renameTo(newDir)) {
                        selectedFile = newDir;
                        ShowFileChildren(currentDir);
                        ShowSelectedFilename();
                    }
                    else
                        EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.ErrorRenameFolder);
                }
                break;
        }    }

	private void ShowRootLevel(){
		/*
		files.add(Environment.getRootDirectory());
		files.add(Environment.getDataDirectory());
		files.add(Environment.getDownloadCacheDirectory());
		*/
		
		if (Environment.getExternalStorageState().equalsIgnoreCase(Environment.MEDIA_MOUNTED)){
			//File sdRoot = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS);
			rootDir = Environment.getExternalStorageDirectory();
			ShowFileChildren(rootDir);			
			currentDir = rootDir;
		}
	}	
	
	private void ShowFileChildren(File file){
		try{
			ArrayList<File> allObjectsList = new ArrayList<>();
			ArrayList<File> dirsList = new ArrayList<>();
			ArrayList<File> filesList = new ArrayList<>();
			if (!file.getAbsolutePath().equals(rootDir.getAbsolutePath()))
			{
				allObjectsList.add(new File(getResources().getString(R.string.FILE_TO_UPPER_DIR)));
				/*
				File fakeFile = new File(file.getAbsolutePath() + "/" + FILE_TO_UPPER_DIR);
				File par = fakeFile.getParentFile();
				allObjectsList.add(fakeFile);
				*/			
			}
			//
			File[] objects = file.listFiles();
			
			for(File f: objects){
				if (f.isFile())
				{
					if (fixedFilename.length() == 0)
					{
						if ((mask.length() > 0) && f.getName().contains(mask)) filesList.add(f);
					}
					else
					{
						if ((fixedFilename.length() > 0) && f.getName().equals(fixedFilename))	filesList.add(f);
					}					
				}
				else if (f.isDirectory())
				{
					dirsList.add(f);
				}					
			}
			allObjectsList.addAll(dirsList);
			allObjectsList.addAll(filesList);
			
			lstExplorer.setAdapter(new FileAdapter(this, allObjectsList));
		}
		catch(Exception e){
			//TODO 
		}
	}	
	
	private OnItemClickListener OnItemClickListenerHandler = new OnItemClickListener(){
		@Override
		public void onItemClick(AdapterView<?> lv, View v, int position, long id) {
			
			File file = (File)lv.getItemAtPosition(position);
			if (file.getPath().equals(getResources().getString(R.string.FILE_TO_UPPER_DIR))){
				if (!currentDir.getAbsolutePath().equals(rootDir.getAbsolutePath()))
				{	
					File fParent = currentDir.getParentFile(); //file
					if (fParent != null) ShowFileChildren(fParent); else ShowRootLevel();
					selectedFile = null;
					currentDir = fParent;
					ShowSelectedFilename();
				}
			}
			else if (file.isDirectory()) 
			{
				selectedFile = null;
				currentDir = file;
				ShowFileChildren(currentDir);				
			}
			else if (file.isFile()) 
			{
				selectedFile = file;
                goFinish();
                return;
			}
			ShowSelectedFilename();
		}
	};
	
	private OnItemLongClickListener OnItemLongClickListenerHandler = new OnItemLongClickListener(){
		@Override
		public boolean onItemLongClick(AdapterView<?> lv, View v, int position, long id) {
			selectedFile = (File)lv.getItemAtPosition(position);
			//ShowSelectedFilename();
            goFinish();
			return true;
		}
	};

	private void ShowSelectedFilename(){
		final EditText edSelectedFile = (EditText)this.findViewById(R.id.idSelectedFile);
		final TextView edCurrentDir = (TextView)this.findViewById(R.id.idCurrentDir);
		
		if (selectedFile != null) 
		{
			edSelectedFile.setText(selectedFile.getName()); 
		}
		else
		{
			edSelectedFile.setText(fixedFilename);
		}
		if (currentDir != null) edCurrentDir.setText(currentDir.getAbsolutePath()); else edCurrentDir.setText("");
	}

    @Override
	public void onBackPressed() {
        goBack();
	}

    private void goUp()
    {
        Intent intent = new Intent();
        if (currentDir != null)
            intent.putExtra(getResources().getString(R.string.EXTRA_ID_FILENAME), "");
        setResult(RESULT_CANCELED, intent);
        finish();
     }

    private void goBack()
    {
        if (currentDir == null)
            return;
        File fParent = currentDir.getParentFile();

        if (!currentDir.getAbsolutePath().equals(rootDir.getAbsolutePath()))
        {
            if (fParent != null) {
                ShowFileChildren(fParent);
                currentDir = fParent;
            }
            else {
                ShowRootLevel();
                currentDir = rootDir;
            }
        }
        else {
            goUp();
        }
        ShowSelectedFilename();
    }

    private void goFinish(){
        if (selectedFile.isFile())
        {
            Intent intent = new Intent();
            intent.putExtra(getResources().getString(R.string.EXTRA_ID_FILENAME), selectedFile.getAbsolutePath());
            setResult(RESULT_OK, intent);
            finish();
        }
    }

}
