package com.bv.eidss.model;

import java.io.IOException;
import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.xmlpull.v1.XmlSerializer;

import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.utils.DateHelpers;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

public class Species implements Parcelable, IValidatable {
    private long _id;
    public long getId() { return _id; } 
    public void setId(long value) { _id = value; }
    private long _idVetCase;
    public long getIdVetCase() { return _idVetCase; } 
    public void setIdVetCase(long value) { _idVetCase = value; }
    
    private long _idfsHerd;
    public long getHerd() { return _idfsHerd; } public void setHerd(long value) { bChanged = bChanged || _idfsHerd != value; _idfsHerd = value; }
    private long _idfsSpeciesType;
    public long getSpeciesType() { return _idfsSpeciesType; } 
    public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _idfsSpeciesType = value; }
    private Date _datStartOfSignsDate;
    public Date getStartOfSignsDate() { return _datStartOfSignsDate; } 
    public void setStartOfSignsDate(Date value) { bChanged = bChanged || _datStartOfSignsDate != value; _datStartOfSignsDate = value; }
    private int _intTotalAnimalQty;
    public int getTotalAnimalQty()  { return _intTotalAnimalQty; } 
    public void setTotalAnimalQty(int value) { bChanged = bChanged || _intTotalAnimalQty != value; _intTotalAnimalQty = value; }
    private int _intDeadAnimalQty;
    public int getDeadAnimalQty()  { return _intDeadAnimalQty; } 
    public void setDeadAnimalQty(int value) { bChanged = bChanged || _intDeadAnimalQty != value; _intDeadAnimalQty = value; }
    private int _intSickAnimalQty;
    public int getSickAnimalQty()  { return _intSickAnimalQty; } 
    public void setSickAnimalQty(int value) { bChanged = bChanged || _intSickAnimalQty != value; _intSickAnimalQty = value; }

    private Boolean bChanged;
    public Boolean getChanged() { return bChanged; }  public void setUnchanged() { bChanged = false; }


    private Species()
    {
    }

    public static Species CreateNew(long caseId)
    {
    	Species ret = new Species();
        ret._idVetCase = caseId;
        ret._datStartOfSignsDate = null;
        ret.bChanged = true;
        return ret;
    }

    public static Species FromCursor(Cursor cursor)
    {
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	Species ret = new Species();
		try {
	        ret._id = cursor.getLong(cursor.getColumnIndex("id"));
	        ret._idVetCase = cursor.getLong(cursor.getColumnIndex("idVetCase"));
	        ret._idfsHerd = cursor.getLong(cursor.getColumnIndex("idfsHerd"));
	        ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
	        String strDate = cursor.getString(cursor.getColumnIndex("datStartOfSignsDate"));
	    	if (strDate != null && !strDate.isEmpty())
	    		ret._datStartOfSignsDate = (Date)formatterDateTime.parseObject(strDate);
	        ret._intTotalAnimalQty = cursor.getInt(cursor.getColumnIndex("intTotalAnimalQty"));
	        ret._intDeadAnimalQty = cursor.getInt(cursor.getColumnIndex("intDeadAnimalQty"));
	        ret._intSickAnimalQty = cursor.getInt(cursor.getColumnIndex("intSickAnimalQty"));
	        ret.bChanged = false;
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		} 
        return ret;
    }

    public ContentValues ContentValues()
    {
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	
    	ContentValues ret = new ContentValues();
        if (_id != 0)
        	ret.put("id", _id);
        ret.put("idVetCase", _idVetCase);
        ret.put("idfsHerd", _idfsHerd);
        ret.put("idfsSpeciesType", _idfsSpeciesType);
        String strDate = null;
        if (_datStartOfSignsDate != null)
        	strDate = formatterDateTime.format(_datStartOfSignsDate);
        ret.put("datStartOfSignsDate", strDate);
        ret.put("intTotalAnimalQty",    _intTotalAnimalQty);
        ret.put("intDeadAnimalQty",    _intDeadAnimalQty);
        ret.put("intSickAnimalQty",    _intSickAnimalQty);
        return ret;
    }

	@Override
	public ValidateCode Validate() {
        if (getSpeciesType() == 0)
        	return ValidateCode.SpeciesTypeMandatory;
        if (getStartOfSignsDate() != null && getStartOfSignsDate().after(DateHelpers.Today()))
        	return ValidateCode.DateOfStartOfSignsCheckCurrent;
        if (_intTotalAnimalQty < _intDeadAnimalQty + _intSickAnimalQty)
        	return ValidateCode.SpeciesTotalLessDeadSick;
		return ValidateCode.OK;
	}

    private Species(Parcel source)
    {
        _id = source.readLong();
        _idVetCase = source.readLong();
        _idfsHerd = source.readLong();
        _idfsSpeciesType = source.readLong();
        _datStartOfSignsDate = (Date)source.readSerializable();
        _intTotalAnimalQty = source.readInt();
        _intDeadAnimalQty = source.readInt();
        _intSickAnimalQty = source.readInt();
        bChanged = source.readByte() == 1;
    }
	
    public static final Parcelable.Creator<Species> CREATOR = 
            new Parcelable.Creator<Species>() {

                @Override
                public Species createFromParcel(Parcel source) {
                    return new Species(source);
                }

                @Override
                public Species[] newArray(int size) {
                    return new Species[size];
                }
            };

    
    @Override
	public int describeContents() {
        return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flag) {
		dest.writeLong(_id);
		dest.writeLong(_idVetCase);
		dest.writeLong(_idfsHerd);
		dest.writeLong(_idfsSpeciesType);
        dest.writeSerializable(_datStartOfSignsDate);
        dest.writeInt(_intTotalAnimalQty);
        dest.writeInt(_intDeadAnimalQty);
        dest.writeInt(_intSickAnimalQty);
        dest.writeByte((byte) (bChanged ? 1 : 0));     
	}

	public void writeXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        serializer.startTag("", "kind");
        if (getId() != 0) 
        	serializer.attribute("", "id", String.valueOf(getId()));
        if (getHerd() != 0) 
        	serializer.attribute("", "herd", String.valueOf(getHerd()));
        if (getSpeciesType() != 0) 
        	serializer.attribute("", "speciesType", String.valueOf(getSpeciesType()));
        if (getStartOfSignsDate() != null) 
        	serializer.attribute("", "startOfSignsDate", formatterDateTime.format(getStartOfSignsDate()).replace(' ', 'T'));
        if (getTotalAnimalQty() != 0) 
        	serializer.attribute("", "totalAnimalQty", String.valueOf(getTotalAnimalQty()));
        if (getDeadAnimalQty() != 0) 
        	serializer.attribute("", "deadAnimalQty", String.valueOf(getDeadAnimalQty()));
        if (getSickAnimalQty() != 0) 
	        serializer.attribute("", "sickAnimalQty", String.valueOf(getSickAnimalQty()));
        serializer.endTag("", "kind");
	}
}
