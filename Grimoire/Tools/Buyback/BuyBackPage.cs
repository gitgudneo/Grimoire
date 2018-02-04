using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace Grimoire.Tools.Buyback
{
    public class BuyBackPage
    {
        private readonly HtmlDocument _doc;

        public BuyBackPage(string html)
        {
            _doc = new HtmlDocument();
            _doc.LoadHtml(html);
        }

        public const string EventTarget = "GridBuyBack";
        public const string Confirm = "YES%2c+GET+NOW+FOR+FREE";

        public string EventArgument
        {
            get
            {
                try
                {
                    string full = _doc.DocumentNode.SelectNodes("//input[@type]").First().Attributes["onclick"].Value;
                    Regex r = new Regex(@"BuyNow(\$)\d{1,2}", RegexOptions.IgnoreCase);
                    return HttpUtility.UrlEncode(r.Matches(full)[0].Value);
                }
                catch { return string.Empty; }
            }
        }

        public string ViewState
        {
            get
            {
                try
                {
                    return HttpUtility.UrlEncode(_doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value);
                }
                catch { return string.Empty; }
            }
        }

        public string ViewStateGenerator
        {
            get
            {
                try
                {
                    return HttpUtility.UrlEncode(_doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']").Attributes["value"].Value);
                }
                catch { return string.Empty; }
            }
        }

        public string EventValidation
        {
            get
            {
                try
                {
                    return HttpUtility.UrlEncode(_doc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value);
                }
                catch { return string.Empty; }
            }
        }
    }
}
