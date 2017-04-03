using System;

namespace EIDSS.FlexibleForms.Helpers
{
    public static class ErrorHelper
    {
        /// <summary>
        /// ќпредел€ет, €вл€етс€ ли переданное сообщение специальным информативным
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsEIDSSError(string message)
        {
            //??? - сто€т в начале любого информативного сообщени€, которое кидаетс€ хр. проц. spThrowException
            return ((message.Length > 3) && (message.Substring(0, 3).Equals("???")));
        }

        /// <summary>
        /// ѕолучает насто€щий текст сообщени€, очища€ его от служебных символов
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetMessageString(string message)
        {
            string result = String.Empty;
            if (IsEIDSSError(message))
            {
                //находим вторую служебную подстроку
                int index = message.IndexOf("???",3,StringComparison.OrdinalIgnoreCase);
                result = message.Substring(3, index - 3);
            }

            return result;
        }
    }
}
