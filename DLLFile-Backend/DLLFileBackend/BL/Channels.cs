using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class Channels
    {
        private string Name;
        

        public Channels(string name)
        {
            Name=name;
            
        }  
        
        public string GetChannelName()
        {
            return Name;
        }

    }
}
