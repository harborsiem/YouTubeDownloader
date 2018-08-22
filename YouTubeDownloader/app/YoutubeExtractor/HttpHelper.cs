//Parts of code from YouTubeExtractor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace YoutubeExtractor {
    static class HttpHelper {

        public static string DownloadString(string url) {
            using (var client = new WebClient()) {
                client.Proxy = YouTubeDownloader.Helper.InitialProxy(); //added (harborsiem)
                client.Encoding = System.Text.Encoding.UTF8;
                return client.DownloadString(url);
            }
        }

        public static IDictionary<string, string> ParseQueryString(string s) {
            // remove anything other than query string from url
            if (s.Contains("?")) {
                s = s.Substring(s.IndexOf('?') + 1);
            }

            var dictionary = new Dictionary<string, string>();

            foreach (string vp in Regex.Split(s, "&")) {
                string[] strings = Regex.Split(vp, "=");
                dictionary.Add(strings[0], strings.Length == 2 ? UrlDecode(strings[1]) : string.Empty);
            }

            return dictionary;
        }

        public static string UrlDecode(string url) {
#if PORTABLE
            return System.Net.WebUtility.UrlDecode(url);
#else
            return System.Web.HttpUtility.UrlDecode(url);
#endif
        }
    }
}
