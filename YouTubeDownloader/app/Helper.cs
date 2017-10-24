//Copy rights are reserved for Akram kamal qassas
//Email me, Akramnet4u@hotmail.com
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
//using YoutubeExtractor;
//using Newtonsoft.Json.Linq;

namespace YouTubeDownloader {
    public static class Helper {

        /// <summary>
        /// Decode a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static string UrlDecode(string str) {
        //    return System.Web.HttpUtility.UrlDecode(str);
        //}

        public static bool IsValidUrl(string urlString) {
            string pattern = @"^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?$";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(urlString);
        }

        ///// <summary>
        ///// Gets the text that lies between these two strings
        ///// </summary>
        //public static string GetTextBetween(string input, string start, string end, int startIndex) {
        //    return GetTextBetween(input, start, end, startIndex, false);
        //}

        ///// <summary>
        ///// Gets the text that lies between these two strings
        ///// </summary>
        //public static string GetLastTextBetween(string input, string start, string end, int startIndex) {
        //    return GetTextBetween(input, start, end, startIndex, true);
        //}

        ///// <summary>
        ///// Gets the text that lies between these two strings
        ///// </summary>
        //private static string GetTextBetween(string input, string start, string end, int startIndex, bool useLastIndexOf) {
        //    int index1 = useLastIndexOf ? input.LastIndexOf(start, startIndex) :
        //                                  input.IndexOf(start, startIndex);
        //    if (index1 == -1) return "";
        //    index1 += start.Length;
        //    int index2 = input.IndexOf(end, index1);
        //    if (index2 == -1) return input.Substring(index1);
        //    return input.Substring(index1, index2 - index1);
        //}

        ///// <summary>
        ///// Split the input text for this pattern
        ///// </summary>
        //public static string[] Split(string input, string pattern) {
        //    return Regex.Split(input, pattern);
        //}


        /// <summary>
        /// Returns the content of a given web address as string.
        /// </summary>
        /// <param name="urlString">URL of the webpage</param>
        /// <returns>Website content</returns>
        public static string DownloadWebPage(string urlString) {
            return DownloadWebPage(urlString, null);
        }

        private static string DownloadWebPage(string urlString, string stopLine) {
            try {
                // Open a connection
                HttpWebRequest webRequestObject = (HttpWebRequest)HttpWebRequest.Create(urlString);
                webRequestObject.Proxy = InitialProxy();
                // You can also specify additional header values like 
                // the user agent or the referer:
                webRequestObject.UserAgent = ".NET Framework/2.0";

                // Request response:
                WebResponse response = webRequestObject.GetResponse();

                // Open data stream:
                Stream webStream = response.GetResponseStream();

                // Create reader object:
                StreamReader reader = new StreamReader(webStream);
                string pageContent = "";
                string line;
                if (stopLine == null) {
                    pageContent = reader.ReadToEnd();
                } else {
                    while (!reader.EndOfStream) {
                        line = reader.ReadLine();
                        pageContent += line + Environment.NewLine;
                        if (line.Contains(stopLine)) {
                            break;
                        }
                    }
                }
                // Cleanup
                reader.Close();
                webStream.Close();
                response.Close();

                return pageContent;
            }
            catch (Exception) {
                throw;
            }
        }


        public static IWebProxy InitialProxy() {
            string address = getIEProxy();
            if (!string.IsNullOrEmpty(address)) {
                WebProxy proxy = new WebProxy(address);
                proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                return proxy;
            } else {
                return null;
            }
        }

        private static string getIEProxy() {
            var proxy = WebRequest.DefaultWebProxy;
            if (proxy == null) {
                return null;
            }
            WebProxy webProxy = proxy as WebProxy;
            if (webProxy == null) {
                Type t = proxy.GetType();
                var s = t.GetProperty("WebProxy", (BindingFlags)0xfff).GetValue(proxy, null);
                webProxy = s as WebProxy;
            }
            if (webProxy == null || webProxy.Address == null || string.IsNullOrEmpty(webProxy.Address.AbsolutePath)) {
                return null;
            }
            return webProxy.Address.Host;
        }

        /// <summary>
        /// Decrypt the signature (uses code from project "YoutubeExtractor")
        /// </summary>
        //public static string GetDecipheredSignature(string playerVersion, string signature) {
        //    return Decipherer.DecipherWithVersion(signature, playerVersion);
        //}

        //public static string GetPlayerVersion(string videoUrl) {
        //    JObject json = LoadJson(videoUrl);
        //    string htmlPlayerVersion = GetHtml5PlayerVersion(json);
        //    return htmlPlayerVersion;
        //}

        //private static string GetHtml5PlayerVersion(JObject json) {
        //    var regex = new Regex(@"player-(.+?).js");

        //    string js = json["assets"]["js"].ToString();

        //    return regex.Match(js).Result("$1");
        //}

        //private static bool IsVideoUnavailable(string pageSource) {
        //    const string unavailableContainer = "<div id=\"watch-player-unavailable\">";

        //    return pageSource.Contains(unavailableContainer);
        //}

        //private static JObject LoadJson(string url) {
        //    string pageSource = HttpHelper.DownloadString(url);

        //    if (IsVideoUnavailable(pageSource)) {
        //        throw new ArgumentException("Watch Player unavailable");
        //    }

        //    var dataRegex = new Regex(@"ytplayer\.config\s*=\s*(\{.+?\});", RegexOptions.Multiline);

        //    string extractedJson = dataRegex.Match(pageSource).Result("$1");

        //    return JObject.Parse(extractedJson);
        //}
    }
}
