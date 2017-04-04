using System.Collections.Generic;


namespace bv.model.TranslationDictionary
{
    public class Word
    {
        #region Constructors
        public Word()
        {
            Translations = new List<Translation>();
        }

        public Word(string key)
        {
            Translations = new List<Translation>();
            Key = key;
        }

        public Word(string key, string comment)
        {
            Translations = new List<Translation>();
            Key = key;
            Comment = comment;
        }
        #endregion

        #region Properties
        public string Key
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public List<Translation> Translations
        {
            get;
            set;
        }
        #endregion

        public string GetDictionaryTranslation(string lang)
        {
            Translation tr = Translations.Find(p => p.Dict == true && p.Language == lang);
            if (tr == null)
                return null;
            else
                return tr.Text;
        }

        public List<string> GetNotDictionaryTranslations(string lang)
        {
            List<string> ret = new List<string>();
            var trs = Translations.FindAll(p => p.Dict == false && p.Language == lang);
            foreach (Translation ttt in trs)
            {
                ret.Add(ttt.Text);
            }
            return ret;
        }
    }
}
