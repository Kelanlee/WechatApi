using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using Services.Interface;
using Services;
namespace WeixinWebApi.Controllers
{
    public class WechatController : ApiController
    {
        

        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/default1/5
        public void Get()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var isValid = ConfigurationManager.AppSettings["IsValid"];
            if (isValid.ToLower() == "true")
                Valid(context);
        }

        // POST api/default1
        public void Post()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            if (context.Request.HttpMethod.ToLower() == "post")
            {
                System.IO.Stream s = context.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b,0,(int)s.Length);
                var postStr = System.Text.Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    responseMsg(postStr,context);
                }

            }
            
        }


        private void Valid(HttpContextBase context)
        {


            try
            {
                string signature = context.Request["signature"].ToString();
                string timestamp = context.Request["timestamp"].ToString();
                string nonce = context.Request["nonce"].ToString();
                string echostr = context.Request["echostr"].ToString();
                string token = "12345";
                string[] arr = { token, timestamp, nonce };
                Array.Sort(arr);
                string tmpStr = string.Join("", arr);
                tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
                tmpStr = tmpStr.ToLower();
                if (tmpStr == signature)
                {
                    context.Response.Write(echostr);
                    context.Response.End();
                }
            }
            catch (Exception e)
            {

                context.Response.Write("Your request is wrong.");
                context.Response.End();
            }


        }
        private void responseMsg(string postStr, HttpContextBase context)
        {
            XmlDocument postXml = new XmlDocument();
            postXml.LoadXml(postStr);
            IMessageSevices ms=new MessageSevices();
            
            context.Response.Write(ms.ReplyMessage(postXml));
            context.Response.End();
        }
    }
}
