//Copy rights are reserved for Akram kamal qassas
//Email me, Akramnet4u@hotmail.com
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Globalization;
using YoutubeExtractor;

namespace YouTubeDownloader {

    /// <summary>
    /// Use this class to get youtube video urls
    /// </summary>
    public static class YouTubeDownloader {

        //private static readonly string[] elValue = {
        //    "",
        //    "detailpage",
        //    "embedded",
        //    "vevo",
        //};

        public static IList<VideoQuality> GetYouTubeVideoUrls(string videoUrl) {
            var list = new List<VideoQuality>();

            var id = YouTubeDownloader.GetVideoIdFromUrl(videoUrl);
            var longId = YouTubeDownloader.GetLongVideoIdFromUrl(videoUrl);

            string stsValue = null;
            bool ageGateContent = false;
            string status;
            string title;
            string videoDuration;
            string[] videos;
            string infoUrl;
            string infoText;

            WebClient webClient = new WebClient();
            webClient.Proxy = Helper.InitialProxy();

            infoUrl = string.Format(CultureInfo.InvariantCulture, "https://www.youtube.com/watch?v={0}&gl=US&hl=en&has_verified=1&bpctr=9999999999", longId);
            infoText = webClient.DownloadString(infoUrl);

            ageGateContent = infoText.Contains("player-age-gate-content");
            if (ageGateContent) {
                infoUrl = string.Format(CultureInfo.InvariantCulture, "https://www.youtube.com/embed/{0}", longId);
                infoText = webClient.DownloadString(infoUrl);
                stsValue = Regex.Match(infoText, @"""sts"":([0-9]+?),").Groups[1].Value;
            }
            if (ageGateContent && !string.IsNullOrEmpty(stsValue)) {
                infoUrl = string.Format(CultureInfo.InvariantCulture, "https://www.youtube.com/get_video_info?video_id={0}&eurl=https://youtube.googleapis.com/v/{1}&sts={2}", longId, id, stsValue);
            } else {
                infoUrl = string.Format(CultureInfo.InvariantCulture, "http://www.youtube.com/get_video_info?&video_id={0}&el=detailpage&ps=default&eurl=&gl=US&hl=en", longId);
            }
            infoText = webClient.DownloadString(infoUrl);
            webClient.Dispose();
            var infoValues = HttpUtility.ParseQueryString(infoText);

#if DEBUG
            Dictionary<String, String> testInfoValues = new Dictionary<string, string>();
            foreach (String key in infoValues) {
                testInfoValues.Add(key, infoValues[key]);
            }
#endif

            String offerButtonText;
            offerButtonText = infoValues["ypc_offer_button_text"];
            if (offerButtonText == null) {
                offerButtonText = String.Empty;
            } else {
                offerButtonText = ", Pay " + offerButtonText;
            }

            status = infoValues["status"];
            if (status != null && status == "fail") {
                var errorcode = infoValues["errorcode"];
                var errordetail = infoValues["errordetail"];
                var reason = infoValues["reason"];
                bool boolDetail = false;
                int intErrorCode = int.Parse(errorcode, CultureInfo.InvariantCulture);
                if (errordetail != null) {
                    int detail = int.Parse(errordetail, CultureInfo.InvariantCulture);
                    boolDetail = detail == 0 ? false : true;
                }
                throw new DownloaderException(reason, intErrorCode, boolDetail);
            }
            title = infoValues["title"];
            videoDuration = infoValues["length_seconds"];
            videos = infoValues["url_encoded_fmt_stream_map"].Split(',');

            string html = Helper.DownloadWebPage(videoUrl);
            var regex = new Regex(@"player-(.+?).js");
            string playerVersion = regex.Match(html).Result("$1");

            foreach (var item in videos) {
                if (String.IsNullOrEmpty(item)) {
                    throw new ArgumentException("Cannot download \"" + title + "\"" + offerButtonText);
                }
                try {
                    var data = HttpUtility.ParseQueryString(item);
                    var fallback_host = data["fallback_host"];
                    String server = String.Empty;
                    if (!String.IsNullOrEmpty(fallback_host)) {
                        server = Uri.UnescapeDataString(fallback_host);
                    }
                    var signature = data["sig"] ?? data["signature"] ?? data["s"];   // Hans: Added "s" for encrypted signatures
                    var url = Uri.UnescapeDataString(data["url"]) + "&fallback_host=" + server;

                    if (!string.IsNullOrEmpty(signature) && data["s"] == null) {
                        url += "&signature=" + signature;
                    }

                    // If the download-URL contains encrypted signature
                    if (data["s"] != null) {

                        string decryptedSignature;
                        try {
                            // Decrypt the signature
                            decryptedSignature = Decipherer.DecipherWithVersion(signature.ToString(), playerVersion);
                        }
                        catch (Exception e) {
                            //string ex = e.Message;
                            throw new DownloaderException("Signature decipher problem", e);
                        }
                        // The new download-url with decrypted signature
                        url += "&signature=" + decryptedSignature;
                    }

                    var size = GetSize(url);
                    var videoItem = new VideoQuality();
                    videoItem.DownloadUrl = url;
                    videoItem.VideoSize = size;
                    videoItem.VideoTitle = title;
                    var tagInfo = new ITagInfo(Uri.UnescapeDataString(data["itag"]));
                    videoItem.Dimension = tagInfo.VideoDimensions;
                    videoItem.Extension = tagInfo.VideoExtensions;
                    videoItem.Length = long.Parse(videoDuration, CultureInfo.InvariantCulture);
                    list.Add(videoItem);
                }
                catch (Exception) {
                    //string ex = e.Message;
                    throw;
                }
            }
            return list;
        }

        private static long GetSize(string videoUrl) {
            long bytesLength;
            var infos = HttpUtility.ParseQueryString(videoUrl);
            string size = infos["clen"];
            if (!string.IsNullOrEmpty(size)) {
                if (long.TryParse(size, out bytesLength)) {
                    return bytesLength;
                }
            }

            HttpWebRequest fileInfoRequest = (HttpWebRequest)HttpWebRequest.Create(videoUrl);
            fileInfoRequest.Proxy = Helper.InitialProxy();
            HttpWebResponse fileInfoResponse = (HttpWebResponse)fileInfoRequest.GetResponse();
            bytesLength = fileInfoResponse.ContentLength;
            fileInfoRequest.Abort();
            return bytesLength;
        }

        /// <summary>
        /// Get the ID of a youtube video from its URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetVideoIdFromUrl(string url) {
            url = url.Substring(url.IndexOf("?", StringComparison.Ordinal) + 1);
            char[] delimiters = { '&', '#' };
            string[] props = url.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            string videoid = string.Empty;
            foreach (string prop in props) {
                if (prop.StartsWith("v=", StringComparison.Ordinal)) {
                    videoid = prop.Substring(prop.IndexOf("v=", StringComparison.Ordinal) + 2);
                }
            }

            return videoid;
        }

        /// <summary>
        /// Get the ID of a youtube video from its URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetLongVideoIdFromUrl(string url) {
            url = url.Substring(url.IndexOf("?", StringComparison.Ordinal) + 1);
            char[] delimiters = { '#' };
            string[] props = url.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            string videoid = string.Empty;
            foreach (string prop in props) {
                if (prop.StartsWith("v=", StringComparison.Ordinal)) {
                    videoid = prop.Substring(prop.IndexOf("v=", StringComparison.Ordinal) + 2);
                }
            }

            return videoid;
        }
    }
}
