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
            using (var unity = new UnityContainer())
            {
                unity.RegisterInstance(Log4NetLoggerFactory.CreateLoggerFactory());
                unity.RegisterSingleton<IHttpAuthorization, BasicAuthorization>();
                unity.RegisterSingleton<IServiceClientRequestOptions, JsonServiceClientRequestOptions>();
                unity.RegisterSingleton<IServiceClient, WebServiceClient>();
                unity.RegisterSingleton<IKahuaApiClient, KahuaApiClient>();




                unity.RegisterSingleton<IKahuaDataMigrator, KahuaDataMigrator>();
                unity.RegisterSingleton<INameSearcher, NameSearcher>();
                unity.RegisterSingleton<IKahuaDataTypeConverter, KahuaDataTypeConverter>();
                unity.RegisterSingleton<IKahuaDataMigratorService, KahuaDataMigratorService>();
                unity.RegisterSingleton<IInflowRepository, ExcelRepository>();
                unity.RegisterSingleton<IModelRepository<KahuaDataMigrationModel>, JsonFileModelRepository<KahuaDataMigrationModel>>();


                unity.RegisterSingleton<IModelRepository<KahuaReponse<KahuaInflowDef>>, JsonFileModelRepository<KahuaReponse<KahuaInflowDef>>>();
                unity.RegisterSingleton<IModelRepository<IEnumerable<KahuaDomain>>, JsonFileModelRepository<IEnumerable<KahuaDomain>>>();


            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSettings());
        }
    }
}
