using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.DLInterfaces
{
    public interface IUserDL
    {
        bool SignUp(User user);
        User SignIn(User user, List<IndividualContact> contacts, List<Group> UserGroups, List<Community> UserCommunities, List<Channels> channels);


        List<Channels> RetreiveChannels();


        

       

        bool validateUser(User user);

        bool ValidateUserForAddingContact(User user);

       

       
        

        


        
    }
}
