using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace WeixinWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private HttpContextBase context;
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public string Post([FromBody] string value)
        {
            context = (HttpContextBase) Request.Properties["MS_HttpContext"];
            var isValid = ConfigurationManager.AppSettings["IsValid"];
            if (isValid.ToLower() == "true")
                Valid();
            if (context.Request.HttpMethod.ToLower() == "post")
            {
                System.IO.Stream s = context.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int) s.Length);
                var postStr = System.Text.Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    responseMsg(postStr);
                }
                return postStr;
            }
            return null;
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        

        
        public void Get()
        {
             context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var isValid = ConfigurationManager.AppSettings["IsValid"];
            if(isValid.ToLower()=="true")
                 Valid();
            //if (context.Request.HttpMethod.ToLower() == "post")
            //{
                System.IO.Stream s = context.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int) s.Length);
                var postStr = System.Text.Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    responseMsg(postStr);
                }
            //}

        }

        

        public void Valid()
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


        public void responseMsg(string postStr)
        {
            XmlDocument postXml=new XmlDocument();
            postXml.LoadXml(postStr);
            var FromUserNameList = postXml.GetElementsByTagName("FromUserName");
            string FromUserName = string.Empty;
            for (int i = 0; i < FromUserNameList.Count; i++)
            {
                if (FromUserNameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    FromUserName = FromUserNameList[i].ChildNodes[0].Value;
                }
            }
            var toUsernameList = postXml.GetElementsByTagName("ToUserName");
            string ToUserName = string.Empty;
            for (int i = 0; i < toUsernameList.Count; i++)
            {
                if (toUsernameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    ToUserName = toUsernameList[i].ChildNodes[0].Value;
                }
            }
            var keywordList = postXml.GetElementsByTagName("Content");
            string Content = string.Empty;
            for (int i = 0; i < keywordList.Count; i++)
            {
                if (keywordList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Content = keywordList[i].ChildNodes[0].Value;
                }
            }
            var time = DateTime.Now;
            var textpl = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[欢迎来到微信世界---" + Content + "]]></Content><FuncFlag>0</FuncFlag></xml> ";
            context.Response.Write(textpl);
            context.Response.End();
        }
    }
}