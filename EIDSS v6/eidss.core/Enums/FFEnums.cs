namespace eidss.model.Enums
{
    public enum FFEditModes : long
    {
        Ordinary = 10068001,
        ReadOnly = 10068002,
        Required = 10068003
    }

    public enum FFRuleFunctions : long
    {
        CurrentDate = 10031001  //{0} <= CurrentDate
        ,
        GreaterEqual = 10031002 //{0} >= {1}
            ,
        Greater = 10031003  //{0} > {1}
            ,
        Empty = 10031004  //{0} is Empty
            , Value = 10031005  //{0} is Value
    }

    public enum FFParameterTypes : long
    {
        Boolean = 10071025
        ,
        Numeric = 10071007
            ,
        NumericNatural = 10071059
            ,
        NumericPositive = 10071060
            ,
        NumericInteger = 10071061
            ,
        String = 10071045
            ,
        DateTime = 10071030
            , Date = 10071029
    }
    public enum FFDecorElementTypes : long
    {
        Line = 10106002
        , Label = 10106001
    }

    public enum FFDeterminantTypes : long
    {
        Country = 19000001
        ,
        Diagnosis = 19000019
            , Test = 19000097
    }
    public enum FFRuleCheckPointType : long
    {
        OnLoad = 10028001
        ,
        OnSaveWithNotify = 10028002
            ,
        OnSaveWithError = 10028004
            , OnValueChanged = 10028003
    }

    public enum FFRuleActions : long
    {
        Clear = 10030001
        , Disabled = 10030002
    }

    public enum FFParameterEditors : long
    {
        TextBox = 0
        ,
        ComboBox = 1
            ,
        CheckBox = 2
            ,
        Date = 3
            ,
        DateTime = 4
            ,
        Memo = 5
            , UpDown = 6
    }

    public enum FFParameterScheme : long
    {
        Left = 0
        ,
        Right = 1
            ,
        Top = 2
            , Bottom = 3
    }
}
