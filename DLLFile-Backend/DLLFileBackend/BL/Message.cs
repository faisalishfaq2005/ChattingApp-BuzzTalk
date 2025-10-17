using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class Message
    {
        
        protected string Sender;
        protected string Receivers; 
        protected DateTime TimeStamp;
        protected bool IsSeen;
        
        
        
        public Message(string Sender,string Receivers,DateTime TimeStamp,bool isSeen) 
        {
           
            this.Sender = Sender;
            this.Receivers = Receivers;
            this.TimeStamp = TimeStamp;
            IsSeen = isSeen;

        }

        public string GetSender()
        {
            return Sender;
        }
        public string GetReceivers()
        {
            return Receivers;
        }
        public DateTime GetTimeStamp()
        {
            return TimeStamp;
        }
        public bool GetIsSeen()
        {
            return IsSeen;
        }
    }
}
