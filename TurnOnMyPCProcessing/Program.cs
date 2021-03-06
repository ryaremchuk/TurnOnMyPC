﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace TurnOnMyPCProcessing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            var service = new ProcessingService();
            service.Process();
            Thread.Sleep(Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new ProcessingService() 
			};
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
