using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.BL
{
    public class IndividualContact
    {
        private User Contact;
        private List<Message> UserMessagesBetweenThatIndividual = new List<Message>();

        public IndividualContact(User Cont)
        {
            Contact = Cont;
           
        }
        

        public User GetUserContact()
        {
            return Contact;
        }
        public void SetUserContact(User user)
        {
            Contact=user;
        }
        public void AddMessageInMessageList(Message message)
        {
            UserMessagesBetweenThatIndividual.Add(message);
        }
        public List<Message> GetIndividualMessages()
        {
            return UserMessagesBetweenThatIndividual;
        }
    }
}
