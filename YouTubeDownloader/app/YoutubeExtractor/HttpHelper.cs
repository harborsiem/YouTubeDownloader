//Parts of code from YouTubeExtractor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace YoutubeExtractor {
    static class HttpHelper {

        public static string DownloadString(string url) {
            using (var client = new WebClient()) {
                client.Proxy = YouTubeDownloader.Helper.InitialProxy(); //added (harborsiem)
                client.Encoding = System.Text.Encoding.UTF8;
                return client.DownloadString(url);
            }
        }
    }
}
