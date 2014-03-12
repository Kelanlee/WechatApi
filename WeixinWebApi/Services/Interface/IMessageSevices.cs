using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Services.Interface
{
    public interface IMessageSevices
    {
        string ReplyMessage(XmlDocument xml);

        bool GetToken();

        bool SendMessage(string openId, string content);

        bool SetMenu();
    }
}
