using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using Services.Interface;
using Data;
namespace Services
{
    public class MessageSevices:IMessageSevices
    {
        public string ReplyMessage(XmlDocument xml)
        {
            Message msg=new Message(xml);
            var time = DateTime.Now;

            

            return GenerateReplyMessage(msg);
        }

        public string GenerateReplyMessage(Message msg)
        {
            switch (msg.MsgType)
            {
                case MessageType.Text:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[" + msg.Content + "]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.Image:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.Voice:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.Video:
                    
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                break;
                case MessageType.Location:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                    "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                    "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                    "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.Link:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.Event:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[收到事件]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
            }



            return "";
        }

        public bool GetToken()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx12fbe830a6d20310&secret=a0df30296549a907119d1845730ba48b");

            var response = request.GetResponse();
            System.IO.Stream s = response.GetResponseStream();
            byte[] postContext =new byte[response.ContentLength];
            s.Read(postContext, 0, (int)response.ContentLength);
            var context = System.Text.Encoding.UTF8.GetString(postContext); 
            return true;
        }

        public bool SendMessage(string openId,string content)
        {
            WebRequest request = WebRequest.Create("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=zwUlVqgocJgw8E4E4z2If-STKcTl__RjsnnUckW_DrMjyKUiRSgOP4sl8f2bBZzKzD3vKXQj24bQc4c0nUDWj1UChPSqEJHtm4Te8dJ4yMXJvaj2HOqfKxFAw_ksvXaB0T5j0IojXN5I06RM3TK0Lw");

            request.Method = "POST";
            string context = "{\"touser\":\"" + openId + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}";
            var date = Encoding.UTF8.GetBytes(context);
            request.GetRequestStream().Write(date,0,date.Length);
            var response = request.GetResponse();
            System.IO.Stream s = response.GetResponseStream();
            byte[] postContext = new byte[response.ContentLength];
            s.Read(postContext, 0, (int)response.ContentLength);
            var responseContext = System.Text.Encoding.UTF8.GetString(postContext); 

            return true;
        }

        public bool SetMenu()
        {
            WebRequest request =
                WebRequest.Create(
                    "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=zwUlVqgocJgw8E4E4z2If-STKcTl__RjsnnUckW_DrMjyKUiRSgOP4sl8f2bBZzKzD3vKXQj24bQc4c0nUDWj1UChPSqEJHtm4Te8dJ4yMXJvaj2HOqfKxFAw_ksvXaB0T5j0IojXN5I06RM3TK0Lw");

            request.Method = "POST";

            string context = "{\"button\":[{\"type\":\"click\",\"name\":\"你是SB\",\"key\":\"你是SB\"},{\"type\":\"click\",\"name\":\"我是SB\",\"key\":\"我是SB\"},{\"name\":\"菜单\",\"sub_button\":[{	\"type\":\"view\",\"name\":\"baidu\",\"url\":\"http://www.baidu.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com/\"},{\"type\":\"click\",\"name\":\"赞一个\",\"key\":\"赞一个\"}]}]}";
            var data = Encoding.UTF8.GetBytes(context);
            request.GetRequestStream().Write(data, 0, data.Length);
            var response = request.GetResponse();
            System.IO.Stream s = response.GetResponseStream();
            byte[] postContext = new byte[response.ContentLength];
            s.Read(postContext, 0, (int)response.ContentLength);
            var responseContext = System.Text.Encoding.UTF8.GetString(postContext);
            return true;
        }
    }

    
}
