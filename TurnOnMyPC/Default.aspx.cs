using System;
using System.Drawing;
using System.Web;

namespace TurnOnMyPC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            pnlLogin.Visible = true;
            pnlPCStatus.Visible = false;
        }

        private void ProcessNotRegisterePC()
        {
            Response.Redirect("~/NotRegisteredPC.aspx");
        }

        private void ProcessRegisteredPC()
        {
            pnlLogin.Visible = false;
            pnlPCStatus.Visible = true;

            var pcName = Core.UserInfoStorage.GetUserPCName(txtLogin.Text);
            var isTurnedOn = Core.RemotePCManager.IsTurnedOn(pcName);

            lblPCName.Text = pcName;

            if (isTurnedOn)
            {
                lblPCStatus.Text = "Running";
                lblPCStatus.ForeColor = Color.Green;
                btnTurnOn.Visible = false;
            }
            else
            {
                lblPCStatus.Text = "Turned off";
                lblPCStatus.ForeColor = Color.Red;
                btnTurnOn.Visible = true;
            }
        }

        protected void btnTurnOn_OnClick(object sender, EventArgs e)
        {
            var mac = Core.UserInfoStorage.GetUserMacAddress(txtLogin.Text);
            Core.RemotePCManager.WakeOnLan(mac);

            Response.Redirect("~/Success.aspx");
        }

        protected void btnEnterLogin_OnClick(object sender, EventArgs e)
        {
            var isPCRegistered = Core.UserInfoStorage.IsUserPCRegistered(txtLogin.Text);
            if (isPCRegistered)
            {
                ProcessRegisteredPC();
            }
            else
            {
                ProcessNotRegisterePC();
            }
        }
    }
}