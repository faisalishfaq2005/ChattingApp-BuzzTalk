using SecSemesterProjOOP.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemesterProjOOP.DLInterfaces
{
    public interface IIndividualContactDL
    {
        bool UpdateContactInUserContacts(User user, User SignedInUser);

        List<IndividualContact> RetrievingDataForContactsList(User user);
    }
}
