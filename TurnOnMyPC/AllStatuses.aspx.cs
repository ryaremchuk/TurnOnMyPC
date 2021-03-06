﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnOnMyPC
{
    public partial class AllStatuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            rptData.DataSource = Core.LocalUserInfoStorage.GetAllData();
            rptData.DataBind();
        }
    }
}