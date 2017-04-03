<Flags()> _
Public Enum BaseReferenceKind
    None = 0
    ProcessedByTrigger = 1
    NotUsed = 2
    ShowInStandardEditor = 4
    DisableDeleting = 8
    DisableCreation = 16
    AllowTranslationOnly = 32
    RestricredAccess = ShowInStandardEditor Or DisableDeleting Or DisableCreation Or AllowTranslationOnly
End Enum
