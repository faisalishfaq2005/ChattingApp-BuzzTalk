using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SecSemesterProjOOP.BL
{
    public class ImageMessage:Message
    {
        
        

        public ImageMessage( string sender, string receivers, DateTime timeStamp,bool IsSeen)
        : base(sender, receivers, timeStamp, IsSeen)
        {
            
        }
    }
}
