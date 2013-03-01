using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Web.Services;
using TurnOnMyPC.BusinessEntities;

namespace TurnOnMyPC
{
    [WebService(Namespace = "http://us.demo.eleks.com/TurnOnMyPC")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetMacsToTurnOn(string userName, string password)
        {
            return ProcessRequest(userName, password, () =>
                {
                    var result = Core.PCToTurnOnQueue.GetAll();
                    //todo: think about this clear... Is this good solution? RY
                    Core.PCToTurnOnQueue.Clear();

                    return result;
                }).ToList();
        }

        [WebMethod]
        public bool UpdateData(string userName, string password, List<UserPCInfo> data)
        {
            return ProcessRequest(userName, password, () =>
            {
                Core.UserInfoStorage.ReloadData(data);
                return true;
            });
        }

        private T ProcessRequest<T>(string userName, string password, Func<T> func) 
        {
            try
            {
                AuthenticateRequest(userName, password);
                return func();
            }
            catch
            {
                //todo: log exception here. RY
                return default(T);
            }
        }

        private void AuthenticateRequest(string userName, string password)
        {
            var isCorrectRequest =
                userName == ConfigurationManager.AppSettings["webServiceUserName"] &&
                password == ConfigurationManager.AppSettings["webServiceUserPassword"];

            if (!isCorrectRequest)
            {
                throw new AuthenticationException(string.Format("invalid credentials {0} {1}", userName, password));
            }
        }
    }
}
