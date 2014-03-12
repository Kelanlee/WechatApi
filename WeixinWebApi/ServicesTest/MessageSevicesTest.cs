
using NUnit.Framework;
using Services;
using Services.Interface;

namespace ServicesTest
{
    [TestFixture]
    public class MessageSevicesTest
    {
        IMessageSevices ms=new MessageSevices();
        [Test]
        public void Test_GetToken()
        {
            ms.GetToken();


        }

        [Test]
        public void Test_SendMessage()
        {
            ms.SendMessage("oKWGOuBpYKDLi2kxTlLDWsEC9jRM","你好");


        }

        [Test]
        public void Test_SetMenu()
        {
            ms.SetMenu();


        }
    }
}
