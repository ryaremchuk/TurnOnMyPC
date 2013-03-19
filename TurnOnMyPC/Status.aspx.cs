using System;
using System.Drawing;
using System.Web;
using TurnOnMyPC.BusinessEntities;

namespace TurnOnMyPC
{
    public partial class Status : System.Web.UI.Page
    {
        private string PcName
        {
            get { return Page.RouteData.Values["pcName"] as string; }
        }

        //todo: think about refactoring.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            if (string.IsNullOrEmpty(PcName))
            {
                Response.Redirect("~");
            }

            var pcInfo = GetCurrentPCInfo();

            if (pcInfo == null)
            {
                Response.Redirect("~");
                return;
            }

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
            ProcessTurnOnPC(pcInfo);
        }

        private void ProcessTurnOnPC(UserPCInfo pcInfo)
        {
            Response.Redirect(string.Format("~/{0}/TurnOn", pcInfo.PCName));
        }

        private UserPCInfo GetCurrentPCInfo()
        {
            var pcInfo = Core.LocalUserInfoStorage.GetData(PcName);
            return pcInfo;
        }
    }
}