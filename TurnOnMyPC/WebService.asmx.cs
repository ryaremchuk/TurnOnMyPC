using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TurnOnMyPC
{
    [WebService(Namespace = "http://us.demo.eleks.com/TurnOnMyPC")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetMacsToTurnOn()
        {
            return null;
        }

        [WebMethod]
        public void UpdateUserPCStatus(string userName, bool isTuredOn)
        {
            
        }
    }
}
