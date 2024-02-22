using Common.Model;
using Common.Model.Constants;

namespace RabbitConsumerForNotification.Builder
{
    public static class AppSettingsBuilder
    {
        public static void AppSettingsBuild()
        {
            CustomConstant.CurrentAppSettings = new AppSettings();
            BuildMongoConnection();
            BuildSqlConnection();
        }
        private static void BuildMongoConnection()
        {
            CustomConstant.CurrentAppSettings.MongoConnection = new MongoConnectionModel();
            CustomConstant.CurrentAppSettings.MongoConnection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["mongodbconnection"];
            CustomConstant.CurrentAppSettings.MongoConnection.InstanceName = System.Configuration.ConfigurationManager.AppSettings["mongodbInstanceName"];
        }
        private static void BuildSqlConnection()
        {
            CustomConstant.CurrentAppSettings.SqlConnection = new SqlConnectionModel();
            CustomConstant.CurrentAppSettings.SqlConnection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["sqlserverdbconnection"];
            CustomConstant.CurrentAppSettings.SqlConnection.InstanceName = System.Configuration.ConfigurationManager.AppSettings["sqlserverInstanceName"];
        }
    }
}
