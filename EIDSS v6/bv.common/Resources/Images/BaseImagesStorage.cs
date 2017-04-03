using System.Drawing;
using System.Reflection;
using System.Resources;
using bv.common.Core;

namespace bv.common.Resources.Images
{
    public class BaseImagesStorage
    {
        private string m_ResFileName;
        private ResourceManager m_ResourceManager;

        public virtual string ResourceName
        {
            get { return GetType().FullName; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Image GetImage(string key)
        {
            if (m_ResourceManager == null)
            {
                var mainAssembly = Assembly.GetExecutingAssembly();
                m_ResourceManager = new ResourceManager(ResourceName, mainAssembly);
            }

            var resource = key.Length > 0 ? m_ResourceManager.GetObject(key) : null;
            return resource as Image;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ResourcePath
        {
            get { return m_ResFileName ?? (m_ResFileName = Utils.GetExecutingPath() + GetType().FullName + ".resx"); }
        }
    }
}
