namespace bv.winclient.Core
{
    public enum WaitDialogType
    {
        None,
        FormLoading, //msgWaitFormCaption,msgFormLoading
        MapInitializing,//msgPleaseWait, msgMapInitializing
        AvrExecutingQuery,//msgPleaseWait, msgAvrExecutingQuery
        AvrExecutingArchiveQuery,//msgPleaseWait, msgAvrExecutingArchiveQuery
        AvrServiceReceiveQuery,//msgPleaseWait, msgAvrServiceReceiveQuery
        BarcodeInitializing,//msgPleaseWait, msgBarcodeInitializing
        ReportInitializing,//msgPleaseWait, msgReportInitializing
        ReportRendering,//msgPleaseWait, msgReportRendering
        FormSaving//msgPleaseWait, msgFormSaving
    }
}
