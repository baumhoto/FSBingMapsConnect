using System;
using System.Globalization;

namespace FSBingMapsConnect
{
    public static class BingMapsConnector
    {
        public static string GetExecutionString(ConnectorParameters parameters)
        {
            string zoomString = "";
            if (parameters.AlignZoom)
            {
                zoomString = $"lvl={20 - Math.Ceiling(parameters.Response.altitudeAboveGround / 1000)}";
            }
            else
            {
                zoomString = $"lvl={parameters.ZoomLevel}";
            }

            string mapString = "sty=";
            switch (parameters.MapType)
            {
                case "Road": mapString += "r"; break;
                default: mapString += "a"; break;
            }

            var gpsString = $"bingmaps:?cp={parameters.Response.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}~{parameters.Response.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}&{zoomString}&{mapString}&hdg={parameters.Response.heading}&pit={parameters.Pitch}";

            return gpsString;
        }
    }
}
