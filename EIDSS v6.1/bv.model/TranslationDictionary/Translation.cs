
namespace bv.model.TranslationDictionary
{
    public class Translation
    {
        #region Constructors
        public Translation()
        {
        }

        public Translation(string language, string text)
        {
            Text = text;
            Language = language;
            Dict = false;
        }

        public Translation(string language, string text, bool dict)
        {
            Text = text;
            Language = language;
            Dict = dict;
        }
        #endregion

      public string Text
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }

        public bool Dict
        {
            get;
            set;
        }
    }
}
