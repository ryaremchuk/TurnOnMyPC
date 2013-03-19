using System;
using System.Drawing;
using System.Web.UI;
using TurnOnMyPC.BusinessEntities;

namespace TurnOnMyPC
{
    public partial class TurnOn : Page
    {
        private string PcName
        {
            get { return Page.RouteData.Values["pcName"] as string; }
        }

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
                case PCState.On:
                        lblStatusMessage.ForeColor = Color.Orange;
                        lblStatusMessage.Text = "Already started.";
                    break;
                case PCState.Off:
                        Core.PCToTurnOnQueue.AddItem(pcInfo.PCMacAddress);
                        lblStatusMessage.ForeColor = Color.Green;
                        lblStatusMessage.Text = "Will be started in a while...";
                    break;
                default:
                    Response.Redirect("~");
                    break;
            }
        }

        private UserPCInfo GetCurrentPCInfo()
        {
            var pcInfo = Core.LocalUserInfoStorage.GetData(PcName);
            return pcInfo;
        }
    }
}