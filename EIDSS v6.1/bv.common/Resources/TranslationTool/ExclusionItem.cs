namespace bv.common.Resources.TranslationTool
{
    public enum ExclusionSource
    {
        Xml,
        MenuAction
    }
    public class ExclusionItem
    {
        public CommonResource Resource { get; set; }
        public string[] Keys { get; set; }
        public bool Disabled { get; set; }
        public ExclusionSource Source { get; set; } //Used to differ static exclusions described in xml from dynamic exclusions like MenuAction
                                                    //Dynamic exclusions can be reloaded during form loading
    }
}
