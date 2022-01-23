using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace TLSScraper.Data
{
    public class Scraper
    {

        public static List<TLSResult> ScrapeTLS(string searchQuery)
        {
            var results = new List<TLSResult>();
        var html = GetTLSHtml();
        var parser = new HtmlParser();
        var document = parser.ParseDocument(html);

        IHtmlCollection<IElement> searchResultElements = document.QuerySelectorAll(".post");

        foreach (IElement result in searchResultElements)
        {
            var titleSpan = result.QuerySelector("h2");
            if (titleSpan == null)
            {
                continue;
            }

            var tLSResult = new TLSResult();
            tLSResult.Title = titleSpan.TextContent;

                var blurbSpan = result.QuerySelector("small");
                if (blurbSpan == null)
                {
                    continue;
                }
                tLSResult.Blurb = titleSpan.TextContent;

                var cmntAmntSpan = result.QuerySelector("div.backtotop");
                if (cmntAmntSpan != null)
                {
                    tLSResult.CommentAmount =cmntAmntSpan.TextContent;
                }

                var imageElement = result.QuerySelector("img");
                if (imageElement != null)
                {
                    var imageSrcValue = imageElement.Attributes["src"].Value;
                    tLSResult.ImageUrl = imageSrcValue;
                }

                var anchorTag = result.QuerySelector("a");
                if (anchorTag != null)
                {
                    tLSResult.LinkUrl = anchorTag.Attributes["href"].Value;
                }
                tLSResult.Blurb = titleSpan.TextContent;
                tLSResult.Blurb = titleSpan.TextContent;
                tLSResult.Blurb = titleSpan.TextContent;

                results.Add(tLSResult);


            }

            return results;
        }

        private static string GetTLSHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = $"https://www.thelakewoodscoop.com/";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
