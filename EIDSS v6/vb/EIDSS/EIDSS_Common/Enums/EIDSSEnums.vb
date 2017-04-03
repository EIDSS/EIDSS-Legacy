Public Delegate Sub SetDataView(ByVal view As DataView)
Public Delegate Sub ValueChanging(ByVal newValue As Object, ByVal oldValue As Object, ByRef Cancel As Boolean)
Public Delegate Sub ValueChanged(ByVal newValue As Object)


Public Enum SiteType
    Undefined = 0
    CDR = 10085001
    EMS = 10085002
    GDR = 10085003
    TRV = 10085004
    PACS = 10085005
    ProxyEMS = 10085006
    SS = 10085007
End Enum

Public Enum ModuleType
    Human
    VET
    LIMS
End Enum


'Public Enum NotificationType
'    notEmptyRequest
'    notVetCase
'    notNewSiteNumberRange
'    notActivationRequest
'    notActivationCode
'    notNotificationPasswordRequest
'    notOutbreak
'    notHumanCase
'    notCaseStatusChanged
'    notCaseDiagnosisChanged
'    notTestResult
'    notLookupTableChanged
'End Enum


<Flags()> _
Public Enum HACode
    None = 0
    Reserved = 1
    Human = 2
    Livestock = 32
    Avian = 64
    Vector = 128
    Syndromic = 256
    All = &HFFFFFFFF
End Enum
