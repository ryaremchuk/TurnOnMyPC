using System;
using System.Web.Security;

namespace TurnOnMyPC
{
    public partial class FilerMyPC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void ProcessNotRegisterePC()
        {
            pnlError.Visible = true;
        }

        protected void btnEnterLogin_OnClick(object sender, EventArgs e)
        {
            var login = txtLogin.Text;
            var isPCRegistered = Core.LocalUserInfoStorage.GetData(login) != null;
            if (isPCRegistered)
            {
                FormsAuthentication.RedirectFromLoginPage(txtLogin.Text, true);
            }
            else
            {
                ProcessNotRegisterePC();
            }
        }
    }
}