using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketing
{
    public class MessageRepository : IMessageRepository 
    {
        public string Message()
        {
            return "Welcome to the plugin!";
        }
    } 
}
