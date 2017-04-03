using System.Drawing;

namespace bv.common.Resources.Images
{
    public class ImagesStorage : BaseImagesStorage
    {
        private static ImagesStorage m_Instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Image Get(string key)
        {
            if (m_Instance == null)
            {
                m_Instance = new ImagesStorage();
            }
            return m_Instance.GetImage(key);
        }
    }
}
