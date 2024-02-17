using System;
using ProxyPattern.Contracts.RemoteProxy.WeatherProxy;
using ProxyPattern.Implementation.RemoteProxy.WeatherProxy;

namespace DesignPattern
{
    internal static class RemoteProxyImplementation
    {
        internal static void RemoteProxyPatternImplementation()
        {
            IWeatherRemoteProxy weatherRemoteProxy =new WeatherRemoteProxy();
            var weather= weatherRemoteProxy.GetCurrentWeatherInfo(DateTime.Now, "Mymensingh");
            //Now We can use it for delivery items depending on weather/ we also can store daily data for future use
        }
    }
}
