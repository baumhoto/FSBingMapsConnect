using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FSBingMapsConnect
{
    public static class GoogleEarthConnector
    {
        public static string GetExecutionString(ConnectorParameters parameters)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"FsMapsConnect.kml");


            foreach (XmlNode aNode in doc.DocumentElement.FirstChild.FirstChild.ChildNodes)
            {
                if (aNode.Name == "name")
                {
                    aNode.InnerText = parameters.Response.title;
                }
                else if (aNode.Name == "description")
                {
                    aNode.InnerText = $"(lon/lat):{parameters.Response.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}, {parameters.Response.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}";
                }
                else if (aNode.Name == "Point")
                {
                    aNode.FirstChild.InnerText = $"{parameters.Response.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)},{parameters.Response.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)},0";
                }
                else if (aNode.Name == "LookAt")
                {
                    foreach (XmlNode lNode in aNode.ChildNodes)
                    {
                        if(lNode.Name == "longitude")
                        {
                            lNode.InnerText = $"{parameters.Response.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}";
                        }
                        else if(lNode.Name == "latitude")
                        {
                            lNode.InnerText = $"{parameters.Response.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}";
                        }
                        else if (lNode.Name == "altitude")
                        {
                            //lNode.InnerText = $"{parameters.Response.altitudeAboveGround * 0.3048}";
                        }
                        else if (lNode.Name == "tilt")
                        {
                            lNode.InnerText = $"{parameters.Pitch}";
                        }
                        else if (lNode.Name == "heading")
                        {
                            lNode.InnerText = $"{parameters.Response.heading.ToString(CultureInfo.InvariantCulture.NumberFormat)}";
                        }
                        else if (lNode.Name == "range")
                        {
                            if(parameters.AlignZoom)
                            {
                                lNode.InnerText = $"{(parameters.Response.altitudeAboveGround * 0.3048).ToString(CultureInfo.InvariantCulture.NumberFormat)}";
                            }
                            else
                            {
                                lNode.InnerText = $"{(21 - parameters.ZoomLevel) * 1000}";
                            }
                        }
                    }
                }
            }

            // save the XmlDocument back to disk
            doc.Save(@"FsMapsConnect.kml");

            return "FsMapsConnect.kml";
        }
    }
}
