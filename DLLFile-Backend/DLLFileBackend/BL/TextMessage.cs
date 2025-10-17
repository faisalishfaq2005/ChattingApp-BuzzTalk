using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class TextMessage:Message
    {

        private string Text;

        public TextMessage(string sender, string receivers, DateTime timeStamp,bool IsSeen,string text): base( sender, receivers, timeStamp,IsSeen)
        {
            Text = text;
        }

        public string GetText()
        {
            return Text;
        }
    }
}
