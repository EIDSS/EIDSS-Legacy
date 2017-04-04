package com.bv.eidss.data;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.interfaces.ISpeciesParent;

import java.util.List;

/**
 * Created by avdovin on 26.04.2016.
 */
public class EidssDatabaseASSamples {
    private static final String select_sql_as_samples =
            "SELECT * " +
                    "FROM ASSample " +
                    "WHERE idParent = ? " +
                    "ORDER BY id";

    public static void ASSamplesSelect(SQLiteDatabase db, final List<ASSession> ret, final long id)
    {
        Cursor cursor;
        if(id == 0) {
            cursor = db.query("ASSample", null, null, null, null, null, "id");
            Boolean rSp = cursor.moveToFirst();
            while(rSp)
            {
                ASSample it = ASSample.FromCursor(cursor);
                if (it != null)
                {
                    for(ASSession vc : ret)
                    {
                        if (vc.getMonitoringSession() == 0){
                            if (it.getParent() == vc.getId()) {
                                vc.asSamples.add(it);
                                break;
                            }
                        } else {
                            if (it.getMonitoringSession() == vc.getMonitoringSession()) {
                                vc.asSamples.add(it);
                                break;
                            }
                        }
                    }
                }
                rSp = cursor.moveToNext();
            }
            cursor.close();
        }
        else {
            for(ASSession vc : ret)
            {
                cursor = db.rawQuery(select_sql_as_samples, new String [] {String.valueOf(vc.getId())} );
                Boolean rSp = cursor.moveToFirst();
                while(rSp)
                {
                    ASSample it = ASSample.FromCursor(cursor);
                    vc.asSamples.add(it);
                    rSp = cursor.moveToNext();
                }
                cursor.close();
            }
        }
    }

    public static void UpdateList(SQLiteDatabase db, List<ASSample> assamples, long parentId){
        for (ASSample sp:assamples) {
            sp.setParent(parentId);
            if(sp.getId() == 0)
                sp.setId(db.insert("ASSample", null, sp.ContentValues()));
            else if(sp.getChanged())
                db.update("ASSample", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
        }

        // delete everything that is not in vc.assamples
        SQLiteStatement s;
        s = db.compileStatement("select count(*) from ASSample where idParent=" + String.valueOf(parentId));
        long nSp = s.simpleQueryForLong();

        if (nSp > assamples.size())	{
            String ids = "";
            for (ASSample sp:assamples) {
                if (sp.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(sp.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("ASSample", "idParent= "+String.valueOf(parentId)+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("ASSample", "idParent= "+String.valueOf(parentId), null);
        }
    }

}
