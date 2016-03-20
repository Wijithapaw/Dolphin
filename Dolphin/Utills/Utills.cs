using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dolphin.Utills
{
    public enum MessageType
    {
        Success,
        Warning,
        Error,
        Other
    }

    public class Message
    {
        public string Title;
        public string Text;
        public MessageType Type;
    }
}