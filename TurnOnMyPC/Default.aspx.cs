using System;
using System.Drawing;
using System.IO;
using TurnOnMyPC.BusinessEntities;

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

        private void ProcessTurnOnPC(UserPCInfo pcInfo)
        {
            Core.PCToTurnOnQueue.AddItem(pcInfo.PCMacAddress);
            Response.Redirect("~/Success.aspx");
        }

        private void ProcessRegisteredPC(UserPCInfo pcInfo)
        {
            pnlLogin.Visible = false;
            pnlPCStatus.Visible = true;

            lblPCName.Text = pcInfo.PCName;
            switch (pcInfo.State)
            {
                case PCState.Unknown:
                    lblPCStatus.Text = "Unknown";
                    lblPCStatus.ForeColor = Color.Orange;
                    btnTurnOn.Visible = true;
                    break;
                case PCState.On:
                    lblPCStatus.Text = "Running";
                    lblPCStatus.ForeColor = Color.Green;
                    btnTurnOn.Visible = false;
                    break;
                case PCState.Off:
                    lblPCStatus.Text = "Turned off";
                    lblPCStatus.ForeColor = Color.Red;
                    btnTurnOn.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected void btnTurnOn_OnClick(object sender, EventArgs e)
        {
            var pcInfo = GetCurrentPCInfo();
            var isPCRegistered = pcInfo != null;
            if (isPCRegistered)
            {
                ProcessTurnOnPC(pcInfo);
            }
            else
            {
                ProcessNotRegisterePC();
            }
        }

        protected void btnEnterLogin_OnClick(object sender, EventArgs e)
        {
            var pcInfo = GetCurrentPCInfo();
            var isPCRegistered = pcInfo != null;
            if (isPCRegistered)
            {
                ProcessRegisteredPC(pcInfo);
            }
            else
            {
                ProcessNotRegisterePC();
            }
        }

        private UserPCInfo GetCurrentPCInfo()
        {
            var login = txtLogin.Text;
            var pcInfo = Core.UserInfoStorage.GetData(login);
            return pcInfo;
        }
    }
}