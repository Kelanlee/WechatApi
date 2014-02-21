using System;
using System.Collections.Generic;
using System.Linq;
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
                case MessageType.text:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[" + msg.Content + "]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.image:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.voice:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.video:
                    
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                break;
                case MessageType.location:
                return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
            "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
            "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
            "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
                case MessageType.link:
                    return "<xml><ToUserName><![CDATA[" + msg.FromUserName + "]]></ToUserName>" +
                "<FromUserName><![CDATA[" + msg.ToUserName + "]]></FromUserName>" +
                "<CreateTime>" + 12 + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
                "<Content><![CDATA[我只看懂文字，SB。]]></Content><FuncFlag>0</FuncFlag></xml> ";
                    break;
            }



            return "";
        }


    }

    
}
