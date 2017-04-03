package com.bv.eidss;

import java.io.File;
import java.util.ArrayList;

import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Environment;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

public class FileBrowser extends EidssBaseBlockTimeoutActivity {
	
	private int workMode; //save/load
	private String mask; //*.txt, например
	private String fixedFilename; //если имя (без пути) задано, то можно задавать только его
	private File rootDir; //каталог, который считается корневым
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);        
        setContentView(R.layout.file_browser);        
        Bundle extras = getIntent().getExtras();
        
        workMode = extras.getInt(EXTRA_ID_MODE, -1);
        mask = extras.getString("mask");
        if (mask == null) mask = "";
        fixedFilename = "";
		if (mask.length() > 0)
		{
			boolean hasFixedFilename = mask.indexOf("*.") < 0;
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
        
        if (workMode == FILE_BROWSER_MODE_LOAD)
        {
        	setTitle(R.string.TitleLoadFile);
        }
        else if (workMode == FILE_BROWSER_MODE_SAVE)
        {
        	setTitle(R.string.TitleSaveFile);
        }
        else
        {
        	//если неверно передан режим
        	finish();
        }
        
        lstExplorer = (ListView)this.findViewById(R.id.lstExplorer);
        lstExplorer.setOnItemClickListener(OnItemClickListenerHandler);
        lstExplorer.setOnItemLongClickListener(OnItemLongClickListenerHandler);
        
        ShowRootLevel();
    }
	
	private ListView lstExplorer;
	
	private static final int IDM_NEWFOLDER = 1;
	private static final int IDM_RENAME = 2;
	private static final int IDM_SAVE = 3; //TODO всё-таки Save или OK?
	private static final int IDM_CANCEL = 4;
	
	private static final int MSG_WRONG_FILE_SELECTED = 5; 
	private static final int MSG_MUST_SELECT_FILE = 6;
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu){
		if (workMode == FILE_BROWSER_MODE_SAVE)
        {
			menu.add(Menu.NONE, IDM_NEWFOLDER, Menu.NONE, R.string.NewFolder);
		}
		menu.add(Menu.NONE, IDM_RENAME, Menu.NONE, R.string.RenameFolder);
		if (workMode == FILE_BROWSER_MODE_LOAD)
        {
			menu.add(Menu.NONE, IDM_SAVE, Menu.NONE, R.string.Load);
        }
		else if (workMode == FILE_BROWSER_MODE_SAVE)
        {
			menu.add(Menu.NONE, IDM_SAVE, Menu.NONE, R.string.Save);
        }		
		menu.add(Menu.NONE, IDM_CANCEL, Menu.NONE, R.string.Cancel);
				
		return super.onCreateOptionsMenu(menu);
	}
	
	//каталог, в котором мы сейчас находимся
	private File currentDir;
	//файл, выбранный пользователем
	private File selectedFile;
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		Intent intent = new Intent();
		
		switch(item.getItemId()){
		case IDM_SAVE:
			if (selectedFile != null)
			{
				if (selectedFile.isDirectory()){
					//показываем сообщение, что нужно выбрать именно файл (маской отсекаются невалидные файлы)
					showDialog(MSG_WRONG_FILE_SELECTED);
					return false;
				}
				else if (selectedFile.isFile())
				{
					//если файл прошёл по маске, то его можно без доп.проверок выбирать
					intent.putExtra(EXTRA_ID_FILENAME, selectedFile.getAbsolutePath().toString());
					setResult(RESULT_OK, intent);
					finish();				
				}
			}
			else 
			{
				if (workMode == FILE_BROWSER_MODE_SAVE)
				{
					//новый файл. Так можно только в режиме сохранения.
					if (fixedFilename.length() == 0)
					{						
						final EditText edSelectedFile = (EditText)this.findViewById(R.id.idSelectedFile);
						String filename = edSelectedFile.getText().toString();
						if (filename.length() == 0){
							showDialog(MSG_WRONG_FILE_SELECTED);
							return false;
						}
						if (mask.length() > 0) filename += mask;				
						intent.putExtra(EXTRA_ID_FILENAME, currentDir.getAbsolutePath() + "/" + filename);
						setResult(RESULT_OK, intent);
						finish();
					}
					else
					{
						intent.putExtra(EXTRA_ID_FILENAME, currentDir.getAbsolutePath() + "/" + fixedFilename);
						setResult(RESULT_OK, intent);
						finish();
					}
				}
				else
				{
					showDialog(MSG_MUST_SELECT_FILE);
				}
			}
			break;
		case IDM_CANCEL:
			if (currentDir != null) intent.putExtra(EXTRA_ID_FILENAME, "");
			setResult(RESULT_CANCELED, intent);
			finish();
			break;
		default:
			if (currentDir != null) showDialog(item.getItemId());
			break;
		}
		
		return false;
	}
	
	//показывает перечень каталогов верхнего уровня
	private void ShowRootLevel(){		
		/*
		files.add(Environment.getRootDirectory());
		files.add(Environment.getDataDirectory());
		files.add(Environment.getDownloadCacheDirectory());
		*/
		
		//TODO закрывать диалог с информационным сообщением, если не подключена карта
		if (Environment.getExternalStorageState().equalsIgnoreCase(Environment.MEDIA_MOUNTED)){
			//File sdRoot = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS);
			rootDir = Environment.getExternalStorageDirectory();
			ShowFileChildren(rootDir);			
			currentDir = rootDir;
		}
	}	
	
	//показывает перечень файлов и каталогов, которые являются дочерними к указанному
	private void ShowFileChildren(File file){		
		try{
			ArrayList<File> allObjectsList = new ArrayList<File>();
			//отбираем отдельно каталоги, отдельно файлы			
			ArrayList<File> dirsList = new ArrayList<File>();			
			ArrayList<File> filesList = new ArrayList<File>();
			//фиктивный файл для подъема на уровень выше
			//если это не есть каталог высшего уровня
			if (!file.getAbsolutePath().equals(rootDir.getAbsolutePath())) 
			{
				allObjectsList.add(new File(FILE_TO_UPPER_DIR));
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
			//выводим сначала каталоги, потом файлы а-ля Total Commander
			allObjectsList.addAll(dirsList);
			allObjectsList.addAll(filesList);
			
			lstExplorer.setAdapter(new FileAdapter(this, allObjectsList));
		}
		catch(Exception e){
			//TODO 
		}
	}	
	
	//выбор папки или файла
	private OnItemClickListener OnItemClickListenerHandler = new OnItemClickListener(){
		@Override
		public void onItemClick(AdapterView<?> lv, View v, int position, long id) {
			
			//если выбрана папка, то переходим к её потомкам
			//если это спецфайл, то на уровень выше
			File file = (File)lv.getItemAtPosition(position);
			if (file.getPath().equals(EidssBaseActivity.FILE_TO_UPPER_DIR)){
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
			}
			ShowSelectedFilename();
		}
	};
	
	//выбор папки или файла
	private OnItemLongClickListener OnItemLongClickListenerHandler = new OnItemLongClickListener(){
		@Override
		public boolean onItemLongClick(AdapterView<?> lv, View v, int position, long id) {
			selectedFile = (File)lv.getItemAtPosition(position);
			ShowSelectedFilename();
			return true;
		}
	};
	
	@Override
    protected Dialog onCreateDialog(int id) {
		//String title = getResources().getString(mCase.getCase() == 0 ? R.string.ConfirmToDeleteNewCase : R.string.ConfirmToDeleteSynCase);
		String title = "";
		LayoutInflater inflater = this.getLayoutInflater();
		View view = inflater.inflate(R.layout.input_text, null);
		final EditText edName = (EditText)view.findViewById(R.id.edText);
		
        switch (id)
        {
	        case IDM_NEWFOLDER:	        	
				title = getResources().getString(R.string.TitleNewFolder);				
				return EidssAndroidHelpers.InputTextDialog(this, title, view, new DialogInterface.OnClickListener() {							
					@Override
					public void onClick(DialogInterface dialog, int which) {							
							File newDir = new File(currentDir.getAbsolutePath() + "/" + edName.getText().toString());
							newDir.mkdir();
							ShowFileChildren(currentDir);
					}}	, null); 
				
	        case IDM_RENAME:
	        	//!пока переименовываем только папки
	        	//TODO определиться, можно ли переименовывать файлы. Их потом пользователь может потерять, особенно если расширение поменяет.
	        	
	        	if (selectedFile != null)
	        	{
	        		title = getResources().getString(R.string.RenameFolder);
	        		edName.setText(selectedFile.getName());
					
					return EidssAndroidHelpers.InputTextDialog(this, title, view, new DialogInterface.OnClickListener() {							
						@Override
						public void onClick(DialogInterface dialog, int which) {
							String absolutePath = selectedFile.getAbsolutePath();
							String filePath = absolutePath.substring(0,absolutePath.lastIndexOf(File.separator));
							File newDir = new File(filePath + "/" + edName.getText().toString());							
							selectedFile.renameTo(newDir);
							selectedFile = newDir;
							ShowFileChildren(currentDir);
							ShowSelectedFilename();
						}}	, null);
	        	}				
                break;
	        case MSG_WRONG_FILE_SELECTED:
	        	return EidssAndroidHelpers.MessageDialog(this, getResources().getString(R.string.MsgWrongFileSelected), new DialogInterface.OnClickListener() {							
					@Override
					public void onClick(DialogInterface dialog, int which) {}});
	        case MSG_MUST_SELECT_FILE:
	        	return EidssAndroidHelpers.MessageDialog(this, getResources().getString(R.string.MsgMustSelectFile), new DialogInterface.OnClickListener() {							
					@Override
					public void onClick(DialogInterface dialog, int which) {}});
	        	
        }
        return null;
    }	
	
	//отображение и редактирования выбранного файла и полного пути к нему
	private void ShowSelectedFilename(){		
		final EditText edSelectedFile = (EditText)this.findViewById(R.id.idSelectedFile);
		final TextView edCurrentDir = (TextView)this.findViewById(R.id.idCurrentDir);
		
		if (selectedFile != null) 
		{
			edSelectedFile.setText(selectedFile.getName()); 
		}
		else
		{
			//либо пустой, либо жестко заданный
			edSelectedFile.setText(fixedFilename);
		}
		if (currentDir != null) edCurrentDir.setText(currentDir.getAbsolutePath()); else edCurrentDir.setText("");
	}	
	
	@Override
	public void onBackPressed() {
		//если находимся не в корневом каталоге, то поднимаемся на уровень выше
		//если в корневом, то закрываем каталог по Cancel
		if (currentDir == null) return;	
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
			Intent intent = new Intent();
			intent.putExtra("filename", "");
			setResult(RESULT_CANCELED, intent);
			finish();
		}
		ShowSelectedFilename();
	}
}
