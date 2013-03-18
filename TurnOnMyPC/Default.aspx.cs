using System;
using System.Web.Security;

namespace TurnOnMyPC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void ProcessNotRegisterePC()
        {
            pnlError.Visible = true;
        }

        protected void btnCheckName_OnClick(object sender, EventArgs e)
        {
            var name = txtPcName.Text;
            var isPCRegistered = Core.LocalUserInfoStorage.GetData(name) != null;
            if (isPCRegistered)
            {
                Response.Redirect(string.Format("~/{0}/Status", name));
            }
            else
            {
                ProcessNotRegisterePC();
            }
        }
    }
}