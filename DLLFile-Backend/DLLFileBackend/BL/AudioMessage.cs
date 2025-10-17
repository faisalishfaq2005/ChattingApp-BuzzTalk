using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class AudioMessage:Message
    {
        public AudioMessage(string sender, string receivers, DateTime timeStamp, bool IsSeen) : base(sender, receivers, timeStamp, IsSeen)
        {

        }

    }
}
