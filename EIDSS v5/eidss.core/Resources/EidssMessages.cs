using bv.common.Resources;
using bv.common.Core;
using bv.model.Model.Core;
using bv.model.Model.Validators;



namespace eidss.model.Resources
{
    public class EidssMessages : BaseStringsStorage
    {
        private volatile static EidssMessages m_Instance;
        private static object syncRoot = new object();
        private EidssMessages() { }
        public override string ResourcePath
        {
            get { return m_ResFileName ?? (m_ResFileName = Utils.GetSolutionPath() + "eidss.model\\resources\\" + GetType().Name + ".resx"); }
        }

        public static EidssMessages Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new EidssMessages();
                    }
                }

                return m_Instance;
            }
        }
        public static string Get(string stringName, string stringValue = null, string CultureName = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, CultureName);
        }

        public static string GetForCurrentLang(string stringName, string stringValue = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, ModelUserContext.CurrentLanguage);
        }

        public static string GetValidationErrorMessage(ValidationEventArgs args, string cultureName = null)
        {
            if (args.Type == typeof(RequiredValidator))
                return string.Format(Instance.GetString("ErrMandatoryFieldRequired", null, cultureName), EidssFields.Get(args.PropertyName, null, cultureName)); 
            
            return Instance.GetString(args.MessageId, args.MessageId, cultureName);                    
        }

        public static string GetValidationErrorMessage(ValidationModelException error, string cultureName = null)
        {
            if (error.ValidatorType == typeof(RequiredValidator))
                return string.Format(Instance.GetString("ErrMandatoryFieldRequired"), EidssFields.Get(error.PropertyName, null));

            return Instance.GetString(error.MessageId, error.MessageId, cultureName);
        }

    }
	
	
}
