using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Data
{
    public class Message
    {
        //Public Data
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public MessageType MsgType { get; set; }
        public string MsgId { get; set; }
        
        //Test
        public string Content { get; set; }
        
        //image
        public string PicUrl { get; set; }
        public string MediaId { get; set; }

        //Voice Video
        public string Format { get; set; }
        public string ThumbMediaId { get; set; }

        //Location
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public string Scale { get; set; }
        public string Label { get; set; }

        //Link
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Message (XmlDocument xml)
        {

            var FromUserNameList = xml.GetElementsByTagName("FromUserName");
            for (int i = 0; i < FromUserNameList.Count; i++)
            {
                if (FromUserNameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    FromUserName = FromUserNameList[i].ChildNodes[0].Value;
                }
            }
            var toUsernameList = xml.GetElementsByTagName("ToUserName");
            for (int i = 0; i < toUsernameList.Count; i++)
            {
                if (toUsernameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    ToUserName = toUsernameList[i].ChildNodes[0].Value;
                }
            }
            CreateTime = 		xml.GetElementsByTagName("CreateTime")[0].InnerText;

            var MsgTypeList = xml.GetElementsByTagName("MsgType");
            for (int i = 0; i < MsgTypeList.Count; i++)
            {
                if (MsgTypeList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    MsgType = GetMessageType(MsgTypeList[i].ChildNodes[0].Value);
                }
            }

            var MsgIdData = xml.GetElementsByTagName("MsgId");
            if (MsgIdData.Count>0)
            {
                MsgId = xml.GetElementsByTagName("MsgId")[0].InnerText;
            }
            

            var ContentList = xml.GetElementsByTagName("Content");
            for (int i = 0; i < ContentList.Count; i++)
            {
                if (ContentList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Content = ContentList[i].ChildNodes[0].Value;
                }
            }


            var PicUrlList = xml.GetElementsByTagName("PicUrl");
            for (int i = 0; i < PicUrlList.Count; i++)
            {
                if (PicUrlList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    PicUrl = PicUrlList[i].ChildNodes[0].Value;
                }
            }

            var MediaIdList = xml.GetElementsByTagName("MediaId");
            for (int i = 0; i < MediaIdList.Count; i++)
            {
                if (MediaIdList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    MediaId = MediaIdList[i].ChildNodes[0].Value;
                }
            }


            var FormatList = xml.GetElementsByTagName("Format");
            for (int i = 0; i < FormatList.Count; i++)
            {
                if (FormatList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Format = FormatList[i].ChildNodes[0].Value;
                }
            }

            var ThumbMediaIdList = xml.GetElementsByTagName("ThumbMediaId");
            for (int i = 0; i < ThumbMediaIdList.Count; i++)
            {
                if (ThumbMediaIdList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    ThumbMediaId = ThumbMediaIdList[i].ChildNodes[0].Value;
                }
            }

            var Location_XList = xml.GetElementsByTagName("Location_X");
            for (int i = 0; i < Location_XList.Count; i++)
            {
                if (Location_XList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Location_X = Location_XList[i].ChildNodes[0].Value;
                }
            }

            var Location_YList = xml.GetElementsByTagName("Location_Y");
            for (int i = 0; i < Location_YList.Count; i++)
            {
                if (Location_YList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Location_Y = Location_YList[i].ChildNodes[0].Value;
                }
            }


            var ScaleList = xml.GetElementsByTagName("Scale");
            for (int i = 0; i < ScaleList.Count; i++)
            {
                if (ScaleList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Scale = ScaleList[i].ChildNodes[0].Value;
                }
            }

            var LabelList = xml.GetElementsByTagName("Label");
            for (int i = 0; i < LabelList.Count; i++)
            {
                if (LabelList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Label = LabelList[i].ChildNodes[0].Value;
                }
            }

            var TitleList = xml.GetElementsByTagName("Title");
            for (int i = 0; i < TitleList.Count; i++)
            {
                if (TitleList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Title = TitleList[i].ChildNodes[0].Value;
                }
            }
            var DescriptionList = xml.GetElementsByTagName("Description");
            for (int i = 0; i < DescriptionList.Count; i++)
            {
                if (DescriptionList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Description = DescriptionList[i].ChildNodes[0].Value;
                }
            }
            var UrlList = xml.GetElementsByTagName("Url");
            for (int i = 0; i < UrlList.Count; i++)
            {
                if (UrlList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
                {
                    Url = UrlList[i].ChildNodes[0].Value;
                }
            }
            
        }

        public MessageType GetMessageType(string str)
        {
            switch (str.ToLower())
            {
                case "text":
                    return MessageType.text;
                case "image":
                    return MessageType.image;
                case "voice":
                    return MessageType.voice;
                case "video":
                    return MessageType.video;
                case "location":
                    return MessageType.location;
                case "link":
                    return MessageType.link;
                default:
                    return MessageType.others;
            }
        }
    }

    public enum MessageType
    {
        text=1,
        image=2,
        voice=3,
        video=4,
        location=5,
        link=6,
        others=0
    }
}
