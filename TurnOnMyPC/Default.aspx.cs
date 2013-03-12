using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            var pcInfo = GetCurrentPCInfo();
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
            Core.PCToTurnOnQueue.AddItem(pcInfo.PCMacAddress);
            Response.Redirect("~/Success.aspx");
        }

        private UserPCInfo GetCurrentPCInfo()
        {
            var login = HttpContext.Current.User.Identity.Name;
            var pcInfo = Core.LocalUserInfoStorage.GetData(login);
            return pcInfo;
        }
    }
}