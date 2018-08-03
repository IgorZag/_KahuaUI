using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigration
{
    public class DataMigrationSettingsSaveToConfigFileAttribute : Attribute
    {
    }
    public class JsonResult
    {
        public int testId { get; set; }
        public string testName { get; set; }
        public int minScore { get; set; }
        public int score { get; set; }
        public List<string> Names { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
    }
    public class DataMigrationSettings
    {
        Dictionary<string, string> AvailableEnvironmentAndValue;
        public List<string> AvailableEnvironments { get; internal set; }
        [DataMigrationSettingsSaveToConfigFileAttribute]
        public string SelectedEnvironment { private set; get; }
        public void SetSelectedEnviromnent(int value)
        {
            try
            {
                SelectedEnvironment = AvailableEnvironments[value];
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.InnerException);
                throw new Exception("Unable to choose selected environment:" + exp.Message);
            }
            
        }

        [DataMigrationSettingsSaveToConfigFileAttribute]
        public string KahuaUsername { get; set; }
        public string Password { get; set; }
        [DataMigrationSettingsSaveToConfigFileAttribute]
        public string KahuaDomain { get; set; }

        public List<string> AvailableInflow { get; }
        [DataMigrationSettingsSaveToConfigFileAttribute]
        public string SelectedInflow { private set; get; }
        public void SetSelectedInflow(int value)
        {
            try
            {
                SelectedInflow = AvailableInflow[value];
            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.InnerException);
                throw new Exception("Unable to choose selected inflow:" + exp.Message);
            }
        }
        [DataMigrationSettingsSaveToConfigFileAttribute]
        public string ExcelFile { get; set; }
        public bool ReadFromConfigFile()
        {
            bool bRet = false;

            var envs = ConfigurationManager.AppSettings.AllKeys.ToDictionary(k => k, v => ConfigurationManager.AppSettings[v]).Where(k => k.Key.StartsWith("Kahua.Env"));

            AvailableEnvironmentAndValue = envs.ToDictionary(k => k.Key, v => v.Value);
            AvailableEnvironments = (AvailableEnvironmentAndValue.Keys.ToList());

            return bRet;
        }
        public bool SaveSelectedSettingsToConfigFile()
        {
            bool bRet = false;

            var props = GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(DataMigrationSettingsSaveToConfigFileAttribute)));
            foreach (var prop in props)
            {
                var v = prop.Name;
                var v222 = prop.ToString();
            }

            return bRet;
        }
    }
}
