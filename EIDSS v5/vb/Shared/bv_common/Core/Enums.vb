
''' -----------------------------------------------------------------------------
''' <summary>
''' Lists all business logic form states used by the system.
''' </summary>
''' <remarks>
''' <i>BusinessObjectState</i> is used by descendent of BaseForm class to identify current state of business object related with the form.
''' The business object can have several <i>BusinessObjectState</i> flags set simultaneously.
''' </remarks>
''' <history>
''' 	[Mike]	27.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Flags()> _
Public Enum BusinessObjectState
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines the state for read-only business object
    ''' </summary>
    ''' <remarks>
    ''' This state is assigned to all list forms
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    None = 0
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies new business object that was created and not saved to database yet.
    ''' </summary>
    ''' <remarks>
    ''' After any saving object to database this flag is cleared automatically.
    ''' There are intermediate savings that occur if some child object 
    ''' should be created for new object in the separate form. 
    ''' After intermediate saving this flag is cleared too.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    NewObject = 1
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies new business object even if it was saved to database in the intermediate state.
    ''' </summary>
    ''' <remarks>
    ''' This flag is cleared only after final saving of new object to database.
    ''' Intermediate savings that occur during child objects creation doesn't change this flag.
    ''' If object creation is cancelled all intermediate records in database should be deleted.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    IntermediateObject = 2
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies the existing business object that was loaded for editing to detail form.
    ''' </summary>
    ''' <remarks>
    ''' This flag is set for the existing objects only.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    EditObject = 4
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies the list form that was called for object selection.
    ''' </summary>
    ''' <remarks>
    '''
    '''     ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    SelectObject = 8

End Enum
''' -----------------------------------------------------------------------------
''' <summary>
''' Defines the type of the data posting raised by <i>BaseDbService.Post</i> method
''' </summary>
''' <remarks>
''' The <i>FinalPosting</i> flag is passed to the <i>BaseDbService.Post</i> method 
''' when user press OK button on the detail form. 
''' Use <i>IntermediatePosting</i> flag to save data in the intermediate state before child object creation.
''' <i>PerformAdditionalPosting</i> flag can be used to inform <i>BaseDbService.Post</i> method that some additional actions should be applied to business object except standard data saving.
''' </remarks>
''' <history>
''' 	[Mike]	27.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Flags()> _
Public Enum PostType
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies that object is saved to database in the intermediate state.
    ''' </summary>
    ''' <remarks>
    ''' Usually this flag is used to save data in the intermediate state before child object creation.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    IntermediatePosting = 1
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identifies that the object is saved to database in its final state.
    ''' </summary>
    ''' <remarks>
    ''' Usually the <i>FinalPosting</i> flag is passed to the <i>BaseDbService.Post</i> method 
    ''' when user press OK button on the detail form. 
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    FinalPosting = 2
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Informs <i>BaseDbService.Post</i> method that some additional actions should be performed with the saved object.
    ''' </summary>
    ''' <remarks>
    ''' Use this flag if there is some non standard action that requires not only object saving but performing some additional action too.
    ''' Usually this flag is passed to the <i>BaseDbService.Post</i> method when some special button on the Form is pressed.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    PerformAdditionalPosting = 4
End Enum
<Flags()> _
Public Enum BaseFormType
    None = 0
    List = 1
    DetailForm = 2
    DetailList = 4
    DetailPanel = 8
    LookupForm = 16
    ReportForm = 32
End Enum

Public Enum RelatedPostOrder
    <Xml.Serialization.XmlEnum("RootPost")> RootPost
    <Xml.Serialization.XmlEnum("SkipPost")> SkipPost
    <Xml.Serialization.XmlEnum("PostFirst")> PostFirst
    <Xml.Serialization.XmlEnum("PostLast")> PostLast
    <Xml.Serialization.XmlEnum("PostInstead")> PostInstead
End Enum

<Flags()> _
Public Enum ControlState
    Normal = 0
    [ReadOnly] = 1
    Mandatory = 2
    KeyField = 4
    Barcode = 8
End Enum

Public Enum FFEditModes
    Ordinary = 10068001
    [ReadOnly] = 10068002
    Required = 10068003
End Enum

Public Enum FFRuleFunctions
    CurrentDate = 10031001  '{0} <= CurrentDate
    GreaterEqual = 10031002 '{0} >= {1}
    Greater = 10031003  '{0} > {1}
    [Empty] = 10031004  '{0} is Empty
    [Value] = 10031005  '{0} is Value
End Enum

Public Enum FFParameterTypes
    [Boolean] = 10071025
    [Numeric] = 10071007
    [NumericNatural] = 10071059
    [NumericPositive] = 10071060
    [NumericInteger] = 10071061
    [String] = 10071045
    DateTime = 10071030
    [Date] = 10071029
End Enum
Public Enum FFDecorElementTypes
    [Line] = 10106002
    [Label] = 10106001
End Enum
Public Enum FFDeterminantTypes
    [Country] = 19000001
    [Diagnosis] = 19000019
    [Test] = 19000097
    [VectorType] = 19000140
End Enum
Public Enum FFRuleCheckPointType
    OnLoad = 10028001
    OnSaveWithNotify = 10028002
    OnSaveWithError = 10028004
    OnValueChanged = 10028003
End Enum
Public Enum FFRuleActions
    Clear = 10030001
    Disabled = 10030002
End Enum
Public Enum FFParameterEditors
    TextBox = 0
    ComboBox = 1
    CheckBox = 2
    [Date] = 3
    DateTime = 4
    Memo = 5
    UpDown = 6
End Enum
Public Enum FFParameterScheme
    Left = 0
    Right = 1
    Top = 2
    Bottom = 3
End Enum
