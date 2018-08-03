using Kahua.ApiClient;
using Kahua.ApiClient.ServiceClient;
using Kahua.ApiClient.ServiceClient.Authorization;
using Kahua.ApiClient.ServiceClient.Options;
using Kahua.Contracts;
using Kahua.Contracts.DataMapping;
using Kahua.Implementation;
using Kahua.Implementation.Repository;
using Kahua.Logging;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace DataMigration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSettings());
        }
    }
}
