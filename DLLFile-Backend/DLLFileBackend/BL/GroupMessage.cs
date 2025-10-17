using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
        public class GroupMessage
        {
        private Message Message;
        private Group Group;
        


        public GroupMessage(Message message, Group group)
        {
            Message = message;
            Group = group;

            
        }

        
    }
}
