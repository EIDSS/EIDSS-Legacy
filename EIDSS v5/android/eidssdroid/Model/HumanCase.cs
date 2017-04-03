using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using eidssdroid.model.Database;
using eidss.model.Enums;
using bv.model.Helpers;

namespace eidssdroid.Model
{
    public enum HumanCaseStatus
    {
        NEW = 1,
        SYNCHRONIZED = 2,
        CHANGED = 3
    }

    public class HumanCase : Java.Lang.Object, IParcelable
    {
        public Int64 id { get; set; }
        public String strLastSynError { get; set; }
        public Int32 intStatus { get; set; } //  1 - new; 2 - synchronized; 3 - changed;
        public DateTime datCreateDate { get; set; }
        public String uidOfflineCaseID { get; set; }
        public String strCaseID { get; set; }
        public Int64 idfCase { get; set; }

        private string _strLocalIdentifier;
        public String strLocalIdentifier { get { return _strLocalIdentifier; } set { bChanged = bChanged || _strLocalIdentifier != value; _strLocalIdentifier = value; } }
        private long _idfsTentativeDiagnosis;
        public Int64 idfsTentativeDiagnosis { get { return _idfsTentativeDiagnosis; } set { bChanged = bChanged || _idfsTentativeDiagnosis != value; _idfsTentativeDiagnosis = value; } }
        private DateTime _datTentativeDiagnosisDate;
        public DateTime datTentativeDiagnosisDate { get { return _datTentativeDiagnosisDate; } set { bChanged = bChanged || _datTentativeDiagnosisDate != value; _datTentativeDiagnosisDate = value; } }
        private string _strFamilyName;
        public String strFamilyName { get { return _strFamilyName; } set { bChanged = bChanged || _strFamilyName != value; _strFamilyName = value; } }
        private string _strFirstName;
        public String strFirstName { get { return _strFirstName; } set { bChanged = bChanged || _strFirstName != value; _strFirstName = value; } }
        private DateTime _datDateofBirth;
        public DateTime datDateofBirth { get { return _datDateofBirth; } set { bChanged = bChanged || _datDateofBirth != value; _datDateofBirth = value; } }
        private int _intPatientAge;
        public Int32 intPatientAge { get { return _intPatientAge; } set { bChanged = bChanged || _intPatientAge != value; _intPatientAge = value; } }
        private long _idfsHumanAgeType;
        public Int64 idfsHumanAgeType { get { return _idfsHumanAgeType; } set { bChanged = bChanged || _idfsHumanAgeType != value; _idfsHumanAgeType = value; } }
        private long _idfsHumanGender;
        public Int64 idfsHumanGender { get { return _idfsHumanGender; } set { bChanged = bChanged || _idfsHumanGender != value; _idfsHumanGender = value; } }
        private long _idfsRegionCurrentResidence;
        public Int64 idfsRegionCurrentResidence { get { return _idfsRegionCurrentResidence; } set { bChanged = bChanged || _idfsRegionCurrentResidence != value; _idfsRegionCurrentResidence = value; } }
        private long _idfsRayonCurrentResidence;
        public Int64 idfsRayonCurrentResidence { get { return _idfsRayonCurrentResidence; } set { bChanged = bChanged || _idfsRayonCurrentResidence != value; _idfsRayonCurrentResidence = value; } }
        private long _idfsSettlementCurrentResidence;
        public Int64 idfsSettlementCurrentResidence { get { return _idfsSettlementCurrentResidence; } set { bChanged = bChanged || _idfsSettlementCurrentResidence != value; _idfsSettlementCurrentResidence = value; } }
        private string _strBuilding;
        public String strBuilding { get { return _strBuilding; } set { bChanged = bChanged || _strBuilding != value; _strBuilding = value; } }
        private string _strHouse;
        public String strHouse { get { return _strHouse; } set { bChanged = bChanged || _strHouse != value; _strHouse = value; } }
        private string _strApartment;
        public String strApartment { get { return _strApartment; } set { bChanged = bChanged || _strApartment != value; _strApartment = value; } }
        private string _strStreetName;
        public String strStreetName { get { return _strStreetName; } set { bChanged = bChanged || _strStreetName != value; _strStreetName = value; } }
        private string _strPostCode;
        public String strPostCode { get { return _strPostCode; } set { bChanged = bChanged || _strPostCode != value; _strPostCode = value; } }
        private string _strHomePhone;
        public String strHomePhone { get { return _strHomePhone; } set { bChanged = bChanged || _strHomePhone != value; _strHomePhone = value; } }
        private DateTime _datOnSetDate;
        public DateTime datOnSetDate { get { return _datOnSetDate; } set { bChanged = bChanged || _datOnSetDate != value; _datOnSetDate = value; } }
        private long _idfsFinalState;
        public Int64 idfsFinalState { get { return _idfsFinalState; } set { bChanged = bChanged || _idfsFinalState != value; _idfsFinalState = value; } }
        private long _idfsHospitalizationStatus;
        public Int64 idfsHospitalizationStatus { get { return _idfsHospitalizationStatus; } set { bChanged = bChanged || _idfsHospitalizationStatus != value; _idfsHospitalizationStatus = value; } }

        public DateTime datNotificationDate { get; set; }
        public String strSentByOffice { get; set; }
        public String strSentByPerson { get; set; }

        public bool bChanged { get; set; }

        public String TentativeDiagnosis(EidssDatabase db)
        { 
            var r =
                db.Reference((long)BaseReferenceType.rftDiagnosis, db.CurrentLanguage, 2)
                    .SingleOrDefault(c => c.idfsBaseReference == idfsTentativeDiagnosis);
            if (r != null) return r.name;
            return "";
        }

        //public bool checkd { get; set; }

        private HumanCase()
        {
        }

        public static HumanCase CreateNew()
        {
            return new HumanCase()
            {
                intStatus = (int)HumanCaseStatus.NEW,
                uidOfflineCaseID = Guid.NewGuid().ToString(),
                strCaseID = "(new)",
                datCreateDate = DateTime.Now,
                bChanged = true
            };
        }


        #region Age
        private DateTime datD
        {
            get { return new Func<HumanCase, DateTime>(c => c.datOnSetDate > DateTime.MinValue ? c.datOnSetDate : (c.datNotificationDate > DateTime.MinValue ? c.datNotificationDate : c.datCreateDate.Date))(this); }
        }

        public int CalcPatientAge()
        {
            int _intPatientAge = 0;
            long _idfsHumanAgeType = 0;
            if (GetDOBandAge(ref _intPatientAge, ref _idfsHumanAgeType))
                return _intPatientAge;
            return this.intPatientAge;
        }

        public long CalcPatientAgeType()
        {
            int _intPatientAge = 0;
            long _idfsHumanAgeType = 0;
            if (GetDOBandAge(ref _intPatientAge, ref _idfsHumanAgeType))
                return _idfsHumanAgeType;
            return this.idfsHumanAgeType;
        }

        private bool GetDOBandAge(ref int _intPatientAge, ref long _idfsHumanAgeType)
        {
            double ddAge = -1;
            DateTime? datUp = null;
            if (this.datDateofBirth > DateTime.MinValue && this.datD > DateTime.MinValue)
            {
                datUp = this.datD;
                ddAge = -this.datDateofBirth.Date.Subtract(this.datD.Date).TotalDays;

                if (ddAge > -1)
                {
                    long yyAge = DateHelper.DateDifference(DateInterval.Year, this.datDateofBirth.Date, datUp.Value);
                    if (yyAge > 0)
                    {
                        //'Years
                        _intPatientAge = (int)yyAge;
                        _idfsHumanAgeType = (long)HumanAgeTypeEnum.Years;
                        return true;
                    }
                    else
                    {
                        long mmAge = DateHelper.DateDifference(DateInterval.Month, this.datDateofBirth.Date, datUp.Value);
                        if (mmAge > 0)
                        {
                            //'Months
                            _intPatientAge = (int)mmAge;
                            _idfsHumanAgeType = (long)HumanAgeTypeEnum.Month;
                            return true;
                        }
                        else
                        {
                            //'Days
                            _intPatientAge = (int)ddAge;
                            _idfsHumanAgeType = (long)HumanAgeTypeEnum.Days;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region FromCursor
        public static HumanCase FromCursor(ICursor cursor)
        {
            return new HumanCase()
            {
                id = cursor.GetLong(cursor.GetColumnIndex("id")),
                strLastSynError = cursor.GetString(cursor.GetColumnIndex("strLastSynError")),
                intStatus = cursor.GetInt(cursor.GetColumnIndex("intStatus")),
                datCreateDate = DateTime.ParseExact(
                    cursor.GetString(cursor.GetColumnIndex("datCreateDate")).Length < 21 ? "00010101 00:00:00.000" : 
                    cursor.GetString(cursor.GetColumnIndex("datCreateDate")), 
                    "yyyyMMdd HH:mm:ss.fff", null),
                uidOfflineCaseID = cursor.GetString(cursor.GetColumnIndex("uidOfflineCaseID")),
                strCaseID = cursor.GetString(cursor.GetColumnIndex("strCaseID")),
                idfCase = cursor.GetLong(cursor.GetColumnIndex("idfCase")),

                strLocalIdentifier = cursor.GetString(cursor.GetColumnIndex("strLocalIdentifier")),
                idfsTentativeDiagnosis = cursor.GetLong(cursor.GetColumnIndex("idfsTentativeDiagnosis")),
                datTentativeDiagnosisDate = DateTime.ParseExact(
                    cursor.GetString(cursor.GetColumnIndex("datTentativeDiagnosisDate")).Length < 8 ? "00010101" :
                    cursor.GetString(cursor.GetColumnIndex("datTentativeDiagnosisDate")),
                    "yyyyMMdd", null),
                strFamilyName = cursor.GetString(cursor.GetColumnIndex("strFamilyName")),
                strFirstName = cursor.GetString(cursor.GetColumnIndex("strFirstName")),
                datDateofBirth = DateTime.ParseExact(
                    cursor.GetString(cursor.GetColumnIndex("datDateofBirth")).Length < 8 ? "00010101" :
                    cursor.GetString(cursor.GetColumnIndex("datDateofBirth")),
                    "yyyyMMdd", null),
                intPatientAge = cursor.GetInt(cursor.GetColumnIndex("intPatientAge")),
                idfsHumanAgeType = cursor.GetLong(cursor.GetColumnIndex("idfsHumanAgeType")),
                idfsHumanGender = cursor.GetLong(cursor.GetColumnIndex("idfsHumanGender")),
                idfsRegionCurrentResidence = cursor.GetLong(cursor.GetColumnIndex("idfsRegionCurrentResidence")),
                idfsRayonCurrentResidence = cursor.GetLong(cursor.GetColumnIndex("idfsRayonCurrentResidence")),
                idfsSettlementCurrentResidence = cursor.GetLong(cursor.GetColumnIndex("idfsSettlementCurrentResidence")),
                strBuilding = cursor.GetString(cursor.GetColumnIndex("strBuilding")),
                strHouse = cursor.GetString(cursor.GetColumnIndex("strHouse")),
                strApartment = cursor.GetString(cursor.GetColumnIndex("strApartment")),
                strStreetName = cursor.GetString(cursor.GetColumnIndex("strStreetName")),
                strPostCode = cursor.GetString(cursor.GetColumnIndex("strPostCode")),
                strHomePhone = cursor.GetString(cursor.GetColumnIndex("strHomePhone")),
                datOnSetDate = DateTime.ParseExact(
                    cursor.GetString(cursor.GetColumnIndex("datOnSetDate")).Length < 8 ? "00010101" :
                    cursor.GetString(cursor.GetColumnIndex("datOnSetDate")),
                    "yyyyMMdd", null),
                idfsFinalState = cursor.GetLong(cursor.GetColumnIndex("idfsFinalState")),
                idfsHospitalizationStatus = cursor.GetLong(cursor.GetColumnIndex("idfsHospitalizationStatus")),
                datNotificationDate = DateTime.ParseExact(
                    cursor.GetString(cursor.GetColumnIndex("datNotificationDate")).Length < 8 ? "00010101" :
                    cursor.GetString(cursor.GetColumnIndex("datNotificationDate")),
                    "yyyyMMdd", null),
                strSentByOffice = cursor.GetString(cursor.GetColumnIndex("strSentByOffice")),
                strSentByPerson = cursor.GetString(cursor.GetColumnIndex("strSentByPerson")),
                bChanged = false
            };
        }
        #endregion

        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            if (id != 0)
                ret.Put("id", id);
            ret.Put("strLastSynError", strLastSynError);
            ret.Put("intStatus", intStatus);
            ret.Put("datCreateDate", datCreateDate.ToString("yyyyMMdd HH:mm:ss.fff"));
            ret.Put("uidOfflineCaseID", uidOfflineCaseID);
            ret.Put("strCaseID", strCaseID);
            ret.Put("idfCase", idfCase);

            ret.Put("strLocalIdentifier", strLocalIdentifier);
            ret.Put("idfsTentativeDiagnosis", idfsTentativeDiagnosis);
            ret.Put("datTentativeDiagnosisDate", datTentativeDiagnosisDate.ToString("yyyyMMdd"));
            ret.Put("strFamilyName", strFamilyName);
            ret.Put("strFirstName", strFirstName);
            ret.Put("datDateofBirth", datDateofBirth.ToString("yyyyMMdd"));
            ret.Put("intPatientAge", intPatientAge);
            ret.Put("idfsHumanAgeType", idfsHumanAgeType);
            ret.Put("idfsHumanGender", idfsHumanGender);
            ret.Put("idfsRegionCurrentResidence", idfsRegionCurrentResidence);
            ret.Put("idfsRayonCurrentResidence", idfsRayonCurrentResidence);
            ret.Put("idfsSettlementCurrentResidence", idfsSettlementCurrentResidence);
            ret.Put("strBuilding", strBuilding);
            ret.Put("strHouse", strHouse);
            ret.Put("strApartment", strApartment);
            ret.Put("strStreetName", strStreetName);
            ret.Put("strPostCode", strPostCode);
            ret.Put("strHomePhone", strHomePhone);
            ret.Put("datOnSetDate", datOnSetDate.ToString("yyyyMMdd"));
            ret.Put("idfsFinalState", idfsFinalState);
            ret.Put("idfsHospitalizationStatus", idfsHospitalizationStatus);
            ret.Put("datNotificationDate", datNotificationDate.ToString("yyyyMMdd"));
            ret.Put("strSentByOffice", strSentByOffice);
            ret.Put("strSentByPerson", strSentByPerson);
            return ret;
        }
        #endregion

        #region IParcelable
        public class HumanCaseCreator : Java.Lang.Object, IParcelableCreator
        {
            public Java.Lang.Object CreateFromParcel(Parcel source)
            {
                return new HumanCase()
                {
                    id = source.ReadLong(),
                    strLastSynError = source.ReadString(),
                    intStatus = source.ReadInt(),
                    datCreateDate = new DateTime(source.ReadInt(), source.ReadInt(), source.ReadInt(), source.ReadInt(), source.ReadInt(), source.ReadInt(), source.ReadInt()),
                    uidOfflineCaseID = source.ReadString(),
                    strCaseID = source.ReadString(),
                    idfCase = source.ReadLong(),

                    strLocalIdentifier = source.ReadString(),
                    idfsTentativeDiagnosis = source.ReadLong(),
                    datTentativeDiagnosisDate = new DateTime(source.ReadInt(), source.ReadInt(), source.ReadInt()),
                    strFamilyName = source.ReadString(),
                    strFirstName = source.ReadString(),
                    datDateofBirth = new DateTime(source.ReadInt(), source.ReadInt(), source.ReadInt()),
                    intPatientAge = source.ReadInt(),
                    idfsHumanAgeType = source.ReadLong(),
                    idfsHumanGender = source.ReadLong(),
                    idfsRegionCurrentResidence = source.ReadLong(),
                    idfsRayonCurrentResidence = source.ReadLong(),
                    idfsSettlementCurrentResidence = source.ReadLong(),
                    strBuilding = source.ReadString(),
                    strHouse = source.ReadString(),
                    strApartment = source.ReadString(),
                    strStreetName = source.ReadString(),
                    strPostCode = source.ReadString(),
                    strHomePhone = source.ReadString(),
                    datOnSetDate = new DateTime(source.ReadInt(), source.ReadInt(), source.ReadInt()),
                    idfsFinalState = source.ReadLong(),
                    idfsHospitalizationStatus = source.ReadLong(),
                    datNotificationDate = new DateTime(source.ReadInt(), source.ReadInt(), source.ReadInt()),
                    strSentByOffice = source.ReadString(),
                    strSentByPerson = source.ReadString(),
                    bChanged = false
                };
            }

            public Java.Lang.Object[] NewArray(int size)
            {
                throw new NotImplementedException();
            }

        }

        [ExportField("CREATOR")]
        public static IParcelableCreator CREATOR()
        {
            return _CREATOR;
        }
        private static IParcelableCreator _CREATOR = new HumanCaseCreator();


        public int DescribeContents()
        {
            return 4;
        }

        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteLong(id);
            dest.WriteString(strLastSynError);
            dest.WriteInt(intStatus);
            dest.WriteInt(datCreateDate.Year);
            dest.WriteInt(datCreateDate.Month);
            dest.WriteInt(datCreateDate.Day);
            dest.WriteInt(datCreateDate.Hour);
            dest.WriteInt(datCreateDate.Minute);
            dest.WriteInt(datCreateDate.Second);
            dest.WriteInt(datCreateDate.Millisecond);
            dest.WriteString(uidOfflineCaseID);
            dest.WriteString(strCaseID);
            dest.WriteLong(idfCase);

            dest.WriteString(strLocalIdentifier);
            dest.WriteLong(idfsTentativeDiagnosis);
            dest.WriteInt(datTentativeDiagnosisDate.Year);
            dest.WriteInt(datTentativeDiagnosisDate.Month);
            dest.WriteInt(datTentativeDiagnosisDate.Day);
            dest.WriteString(strFamilyName);
            dest.WriteString(strFirstName);
            dest.WriteInt(datDateofBirth.Year);
            dest.WriteInt(datDateofBirth.Month);
            dest.WriteInt(datDateofBirth.Day);
            dest.WriteInt(intPatientAge);
            dest.WriteLong(idfsHumanAgeType);
            dest.WriteLong(idfsHumanGender);
            dest.WriteLong(idfsRegionCurrentResidence);
            dest.WriteLong(idfsRayonCurrentResidence);
            dest.WriteLong(idfsSettlementCurrentResidence);
            dest.WriteString(strBuilding);
            dest.WriteString(strHouse);
            dest.WriteString(strApartment);
            dest.WriteString(strStreetName);
            dest.WriteString(strPostCode);
            dest.WriteString(strHomePhone);
            dest.WriteInt(datOnSetDate.Year);
            dest.WriteInt(datOnSetDate.Month);
            dest.WriteInt(datOnSetDate.Day);
            dest.WriteLong(idfsFinalState);
            dest.WriteLong(idfsHospitalizationStatus);
            dest.WriteInt(datNotificationDate.Year);
            dest.WriteInt(datNotificationDate.Month);
            dest.WriteInt(datNotificationDate.Day);
            dest.WriteString(strSentByOffice);
            dest.WriteString(strSentByPerson);
        }
        #endregion
    }
}