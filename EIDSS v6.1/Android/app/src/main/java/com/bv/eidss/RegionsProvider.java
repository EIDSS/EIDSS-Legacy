package com.bv.eidss;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;

import com.bv.eidss.data.EidssDatabase;

public class RegionsProvider  extends ContentProvider{

    static final String PROVIDER_NAME = "com.bv.eidss.regionsprovider";
    static final String URL = "content://" + PROVIDER_NAME + "/regions";
    public static final Uri CONTENT_URI = Uri.parse(URL);
    public static final String NAME = "name";

    static final int REGIONS = 1;
    static final int REGION_ID = 2;

    static final UriMatcher uriMatcher;
    static{
        uriMatcher = new UriMatcher(UriMatcher.NO_MATCH);
        uriMatcher.addURI(PROVIDER_NAME, "regions", REGIONS);
        uriMatcher.addURI(PROVIDER_NAME, "regions/#", REGION_ID);
    }

        private SQLiteDatabase db;

        @Override
        public boolean onCreate() {
            /*EidssDatabase mDb = new EidssDatabase(getContext());
            db = mDb.getReadableDatabase();
            return (db == null)? false:true;*/
            return true;
        }

        @Override
        public Uri insert(Uri uri, ContentValues values) {
            throw new SQLException("Failed to add a record into " + uri);
        }

        @Override
        public Cursor query(Uri uri, String[] projection, String selection,
                            String[] selectionArgs, String sortOrder) {
            if (db == null) {
                EidssDatabase mDb = new EidssDatabase(getContext());
                db = mDb.getReadableDatabase();
            }
            switch (uriMatcher.match(uri)) {
                case REGIONS:
                    return db.rawQuery(EidssDatabase.select_sql_regions, selectionArgs);
                case REGION_ID:
                    return db.rawQuery(EidssDatabase.select_sql_region, selectionArgs);
                default:
                    throw new IllegalArgumentException("Wrong URI: " + uri);
            }
        }

        @Override
        public int delete(Uri uri, String selection, String[] selectionArgs) {
            throw new IllegalArgumentException("Unknown URI " + uri);
        }

        @Override
        public int update(Uri uri, ContentValues values, String selection,
                          String[] selectionArgs) {
            throw new IllegalArgumentException("Unknown URI " + uri );
        }

        @Override
        public String getType(Uri uri) {
            throw new IllegalArgumentException("Unsupported URI: " + uri);
        }
}
