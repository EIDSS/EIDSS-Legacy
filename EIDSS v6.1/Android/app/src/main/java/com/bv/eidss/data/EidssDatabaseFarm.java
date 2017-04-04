package com.bv.eidss.data;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;

import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.interfaces.ISpeciesParent;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by avdovin on 05.05.2016.
 */
public class EidssDatabaseFarm {
    private static final String insert_sql_farm =
            "insert into Farm(intRowStatus,idfFarm,blnIsRoot,idfRootFarm,strFarmCode,strFarmName,strOwnerLastName,strOwnerFirstName,strOwnerMiddleName,idfsRegion,idfsRayon,idfsSettlement,strStreetName,strBuilding,strHouse,strApartment,strPostCode,strPhone,strFax,strEmail,dblLongitude,dblLatitude) values (?,?,1,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    private static final String update_sql_farm =
            "update Farm set intRowStatus=?,idfFarm=?,blnIsRoot=1,idfRootFarm=?,strFarmCode=?,strFarmName=?,strOwnerLastName=?,strOwnerFirstName=?,strOwnerMiddleName=?,idfsRegion=?,idfsRayon=?,idfsSettlement=?,strStreetName=?,strBuilding=?,strHouse=?,strApartment=?,strPostCode=?,strPhone=?,strFax=?,strEmail=?,dblLongitude=?,dblLatitude=? where id=?";
    private static final String update_sql_farm_root =
            "update Farm set strFarmName=?,strOwnerLastName=?,strOwnerFirstName=?,strOwnerMiddleName=?,idfsRegion=?,idfsRayon=?,idfsSettlement=?,strStreetName=?,strBuilding=?,strHouse=?,strApartment=?,strPostCode=?,strPhone=?,strFax=?,strEmail=?,dblLongitude=?,dblLatitude=? where blnIsRoot=1 and idfFarm=?";

    private static final String select_sql_farms =
            "SELECT * " +
                "FROM Farm " +
                "WHERE ifnull(blnIsRoot,0)=0 and idParent = ? " +
                "ORDER BY id";

    public static void updateRootFarm(SQLiteDatabase db, Farm f){
        SQLiteStatement stmt = db.compileStatement(update_sql_farm_root);
        stmt.clearBindings();
        if (f.getFarmName() != null)
            stmt.bindString(1, f.getFarmName());
        if (f.getOwnerLastName() != null)
            stmt.bindString(2, f.getOwnerLastName());
        if (f.getOwnerFirstName() != null)
            stmt.bindString(3, f.getOwnerFirstName());
        if (f.getOwnerMiddleName() != null)
            stmt.bindString(4, f.getOwnerMiddleName());
        stmt.bindLong(5, f.getRegion());
        stmt.bindLong(6, f.getRayon());
        stmt.bindLong(7, f.getSettlement());
        if (f.getStreetName() != null)
            stmt.bindString(8, f.getStreetName());
        if (f.getBuilding() != null)
            stmt.bindString(9, f.getBuilding());
        if (f.getHouse() != null)
            stmt.bindString(10, f.getHouse());
        if (f.getApartment() != null)
            stmt.bindString(11, f.getApartment());
        if (f.getPostCode() != null)
            stmt.bindString(12, f.getPostCode());
        if (f.getPhone() != null)
            stmt.bindString(13, f.getPhone());
        if (f.getFax() != null)
            stmt.bindString(14, f.getFax());
        if (f.getEmail() != null)
            stmt.bindString(15, f.getEmail());
        stmt.bindDouble(16, f.getLongitude());
        stmt.bindDouble(17, f.getLatitude());
        stmt.bindLong(18, f.getRootFarm());
        stmt.execute();
        stmt.close();
    }
    public static void updateRootFarm(SQLiteDatabase db, VetCase f){
        SQLiteStatement stmt = db.compileStatement(update_sql_farm_root);
        stmt.clearBindings();
        if (f.getFarmName() != null)
            stmt.bindString(1, f.getFarmName());
        if (f.getOwnerLastName() != null)
            stmt.bindString(2, f.getOwnerLastName());
        if (f.getOwnerFirstName() != null)
            stmt.bindString(3, f.getOwnerFirstName());
        if (f.getOwnerMiddleName() != null)
            stmt.bindString(4, f.getOwnerMiddleName());
        stmt.bindLong(5, f.getRegion());
        stmt.bindLong(6, f.getRayon());
        stmt.bindLong(7, f.getSettlement());
        if (f.getStreetName() != null)
            stmt.bindString(8, f.getStreetName());
        if (f.getBuilding() != null)
            stmt.bindString(9, f.getBuilding());
        if (f.getHouse() != null)
            stmt.bindString(10, f.getHouse());
        if (f.getApartment() != null)
            stmt.bindString(11, f.getApartment());
        if (f.getPostCode() != null)
            stmt.bindString(12, f.getPostCode());
        if (f.getPhone() != null)
            stmt.bindString(13, f.getPhone());
        //if (f.getFax() != null)
        //    stmt.bindString(14, f.getFax());
        //if (f.getEmail() != null)
        //    stmt.bindString(15, f.getEmail());
        stmt.bindDouble(16, f.getLongitude());
        stmt.bindDouble(17, f.getLatitude());
        stmt.bindLong(18, f.getRootFarm());
        stmt.execute();
        stmt.close();
    }

    public static long insertRootFarm(SQLiteDatabase db, Farm f){
        SQLiteStatement stmt = db.compileStatement(insert_sql_farm);
        stmt.clearBindings();
        stmt.bindLong(1, 0);
        stmt.bindLong(2, f.getRootFarm());
        stmt.bindLong(3, 0);
        if (f.getFarmCode() != null)
            stmt.bindString(4, f.getFarmCode());
        if (f.getFarmName() != null)
            stmt.bindString(5, f.getFarmName());
        if (f.getOwnerLastName() != null)
            stmt.bindString(6, f.getOwnerLastName());
        if (f.getOwnerFirstName() != null)
            stmt.bindString(7, f.getOwnerFirstName());
        if (f.getOwnerMiddleName() != null)
            stmt.bindString(8, f.getOwnerMiddleName());
        stmt.bindLong(9, f.getRegion());
        stmt.bindLong(10, f.getRayon());
        stmt.bindLong(11, f.getSettlement());
        if (f.getStreetName() != null)
            stmt.bindString(12, f.getStreetName());
        if (f.getBuilding() != null)
            stmt.bindString(13, f.getBuilding());
        if (f.getHouse() != null)
            stmt.bindString(14, f.getHouse());
        if (f.getApartment() != null)
            stmt.bindString(15, f.getApartment());
        if (f.getPostCode() != null)
            stmt.bindString(16, f.getPostCode());
        if (f.getPhone() != null)
            stmt.bindString(17, f.getPhone());
        if (f.getFax() != null)
            stmt.bindString(18, f.getFax());
        if (f.getEmail() != null)
            stmt.bindString(19, f.getEmail());
        stmt.bindDouble(20, f.getLongitude());
        stmt.bindDouble(21, f.getLatitude());
        long ret = stmt.executeInsert();
        stmt.close();
        return ret;
    }
    public static long insertRootFarm(SQLiteDatabase db, VetCase f){
        SQLiteStatement stmt = db.compileStatement(insert_sql_farm);
        stmt.clearBindings();
        stmt.bindLong(1, 0);
        stmt.bindLong(2, f.getRootFarm());
        stmt.bindLong(3, 0);
        if (f.getFarmCode() != null)
            stmt.bindString(4, f.getFarmCode());
        if (f.getFarmName() != null)
            stmt.bindString(5, f.getFarmName());
        if (f.getOwnerLastName() != null)
            stmt.bindString(6, f.getOwnerLastName());
        if (f.getOwnerFirstName() != null)
            stmt.bindString(7, f.getOwnerFirstName());
        if (f.getOwnerMiddleName() != null)
            stmt.bindString(8, f.getOwnerMiddleName());
        stmt.bindLong(9, f.getRegion());
        stmt.bindLong(10, f.getRayon());
        stmt.bindLong(11, f.getSettlement());
        if (f.getStreetName() != null)
            stmt.bindString(12, f.getStreetName());
        if (f.getBuilding() != null)
            stmt.bindString(13, f.getBuilding());
        if (f.getHouse() != null)
            stmt.bindString(14, f.getHouse());
        if (f.getApartment() != null)
            stmt.bindString(15, f.getApartment());
        if (f.getPostCode() != null)
            stmt.bindString(16, f.getPostCode());
        if (f.getPhone() != null)
            stmt.bindString(17, f.getPhone());
        //if (f.getFax() != null)
        //    stmt.bindString(18, f.getFax());
        //if (f.getEmail() != null)
        //    stmt.bindString(19, f.getEmail());
        stmt.bindDouble(20, f.getLongitude());
        stmt.bindDouble(21, f.getLatitude());
        long ret = stmt.executeInsert();
        stmt.close();
        return ret;
    }

    public static void LoadFarms(SQLiteDatabase db, ArrayList<Farm> farms){
        ArrayList<Farm> farmsToInsert = new ArrayList<>();
        ArrayList<Farm> farmsToDelete = new ArrayList<>();
        ArrayList<Farm> farmsToUpdate = new ArrayList<>();

        for (int i = 0; i < farms.size(); i++) {
            farmsToInsert.add(farms.get(i));
        }
        //boolean bInsertEmpty = true;
        Cursor cursor = db.query("Farm", null, "blnIsRoot=1", null, null, null, null);
        Boolean r = cursor.moveToFirst();
        while(r)
        {
            Farm cmp = Farm.FromCursor(cursor);
            //if (cmp.getFarm() == 0){
            //    bInsertEmpty = false;
            //}
            boolean bFound = false;
            for (int i = 0; i < farms.size(); i++) {
                if (cmp.getFarm() == farms.get(i).getFarm()){
                    bFound = true;
                    farmsToUpdate.add(farms.get(i));
                    farmsToInsert.remove(farms.get(i));
                }
            }
            if (!bFound && cmp.getFarm() > 0){
                farmsToDelete.add(cmp);
            }
            r = cursor.moveToNext();
        }
        cursor.close();

        /*
        1 intRowStatus,
        2 idfFarm,
          blnIsRoot,
        3 idfRootFarm,
        4 strFarmCode,
        5 strFarmName,
        6 strOwnerLastName,
        7 strOwnerFirstName,
        8 strOwnerMiddleName,
        9 idfsRegion,
        10 idfsRayon,
        11 idfsSettlement,
        12 strStreetName,
        13 strBuilding,
        14 strHouse,
        15 strApartment,
        16 strPostCode,
        17 strPhone,
        18 strFax,
        19 strEmail,
        20 dblLongitude,
        21 dblLatitude
        */
        SQLiteStatement stmt = db.compileStatement(insert_sql_farm);
        /*if (bInsertEmpty) {
            stmt.clearBindings();
            stmt.bindLong(1, 0);
            stmt.bindLong(2, 0);
            stmt.bindLong(3, 0);
            stmt.bindString(4, "");
            stmt.bindString(5, "");
            stmt.bindString(6, "");
            stmt.bindString(7, "");
            stmt.bindString(8, "");
            stmt.bindLong(9, 0);
            stmt.bindLong(10, 0);
            stmt.bindLong(11, 0);
            stmt.bindString(12, "");
            stmt.bindString(13, "");
            stmt.bindString(14, "");
            stmt.bindString(15, "");
            stmt.bindString(16, "");
            stmt.bindString(17, "");
            stmt.bindString(18, "");
            stmt.bindString(19, "");
            stmt.bindDouble(20, 0);
            stmt.bindDouble(21, 0);
            stmt.executeInsert();
        }*/
        for (int i = 0; i < farmsToInsert.size(); i++) {
            Farm f = farmsToInsert.get(i);
            stmt.clearBindings();
            stmt.bindLong(1, 0);
            stmt.bindLong(2, f.getFarm());
            stmt.bindLong(3, f.getRootFarm());
            if (f.getFarmCode() != null)
                stmt.bindString(4, f.getFarmCode());
            if (f.getFarmName() != null)
                stmt.bindString(5, f.getFarmName());
            if (f.getOwnerLastName() != null)
                stmt.bindString(6, f.getOwnerLastName());
            if (f.getOwnerFirstName() != null)
                stmt.bindString(7, f.getOwnerFirstName());
            if (f.getOwnerMiddleName() != null)
                stmt.bindString(8, f.getOwnerMiddleName());
            stmt.bindLong(9, f.getRegion());
            stmt.bindLong(10, f.getRayon());
            stmt.bindLong(11, f.getSettlement());
            if (f.getStreetName() != null)
                stmt.bindString(12, f.getStreetName());
            if (f.getBuilding() != null)
                stmt.bindString(13, f.getBuilding());
            if (f.getHouse() != null)
                stmt.bindString(14, f.getHouse());
            if (f.getApartment() != null)
                stmt.bindString(15, f.getApartment());
            if (f.getPostCode() != null)
                stmt.bindString(16, f.getPostCode());
            if (f.getPhone() != null)
                stmt.bindString(17, f.getPhone());
            if (f.getFax() != null)
                stmt.bindString(18, f.getFax());
            if (f.getEmail() != null)
                stmt.bindString(19, f.getEmail());
            stmt.bindDouble(20, f.getLongitude());
            stmt.bindDouble(21, f.getLatitude());
            stmt.executeInsert();
        }
        stmt.close();

        stmt = db.compileStatement(update_sql_farm);
        for (int i = 0; i < farmsToDelete.size(); i++) {
            Farm f = farmsToDelete.get(i);
            stmt.clearBindings();
            stmt.bindLong(1, 1);
            stmt.bindLong(2, f.getFarm());
            stmt.bindLong(3, f.getRootFarm());
            if (f.getFarmCode() != null)
                stmt.bindString(4, f.getFarmCode());
            if (f.getFarmName() != null)
                stmt.bindString(5, f.getFarmName());
            if (f.getOwnerLastName() != null)
                stmt.bindString(6, f.getOwnerLastName());
            if (f.getOwnerFirstName() != null)
                stmt.bindString(7, f.getOwnerFirstName());
            if (f.getOwnerMiddleName() != null)
                stmt.bindString(8, f.getOwnerMiddleName());
            stmt.bindLong(9, f.getRegion());
            stmt.bindLong(10, f.getRayon());
            stmt.bindLong(11, f.getSettlement());
            if (f.getStreetName() != null)
                stmt.bindString(12, f.getStreetName());
            if (f.getBuilding() != null)
                stmt.bindString(13, f.getBuilding());
            if (f.getHouse() != null)
                stmt.bindString(14, f.getHouse());
            if (f.getApartment() != null)
                stmt.bindString(15, f.getApartment());
            if (f.getPostCode() != null)
                stmt.bindString(16, f.getPostCode());
            if (f.getPhone() != null)
                stmt.bindString(17, f.getPhone());
            if (f.getFax() != null)
                stmt.bindString(18, f.getFax());
            if (f.getEmail() != null)
                stmt.bindString(19, f.getEmail());
            stmt.bindDouble(20, f.getLongitude());
            stmt.bindDouble(21, f.getLatitude());
            stmt.bindLong(22, f.getId());
            stmt.execute();
        }
        for (int i = 0; i < farmsToUpdate.size(); i++) {
            Farm f = farmsToUpdate.get(i);
            stmt.clearBindings();
            stmt.bindLong(1, 0);
            stmt.bindLong(2, f.getFarm());
            stmt.bindLong(3, f.getRootFarm());
            if (f.getFarmCode() != null)
                stmt.bindString(4, f.getFarmCode());
            if (f.getFarmName() != null)
                stmt.bindString(5, f.getFarmName());
            if (f.getOwnerLastName() != null)
                stmt.bindString(6, f.getOwnerLastName());
            if (f.getOwnerFirstName() != null)
                stmt.bindString(7, f.getOwnerFirstName());
            if (f.getOwnerMiddleName() != null)
                stmt.bindString(8, f.getOwnerMiddleName());
            stmt.bindLong(9, f.getRegion());
            stmt.bindLong(10, f.getRayon());
            stmt.bindLong(11, f.getSettlement());
            if (f.getStreetName() != null)
                stmt.bindString(12, f.getStreetName());
            if (f.getBuilding() != null)
                stmt.bindString(13, f.getBuilding());
            if (f.getHouse() != null)
                stmt.bindString(14, f.getHouse());
            if (f.getApartment() != null)
                stmt.bindString(15, f.getApartment());
            if (f.getPostCode() != null)
                stmt.bindString(16, f.getPostCode());
            if (f.getPhone() != null)
                stmt.bindString(17, f.getPhone());
            if (f.getFax() != null)
                stmt.bindString(18, f.getFax());
            if (f.getEmail() != null)
                stmt.bindString(19, f.getEmail());
            stmt.bindDouble(20, f.getLongitude());
            stmt.bindDouble(21, f.getLatitude());
            stmt.bindLong(22, f.getId());
            stmt.execute();
        }
        stmt.close();
    }

    public static long NewFarmCount(EidssDatabase ed){
        SQLiteDatabase db = ed.getReadableDatabase();
        SQLiteStatement s = db.compileStatement("select count(*) from Farm where ifnull(blnIsRoot,0)=0 and ifnull(idfFarm,0)<=0 and ifnull(idfRootFarm,0)=0");
        long ret = s.simpleQueryForLong();
        db.close();
        return ret;
    }

    public static long NewFarmRootCount(SQLiteDatabase db){
        SQLiteStatement s = db.compileStatement("select count(*) from Farm where ifnull(blnIsRoot,0)=1 and ifnull(idfFarm,0)<=0 and ifnull(idfRootFarm,0)=0");
        long ret = s.simpleQueryForLong();
        return ret;
    }

    public static Farm_object GetRootFarm(EidssDatabase ed, long id){
        SQLiteDatabase db = ed.getReadableDatabase();
        Farm ret = null;
        Cursor cursor = db.query("Farm", null, "blnIsRoot=1 and idfFarm=" + String.valueOf(id), null, null, null, null);
        Boolean r = cursor.moveToFirst();
        if(r) {
            ret = Farm.FromCursor(cursor);
        }
        cursor.close();
        db.close();
        return ret;
    }

    //--------------------------------------
    public static void FarmsSelect(EidssDatabase ed, final List<ASSession> ret, final long id)
    {
        SQLiteDatabase db = ed.getReadableDatabase();
        Cursor cursor;
        if(id == 0) {
            cursor = db.query("Farm", null, "ifnull(blnIsRoot,0)=0", null, null, null, "id");
            Boolean rSp = cursor.moveToFirst();
            while(rSp)
            {
                Farm it = Farm.FromCursor(cursor);
                if (it != null)
                {
                    for(ASSession vc : ret)
                    {
                        if (it.getParent() == vc.getId()) {
                            vc.farms.add(it);
                            break;
                        }
                    }
                }
                rSp = cursor.moveToNext();
            }
            cursor.close();
        } else {
            for(ASSession vc : ret)
            {
                cursor = db.rawQuery(select_sql_farms, new String [] {String.valueOf(vc.getId())} );
                Boolean rSp = cursor.moveToFirst();
                while(rSp)
                {
                    Farm it = Farm.FromCursor(cursor);
                    vc.farms.add(it);
                    rSp = cursor.moveToNext();
                }
                cursor.close();
            }
        }

        for(ASSession vc : ret){
            for(Farm f : vc.farms){
                EidssDatabaseSpecies.SpeciesSelect(db, new ArrayList<ISpeciesParent>(vc.farms), f.getId());
            }
        }

        db.close();
    }

    public static void InsertFarm(SQLiteDatabase db, Farm f){
        f.setId(db.insert("Farm", null, f.ContentValues()));
    }

    public static void UpdateOrInsertFarm(SQLiteDatabase db, Farm f){
        Farm fndF = null;
        Cursor cursor = db.query("Farm", null, "ifnull(blnIsRoot,0)=0 and idfFarm=" + f.getFarm(), null, null, null, null);
        Boolean r = cursor.moveToLast();
        if(r){
            fndF = Farm.FromCursor(cursor);
        }
        cursor.close();

        if (fndF != null){
            db.update("Farm", f.ContentValues(), "ifnull(blnIsRoot,0)=0 and idfFarm=?", new String[]{String.valueOf(f.getFarm())});
        } else {
            InsertFarm(db, f);
        }
    }

}
