package com.bv.eidss.data;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v4.util.SimpleArrayMap;

import com.bv.eidss.model.ActivityParameter;

/**
 * Created by avdovin on 26.04.2016.
 */
public class EidssDatabaseFF {
    private static final String select_sql_ff_activity_parameters =
            "SELECT * FROM FFActivityParameter WHERE idfObservation = ?";

    public static SimpleArrayMap<String, ActivityParameter> FFActivityParametersSelect(SQLiteDatabase db, long idfObservation)
    {
        SimpleArrayMap <String, ActivityParameter> ret = new SimpleArrayMap<>();
        if (idfObservation == 0) return ret;

        Cursor cursor = db.rawQuery(select_sql_ff_activity_parameters, new String[]{String.valueOf(idfObservation)});
        Boolean rSp = cursor.moveToFirst();
        while(rSp) {
            ActivityParameter ap = ActivityParameter.FromCursor(cursor);
            ret.put(ap.GetKey(), ap);
            rSp = cursor.moveToNext();
        }
        cursor.close();
        return ret;
    }
}
