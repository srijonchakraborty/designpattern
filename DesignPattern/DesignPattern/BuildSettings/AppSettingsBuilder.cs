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
        }
        private static void BuildMongoConnection()
        {
            CustomConstant.CurrentAppSettings.MongoConnection = new MongoConnectionModel();
            CustomConstant.CurrentAppSettings.MongoConnection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["mongodbconnection"];
            CustomConstant.CurrentAppSettings.MongoConnection.InstanceName = System.Configuration.ConfigurationManager.AppSettings["mongodbInstanceName"];
        }
    }
}
