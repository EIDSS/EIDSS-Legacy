using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Extenders;

namespace eidss.model.Schema
{
    public partial class Patient
    {
        /*public Patient DeepClone()
        {
            Patient ret = base.Clone() as Patient;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            if (CurrentResidenceAddress != null)
                ret.CurrentResidenceAddress = CurrentResidenceAddress.DeepClone();
            if (EmployerAddress != null)
                ret.EmployerAddress = EmployerAddress.DeepClone();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/

        public Patient CopyFrom(DbManagerProxy manager, Patient source)
        {
            // copy all fields, except primaryKey
            var ret = source.CloneWithSetup(manager) as Patient;
            if (ret == null)
            {
                return null;
            }

            ret.idfHuman = idfHuman;
            ret.idfRootHuman = source.idfRootHuman.HasValue ? source.idfRootHuman : source.idfHuman;
            if (CurrentResidenceAddress != null && source.CurrentResidenceAddress != null)
            {
                ret.CurrentResidenceAddress = CurrentResidenceAddress.CopyFrom(manager, source.CurrentResidenceAddress);
            }
            if (EmployerAddress != null && source.EmployerAddress != null)
            {
                ret.EmployerAddress = EmployerAddress.CopyFrom(manager, source.EmployerAddress);
            }
            if (RegistrationAddress != null && source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = RegistrationAddress.CopyFrom(manager, source.RegistrationAddress);
            }
            else if (source.RegistrationAddress != null)
            {
                ret.RegistrationAddress = source.RegistrationAddress.CloneWithSetup(manager) as Address;
            }

            return ret;
        }

        public void SetFromRoot(DbManagerProxy manager, long idfHumanActual, HumanCase hc)
        {
            var patient = Patient.Accessor.Instance(null).SelectByKey(manager, idfHumanActual);
            hc.Patient = CopyFrom(manager, patient);
            hc.Patient.intPatientAgeFromCase = hc.CalcPatientAge();
            hc.Patient.HumanAgeType = HumanAgeTypeLookup.SingleOrDefault(a => a.idfsBaseReference == hc.CalcPatientAgeType());
            HumanCase.Accessor.Instance(null).SetupChildHandlers(hc, hc.Patient);
        }

        public void SetFromRoot(DbManagerProxy manager, long idfHumanActual, ContactedCasePerson cp)
        {
            var patient = Patient.Accessor.Instance(null).SelectByKey(manager, idfHumanActual);
            cp.Person = CopyFrom(manager, patient);
            ContactedCasePerson.Accessor.Instance(null).SetupChildHandlers(cp, cp.Person);
        }

        public Patient Clear(DbManagerProxy manager, long id)
        {
            var ret = Accessor.Instance(null).Create(manager, Parent, id);
            ret.idfHuman = idfHuman;
            if (CurrentResidenceAddress != null && ret.CurrentResidenceAddress != null)
            {
                ret.CurrentResidenceAddress.idfGeoLocation = CurrentResidenceAddress.idfGeoLocation;
            }
            if (EmployerAddress != null && ret.EmployerAddress != null)
            {
                ret.EmployerAddress.idfGeoLocation = EmployerAddress.idfGeoLocation;
            }
            if (RegistrationAddress != null && ret.RegistrationAddress != null)
            {
                ret.RegistrationAddress.idfGeoLocation = RegistrationAddress.idfGeoLocation;
            }

            return ret;
        }

        internal void RaisePropChanged()
        {
            this.OnPropertyChanged("datDateofBirth");
            this.OnPropertyChanged("Gender");
        }
        public Patient Clear(DbManagerProxy manager)
        {
            return Clear(manager, (Parent as HumanCase).idfCase);
        }


        /*
                __CurrentResidenceAddress = value;
        */
        /*
        private Address __CurrentResidenceAddress;
        protected Address _CurrentResidenceAddress
        {
            get { return __CurrentResidenceAddress; }
            set { __CurrentResidenceAddress = value; CheckAddress(); }
        }
        */

        /*
        public Int64? idfCurrentResidenceAddress { 
            get { return _idfCurrentResidenceAddress; }
            set { _idfCurrentResidenceAddress = value; 
                OnPropertyChanged(_str_idfCurrentResidenceAddress);
                CheckAddress(); }
        }
        private Int64? _idfCurrentResidenceAddress;
        */

        public void FixAddress() // fixing bug 11245
        {
            if (CurrentResidenceAddress != null && idfCurrentResidenceAddress != CurrentResidenceAddress.idfGeoLocation)
            {
                WriteToLog("idfCurrentResidenceAddress", idfCurrentResidenceAddress, CurrentResidenceAddress.idfGeoLocation);
                idfCurrentResidenceAddress = CurrentResidenceAddress.idfGeoLocation;
            }
            if (EmployerAddress != null && idfEmployerAddress != EmployerAddress.idfGeoLocation)
            {
                WriteToLog("idfEmployerAddress", idfEmployerAddress, EmployerAddress.idfGeoLocation);
                idfEmployerAddress = EmployerAddress.idfGeoLocation;
            }
            if (RegistrationAddress != null && idfRegistrationAddress != RegistrationAddress.idfGeoLocation)
            {
                WriteToLog("idfRegistrationAddress", idfRegistrationAddress, RegistrationAddress.idfGeoLocation);
                idfRegistrationAddress = RegistrationAddress.idfGeoLocation;
            }
        }

        private void WriteToLog(string field, long? inObj, long? inAddr)
        {
            string path = Config.GetSetting("ErrorLogPath");
            if (!String.IsNullOrEmpty(path))
            {
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        return;
                    }
                }

                string filename = String.Format("ErrorLog{0}{1}{2}.txt", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);
                try
                {
                    using (StreamWriter stream = File.AppendText(Path.Combine(path, filename)))
                    {
                        stream.WriteLine("{0}", DateTime.Now.ToString("MM/dd/yyyy hh:mm"));
                        stream.WriteLine("{0}: in object {1}, in address {2}", field, inObj, inAddr);
                        stream.WriteLine("--------------------------------------------------\r\n");
                        stream.Flush();
                    }
                }
                catch
                {
                }
            }
        }

        public void CheckAddress()
        {
            if (_CurrentResidenceAddress != null && idfCurrentResidenceAddress != _CurrentResidenceAddress.idfGeoLocation
                ||
                _CurrentResidenceAddress == null && idfCurrentResidenceAddress != null
                )
            {
                var sb = new StringBuilder();
                try
                {
                    var stackTrace = new StackTrace();
                    var stackFrames = stackTrace.GetFrames();
                    stackFrames.ToList().ForEach(c =>
                        {
                            try
                            {
                                var method = c.GetMethod();
                                var tp = method.DeclaringType.FullName;
                                var mn = method.Name;
                                sb.AppendFormat("{0}.{1}", tp, mn);
                            }
                            catch
                            {
                                sb.AppendFormat("---- unknown frame ----");
                            }
                            sb.AppendLine();
                        });
                }
                catch
                {
                }
                

                string path = Config.GetSetting("ErrorLogPath");
                if (!String.IsNullOrEmpty(path))
                {
                    if (!Directory.Exists(path))
                    {
                        try
                        {
                            Directory.CreateDirectory(path);
                        }
                        catch
                        {
                            return;
                        }
                    }

                    string filename = String.Format("ErrorLog{0}{1}{2}.txt", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);
                    try
                    {
                        using (StreamWriter stream = File.AppendText(Path.Combine(path, filename)))
                        {
                            stream.WriteLine("{0}", DateTime.Now.ToString("MM/dd/yyyy hh:mm"));
                            stream.WriteLine("_CurrentResidenceAddress = {0}", _CurrentResidenceAddress == null ? "null" : "object");
                            stream.WriteLine("_CurrentResidenceAddress.idfGeoLocation = {0}", _CurrentResidenceAddress == null ? "null" : _CurrentResidenceAddress.idfGeoLocation.ToString());
                            stream.WriteLine("idfCurrentResidenceAddress = {0}", idfCurrentResidenceAddress.ToString());
                            stream.Write(sb.ToString());
                            stream.WriteLine("--------------------------------------------------\r\n");
                            stream.Flush();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
