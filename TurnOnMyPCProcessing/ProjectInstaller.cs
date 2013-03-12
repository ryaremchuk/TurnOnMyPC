using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace TurnOnMyPCProcessing
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            //todo: update app config here.
            base.Install(stateSaver);
        }


        private void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            StartWinService();
 
        }

        private void StartWinService()
        {
            using (var controller = new ServiceController(serviceInstaller.ServiceName))
            {
                controller.Start();
            }
        }
    }
}
