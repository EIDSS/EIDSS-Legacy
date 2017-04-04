package com.bv.eidss.data;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.model.Species;
import com.bv.eidss.model.interfaces.ISpeciesParent;

import java.util.List;

/**
 * Created by avdovin on 26.04.2016.
 */
public class EidssDatabaseSpecies {
    public static void UpdateList(SQLiteDatabase db, List<Species> species, long parentId){
        for (Species sp:species) {
            sp.setParent(parentId);
            if(sp.getId() == 0)
                sp.setId(db.insert("Species", null, sp.ContentValues()));
            else if(sp.getChanged())
                db.update("Species", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
        }

        // delete everything that is not in vc.species
        SQLiteStatement s;
        s = db.compileStatement("select count(*) from Species where idParent=" + String.valueOf(parentId));
        long nSp = s.simpleQueryForLong();

        if (nSp > species.size())	{
            String ids = "";
            for (Species sp:species) {
                if (sp.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(sp.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("Species", "idParent= "+String.valueOf(parentId)+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("Species", "idParent= "+String.valueOf(parentId), null);
        }
    }

    public static void SpeciesSelect(SQLiteDatabase db, List<ISpeciesParent> ret, long id)
    {
        Cursor cursor;
        if(id == 0)
            cursor = db.query("Species", null, null, null, null, null, "id");
        else
            cursor = db.query("Species", null, "idParent=" + id, null, null, null, "id");
        Boolean rSp = cursor.moveToFirst();
        while(rSp)
        {
            Species sp = Species.FromCursor(cursor);
            if (sp != null)
            {
                for(ISpeciesParent vc : ret)
                {
                    if(sp.getParent() == vc.getId()){
                        sp.FFPresenterCs.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, sp.getObservation());
                        vc.getSpecies().add(sp);
                        break;
                    }
                }
            }
            rSp = cursor.moveToNext();
        }
        cursor.close();
    }

}
