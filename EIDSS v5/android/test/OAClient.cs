using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;

/*
 "C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\SvcUtil" http://localhost:1587/EIDSSService.asmx?WSDL /out:C:\Work\sources\TFSVM\EIDSS\EIDSS_V4\DevelopersBranch_V5\android\OAClient\OAProxy.cs
*/

namespace bv.com.eidss
{
    public class OAClient
    {
        private EidssServiceSoapClient m_proxy;
        public OAClient(string url)
        {
            //var binding = new WebHttpBinding(WebHttpSecurityMode.None);
            var binding = new CustomBinding();
            //binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8));
            binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
            //binding.Elements.Add(new WebMessageEncodingBindingElement(Encoding.UTF8));
            var transport = url.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                                ? new HttpsTransportBindingElement()
                                : new HttpTransportBindingElement();
            binding.Elements.Add(transport);
            var endpoint = new EndpointAddress(url);
            m_proxy = new EidssServiceSoapClient(binding, endpoint);
            //m_proxy.Endpoint.Behaviors.Add(new WebHttpBehavior()); 
        }

        public EidssServiceSoapClient Proxy { get { return m_proxy; } }
    }
}

