using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

using Android.Content;

/*
 "C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\SvcUtil" http://192.168.10.34:8080/EIDSSService.asmx?WSDL /out:C:\Work\sources\TFSVM\EIDSS\EIDSS_V4\DevelopersBranch_V5\android\OAClient\OAProxy.cs
*/

namespace bv.com.eidss
{

    public class OAClient
    {
        private EidssServiceSoapClient m_proxy;
        public OAClient(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            var binding = new CustomBinding();
            binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
            var transport = url.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                                ? new HttpsTransportBindingElement()
                                : new HttpTransportBindingElement();
            binding.Elements.Add(transport);
            var endpoint = new EndpointAddress(url);
            m_proxy = new EidssServiceSoapClient(binding, endpoint);
        }

        public EidssServiceSoapClient Proxy { get { return m_proxy; } }
    }


    public partial class BaseReferenceRaw
    {
        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("idfsBaseReference", idfsBaseReference);
            ret.Put("idfsReferenceType", idfsReferenceType);
            ret.Put("intHACode", intHACode);
            ret.Put("strDefault", strDefault);
            return ret;
        }
        #endregion
    }

    public partial class GisBaseReferenceRaw
    {
        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("idfsBaseReference", idfsBaseReference);
            ret.Put("idfsReferenceType", idfsReferenceType);
            ret.Put("idfsCountry", idfsCountry);
            ret.Put("idfsRegion", idfsRegion);
            ret.Put("idfsRayon", idfsRayon);
            ret.Put("strDefault", strDefault);
            return ret;
        }
        #endregion
    }

    public partial class BaseReferenceTranslationRaw
    {
        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("idfsBaseReference", idfsBaseReference);
            ret.Put("strTranslation", strTranslation);
            ret.Put("strLanguage", strLanguage);
            return ret;
        }
        #endregion
    }

    public partial class GisBaseReferenceTranslationRaw
    {
        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("idfsBaseReference", idfsBaseReference);
            ret.Put("strTranslation", strTranslation);
            ret.Put("strLanguage", strLanguage);
            return ret;
        }
        #endregion
    }

}
