using EIDSS.FlexibleForms.DataBase;
namespace EIDSS.FlexibleForms.Helpers
{
    /// <summary>
    /// Хранилище данных при копировании пользовательских данных
    /// </summary>
    public class ActivityParametersBuffer
    {
        /// <summary>
        /// 
        /// </summary>
        public ActivityParametersBuffer()
        {
            UserDataBuffer = new FlexibleFormsDS.ActivityParametersRow[] { };
        }

        /// <summary>
        /// 
        /// </summary>
        public object IdfsFormTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object IdfsObservation { get; set; }

        /// <summary>
        /// Буфер для хранения строк данных при копировании
        /// </summary>
        public FlexibleFormsDS.ActivityParametersRow[] UserDataBuffer { get; set; }

        /// <summary>
        /// Очистка буфера
        /// </summary>
        public void Clear()
        {
            IdfsFormTemplate = IdfsObservation = null;
            UserDataBuffer = new FlexibleFormsDS.ActivityParametersRow[]{};
        }

        /// <summary>
        /// Пуст ли буфер
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return ((IdfsFormTemplate == null) || (IdfsObservation == null) || (UserDataBuffer.Length == 0));
        }
    }
}