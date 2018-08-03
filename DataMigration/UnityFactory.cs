using Kahua.ApiClient;
using Kahua.ApiClient.ServiceClient;
using Kahua.ApiClient.ServiceClient.Authorization;
using Kahua.ApiClient.ServiceClient.Options;
using Kahua.Contracts;
using Kahua.Contracts.DataMapping;
using Kahua.Implementation;
using Kahua.Implementation.Repository;
using Kahua.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Registration;

namespace DataMigration
{
    public static class UnityFactory
    {
        private static IUnityContainer _unityContainer = null;

        static UnityFactory()
        {
            RegisterAll();
        }

        public static T Resolve<T>()
        {
            if (_unityContainer != null)
            {
                if (_unityContainer.IsRegistered<T>())
                {
                    return _unityContainer.Resolve<T>();
                }
            }
            return default(T);

        }
        private static void RegisterAll()
        {
            if (null == _unityContainer)
            {
                _unityContainer = new UnityContainer();


                _unityContainer.RegisterInstance(Log4NetLoggerFactory.CreateLoggerFactory());
                _unityContainer.RegisterSingleton<IHttpAuthorization, BasicAuthorization>();
                _unityContainer.RegisterSingleton<IServiceClientRequestOptions, JsonServiceClientRequestOptions>();
                _unityContainer.RegisterSingleton<IServiceClient, WebServiceClient>();
                _unityContainer.RegisterSingleton<IKahuaApiClient, KahuaApiClient>();

                _unityContainer.RegisterSingleton<ILogger, Log4NetLogger>();
                _unityContainer.RegisterSingleton<ILoggingService, LoggingService>();


                _unityContainer.RegisterSingleton<IKahuaDataMigrator, KahuaDataMigrator>();
                _unityContainer.RegisterSingleton<INameSearcher, NameSearcher>();
                _unityContainer.RegisterSingleton<IKahuaDataTypeConverter, KahuaDataTypeConverter>();
                _unityContainer.RegisterSingleton<IKahuaDataMigratorService, KahuaDataMigratorService>();
                _unityContainer.RegisterSingleton<IInflowRepository, ExcelRepository>();
                _unityContainer.RegisterSingleton<IModelRepository<KahuaDataMigrationModel>, JsonFileModelRepository<KahuaDataMigrationModel>>();


                _unityContainer.RegisterSingleton<IModelRepository<KahuaReponse<KahuaInflowDef>>, JsonFileModelRepository<KahuaReponse<KahuaInflowDef>>>();
                _unityContainer.RegisterSingleton<IModelRepository<IEnumerable<KahuaDomain>>, JsonFileModelRepository<IEnumerable<KahuaDomain>>>();
            }

        }

    }
}
