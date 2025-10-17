using SecSemesterProjOOP.BL;
using SecSemesterProjOOP.DL.DB;
using SecSemesterProjOOP.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Utilities
{
    public class ObjectHandler
    {
        private static IUserDL UserDL=new UserDB();
        private static ICommunityDL CommunityDL=new CommunityDB();
        private static IGroupDL GroupDL = new GroupDB();
        private static IMessageDL MessageDL = new MessageDB();
        private static IIndividualContactDL IndividualContactDL = new IndividualContactDB();


        public static IUserDL GetUserDL()
        {
            return UserDL;
        }

        public static ICommunityDL GetCommunityDL()
        {
            return CommunityDL;
        }

        public static IGroupDL GetGroupDL()
        {
            return GroupDL;
        }

        public static IMessageDL GetMessageDL()
        {
            return MessageDL;
        }

        public static IIndividualContactDL GetIndividualContactDL()
        {
            return IndividualContactDL;
        }



    }
}
