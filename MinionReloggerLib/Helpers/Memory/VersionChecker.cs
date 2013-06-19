//using System;
//using System.Net;
//using System.Xml;
//using MinionReloggerLib.Helpers.Memory;

//public static class VersionChecker
//{
//    public static void CheckForUpdates()
//    {
//        XmlTextReader reader = null;
//        try
//        {
//            string xmlURL = "http://minionrelogger.azurewebsites.net/version.xml";
//            var hwRequest = (HttpWebRequest) WebRequest.Create(xmlURL);
//            hwRequest.Timeout = 5000;
//            hwRequest.ReadWriteTimeout = 5000;
//            hwRequest.Proxy = null;
//            HttpWebResponse hwResponse = null;
//            try
//            {
//                hwResponse = (HttpWebResponse) hwRequest.GetResponse();
//                reader = new XmlTextReader(hwResponse.GetResponseStream());
//                reader.MoveToContent();

//                string elementName = "";
//                if ((reader.NodeType == XmlNodeType.Element) &&
//                    (reader.Name == "minionlauncher"))
//                {
//                    while (reader.Read())
//                    {
//                        if (reader.NodeType == XmlNodeType.Element)
//                            elementName = reader.Name;
//                        else
//                        {
//                            if ((reader.NodeType == XmlNodeType.Text) &&
//                                (reader.HasValue))
//                            {
//                                switch (elementName)
//                                {
//                                    case "buildnumber":
//                                        uint.TryParse(reader.Value, out Pointers.BuildNumber);
//                                        break;
//                                    case "viewstate":
//                                        uint.TryParse(reader.Value, out Pointers.ViewStatePtr);
//                                        break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception)
//            {
//            }
//            finally
//            {
//                if (reader != null) reader.Close();
//                if (hwResponse != null) hwResponse.Close();
//            }
//        }
//        catch
//        {
//        }
//        finally
//        {
//            if (reader != null) reader.Close();
//        }
//    }
//}

