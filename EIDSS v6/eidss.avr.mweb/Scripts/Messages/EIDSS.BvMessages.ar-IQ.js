var EIDSS = {
	BvMessages: {

		'bntHideSearch': 'إخفاء البحث',
		'bntShowSearch': 'إظهار البحث',
		'btnClear': 'مسح محتويات الحقل',
		'btnHideErrDetail': 'إخفاء التفاصيل',
		'btnSelect': 'تحديد',
		'btnShowErrDetail': 'إظهار التفاصيل',
		'btnView': 'عرض',
		'strSave_Id': 'حفظ',
		'tooltipSave_Id': 'حفظ',
		'strClose_Id': 'إغلاق',
		'strRefresh_Id': 'تحديث',
		'tooltipRefresh_Id': 'تحديث',
		'strCreate_Id': 'جديد',
		'tooltipCreate_Id': 'جديد',
		'strEdit_Id': 'تحرير',
		'tooltipEdit_Id': 'تحرير',
		'Confirmation': 'تأكيد',
		'Delete Record': 'حذف السجل',
		'ErrAuthentication': 'الطلب يحتاج إلى مصادقة المستخدم.',
		'ErrDatabase': 'حدث خطأ أثناء عملية قاعدة البيانات.',
		'errDatabaseNotFound': 'لا يمكن فتح قاعدة البيانات \'{0}\' على الملقم \'{1}\' تحقق من صحة اسم قاعدة البيانات.',
		'ErrDataValidation': 'حقل يحتوي على بيانات غير صالحة.',
		'ErrEmptyUserLogin': 'لا يمكن أن يكون تسجيل دخول اسم المستخدم فارغا',
		'ErrFieldSampleIDNotFound': 'تعثر العثور على العينة.',
		'ErrFillDataset': 'خطأ أثناء استرداد البيانات من قاعدة البيانات.',
		'ErrFilterValidatioError': 'لا يمكن أن تكون قيمة معاير عامل التصفية [{0}] فارغة.',
		'errGeneralNetworkError': 'لا يمكن إنشاء اتصال بخادم SQL. الرجاء التأكد من إنشاء الاتصال بالشبكة ومحاولة فتح هذا النموذج من جديد.',
		'ErrIncorrectDatabaseVersion': 'إصدار قاعدة البيانات غير موجودة أو موجودة بتنسيق خاطئ. يرجى تحديث قاعدة البيانات لديك للحصول على أحدث إصدار قاعدة بيانات.',
		'errInvailidSiteID': 'خطأ في معرِّف الموقع أو في الرقم التسلسلي',
		'errInvailidSiteType': 'خطأ في نوع الموقع أو في الرقم التسلسلي',
		'ErrInvalidFieldFormat': 'تنسيق البيانات غير صالح لحقل \'{0}\'.',
		'ErrInvalidLogin': 'لا يمكن الاتصال بخادم SQL. هناك خطأ في اسم المستخدم أو كلمة المرور الخاصة بقاعدة البيانات.',
		'ErrInvalidParameter': 'تم إرسال قيمة غير صالحة إلى معلمة أمر SQL.',
		'errInvalidSearchCriteria': 'معايير بحث غير صالحة.',
		'ErrLocalFieldSampleIDNotFound': 'لم يتم العثور في الشبكة على معرف العينة المحلية/الحقلية.',
		'ErrLoginIsLocked': 'لقد تجاوزت عدد محاولات تسجيل الدخول الخاطئة. يرجى المحاولة مرة أخرى بعد {0} دقيقة (دقائق).',
		'ErrLowClientVersion': 'إصدار التطبيق لا يتوافق مع إصدار قاعدة بيانات. الرجاء تثبيت إصدار التطبيق الأحدث.',
		'ErrLowDatabaseVersion': 'يتطلب التطبيق أحدث إصدار لقاعدة البيانات. يرجى تحديث قاعدة البيانات لديك إلى أحدث إصدار قاعدة بيانات.',
		'ErrMandatoryFieldRequired': 'الحقل \'{0}\' إلزامي. يجب عليك إدخال البيانات في هذا الحقل قبل حفظ النموذج.',
		'errNoFreeLocation': 'لا يوجد مكان شاغر في الموقع المقصود',
		'ErrOldPassword': 'كلمة المرور القديمة (الحالية) غير صحيحة. لم يتم تغيير كلمة المرور.',
		'Error': 'خطأ',
		'ErrPasswordExpired': 'انتهت مدة صلاحية كلمة المرور الخاصة بك. الرجاء تغيير كلمة المرور.',
		'ErrPasswordPolicy': 'تعذر تحديث كلمة المرور. القيمة المتوفرة في كلمة المرور الجديدة لا تفي بشروط الطول أو التعقيد أو التاريخ.',
		'ErrPost': 'حدث خطأ أثناء حفط البيانات في قاعدة البيانات.',
		'errSampleInTransfer': 'العينة "{0}" مدرجة مسبقاً في نقل "{1}"',
		'errSQLLoginError': 'لا يمكن الاتصال بخادم SQL. تحقق من صحة معلمات اتصال SQL في علامة تبويب خادم SQL أو إمكانية الدخول إلى خادم SQL.',
		'ErrSqlQuery': 'حدث خطأ أثناء تنفيذ استعلام SQL.',
		'errSqlServerDoesntExist': 'لا يمكن الاتصال بخادم SQL. يرجى التأكد من إنشاء الاتصال مع الشبكة وعدم توقف خادم SQL عن العمل، ثم حاول فتح هذا النموذج مرة أخرى.',
		'errSqlServerNotFound': 'لا يمكن الاتصال بخادم SQL \'{0}\' تحقق من صحة اسم خادم SQL أو إمكانية الدخول إلى خادم SQL.',
		'ErrStoredProcedure': 'حدث خطأ أثناء تنفيذ إجراء قاعدة البيانات المخزنة.',
		'ErrUndefinedStdError': 'بعض الخطأ يحدث في التطبيق. الرجاء إرسال معلومات حول هذا الخطأ لفريق تطوير البرمجيات.',
		'errUnknownError': 'حدث خطأ في التطبيق',
		'ErrUnprocessedError': 'بعض الخطأ يحدث في التطبيق. الرجاء إرسال معلومات حول هذا الخطأ لفريق تطوير البرمجيات.',
		'ErrUserNotFound': 'هناك خطأ في اسم المستخدم أو كلمة المرور.',
		'ErrWebTemporarilyUnavailableFunction': 'ErrWebTemporarilyUnavailableFunction',
		'Message': 'الرسالة',
		'msgCancel': 'سيتم فقدان جميع البيانات التي تم إدخالها. تود المتابعة؟',
		'msgCantDeleteRecord': 'لا يمكن حذف السجل',
		'msgClearControl': 'اضغط على Ctrl-Del لمسح القيمة.',
		'msgConfimation': 'تأكيد',
		'msgConfirmClearFlexForm': 'مسح محتوى اللوحة؟',
		'msgConfirmClearLookup': 'مسح المحتوى؟',
		'msgDeletePrompt': 'سيتم حذف الكائن. تود حذف الكائن؟',
		'msgDeleteRecordPrompt': 'سيتم حذف السجل (السجلات). تود الحذف؟',
		'msgCancelPrompt': 'هل ترغب في إلغاء كل التغييرات وإغلاق النموذج؟',
		'msgSavePrompt': 'هل تريد حفظ التغييرات؟',
		'msgOKPrompt': 'هل تريد حفظ التغييرات وإغلاق النموذج؟',
		'msgEIDSSCopyright': 'حقوق النشر محفوظة © 2005-2013 بلاك آند فيتِك سبيشِل بروجيكتس كورب/Black && Veatch Special Projects Corp.',
		'msgEIDSSRunning': 'لا يمكنك تشغيل مثيلات متعددة من النظام الإلكتروني المتكامل لمراقبة الأمراض في نفس الوقت. هناك مثيل آخر للنظام الإلكتروني المتكامل لمراقبة الأمراض قيد التشغيل بالفعل',
		'msgEmptyLogin': 'لم يتم تحديد تسجيل الدخول',
		'msgMessage': 'الرسالة',
		'msgNoDeletePermission': 'لا يوجد لديك الحق في حذف هذا الكائن',
		'msgNoFreeSpace': 'لا يوجد مساحة متبقية في الموقع.',
		'msgNoInsertPermission': 'لا يحق لك إنشاء هذا الكائن',
		'msgNoRecordsFound': 'تعذر العثور على أي سجلات لمعايير البحث الحالية.',
		'msgNoSelectPermission': 'لا يحق لك عرض هذا النموذج',
		'msgParameterAlreadyExists': 'الحقل موجود مسبقاً',
		'msgPasswordChanged': 'تم تغيير كلمة المرور الخاصة بك بنجاح',
		'msgPasswordNotTheSame': 'يجب أن تتطابق كلمة المرور الجديدة وكلمة المرور المؤكدة',
		'msgReasonEmpty': 'يرجى إدخال سبب التغير',
		'msgReplicationPrompt': 'هل تود بدء النسخ المتماثل لنقل البيانات على مواقع أخرى؟',
		'msgREplicationPromptCaption': 'تأكيد النسخ المتماثل',
		'msgWaitFormCaption': 'يرجى الانتظار',
		'msgFormLoading': 'جاري تحميل النموذج',
		'msgWrongDiagnosis': 'يجب ان يختلف التشخيص المتغير ({0}) عن التشخيص الأولي ({1}).',
		'Save data?': 'هل تريد حفظ البيانات؟',
		'Warning': 'رسالة تحذير',
		'SecurityLog_EIDSS_finished_successfully': 'انتهى النظام الالكتروني المتكامل لمراقبة الأمراض بنجاح',
		'SecurityLog_EIDSS_started_abnormaly': 'بدأ تشغيل النظام الالكتروني المتكامل لمراقبة الأمراض بشكل غير عادي',
		'SecurityLog_EIDSS_started_successfully': 'بدأ تشغيل النظام الالكتروني المتكامل لمراقبة الأمراض بنجاح',
		'strCancel_Id': 'إلغاء',
		'strChangeDiagnosisReason_msgId': 'السبب مطلوب.',
		'strDelete_Id': 'حذف',
		'strOK_Id': 'موافق',
		'tooltipCancel_Id': 'إلغاء',
		'tooltipClose_Id': 'إغلاق',
		'tooltipDelete_Id': 'حذف',
		'tooltipOK_Id': 'موافق',
		'titleAccessionDetails': 'تفاصيل الإضافة',
		'titleAntibiotic': 'مضاد حيوي',
		'titleContactInformation': 'التفاصيل ومعلومات الاتصال المتعلقة بالشخص',
		'titleDiagnosisChange': 'تغيير التشخيص',
		'titleDuplicates': 'تكرارات',
		'titleEmployeeDetails': 'تفاصيل عن الموظف',
		'titleEmployeeList': 'قائمة العاملين',
		'titleGeoLocation': 'الموقع الجغرافي',
		'titleHumanCaseList': 'قائمة حالات بشرية',
		'titleOrganizationList': 'قائمة المنظمات',
		'titleOutbreakList': 'قائمة التفشي',
		'titlePersonsList': 'قائمة الأشخاص',
		'titleFarmList': 'titleFarmList',
		'titleTestResultChange': 'تغيير نتيجة الاختبار',
		'titleSampleDetails': 'تفاصيل العينة',
		'titleOutbreakNote': 'titleOutbreakNote',
		'errLoginMandatoryFields': 'كافة الحقول إلزامية.',
		'msgAddToPreferencesPrompt': 'سيتم إضافة السجلات المحددة إلى التفضيلات.',
		'msgRemoveFromPreferencesPrompt': 'ستتم إزالة السجلات المحددة من التفضيلات.',
		'strAdd_Id': 'إضافة',
		'strRemove_Id': 'إزالة',
		'titleResultSummary': 'ملخص النتائج والتفسير',
		'titleVeterinaryCaseList': 'قائمة الحالات البيطرية',
		'titleVSSessionList': 'titleVSSessionList',
		'titlePensideTest': 'اختبار سريع',
		'titleTestDetails': 'تفاصيل الاختبار',
		'titleASSessionList': 'قائمة فترات المراقبة النشطة',
		'titleTestResultDetails': 'تفاصيل نتيجة الاختبار',
		'ErrObjectCantBeDeleted': 'لا يمكن حذف الكائن.',
		'titleVaccination': 'تلقيح',
		'msgAsSessionNoCaseCreated': 'لا توجد عينات إيجابية.',
		'strYes_Id': 'نعم',
		'strNo_Id': 'لا',
		'titleClinicalSigns': 'علامات سريرية',
		'LastName': 'الأخير',
		'FirstName': 'الأول',
		'MiddleName': 'وسط',
		'AsCampaign_GetSessionRemovalConfirmation': 'هل تريد فعلاً إزالة الارتباط بالجلسة المحددة؟',
		'titleSelectFarm': 'قائمة المزارع',
		'Info': 'Info',
		'strSearchPanelMandatoryFields_msgId': 'يرجى إملاء كافة الحقول الإلزامية في لوحة البحث.',
		'menuCreateAliquot': 'إنشاء قاسم',
		'menuCreateDerivative': 'إنشاء مشتقات',
		'menuTransferOutSample': 'نقل عينة للخارج',
		'menuAccessionInPoorCondition': 'مقبول بحالة سيئة',
		'menuAccessionInRejected': 'مرفوض',
		'menuAmendTestResult': 'تعديل نتيجة الاختبار',
		'menuAssignTest': 'تعيين اختبار',
		'titleAnimal': 'titleAnimal',
		'btShowCustomizationWindow': 'إظهار نافذة التخصيص',
		'btHideCustomizationWindow': 'إخفاء نافذة التخصيص'
	}
}
