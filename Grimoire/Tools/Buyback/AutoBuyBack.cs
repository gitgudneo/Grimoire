using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Grimoire.Tools.Buyback
{
    // TODO: Rewrite entirely, this is difficult to understand
    public class AutoBuyBack : IDisposable
    {
        protected internal string Username => Flash.Call<string>("GetUsername");
        protected internal string Password => Flash.Call<string>("GetPassword");

        private const string UrlBuyBack = "inventory.aspx?tab=buyback";

        private readonly HttpClient _client;

        public AutoBuyBack()
        {
            _client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                CookieContainer = new CookieContainer()
            })
            {
                BaseAddress = new Uri("https://www.aq.com/acct/")
            };
        }

        public async Task Perform(string item, int pageCap)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return;

            string buyBackPage;
            if (string.IsNullOrEmpty(buyBackPage = await SendPost(string.Empty, $"uuu={Username}&pps={Password}&submit=")))
                return;

            string[] itemInfo;
            if ((itemInfo = await GetItemHtml(buyBackPage, item, pageCap)).Length < 2)
                return;

            BuyBackPage itemArgs = new BuyBackPage(itemInfo[0]);
            BuyBackPage itemSelected = new BuyBackPage(itemInfo[1]);

            string reqPurchase = $"__EVENTTARGET={BuyBackPage.EventTarget}&__EVENTARGUMENT={itemArgs.EventArgument}&" +
                                    $"__VIEWSTATE={itemSelected.ViewState}&__VIEWSTATEGENERATOR={itemSelected.ViewStateGenerator}&" +
                                    "__VIEWSTATEENCRYPTED=&" +
                                    $"__EVENTVALIDATION={itemSelected.EventValidation}";

            string reqResponse;
            if (string.IsNullOrEmpty(reqResponse = await SendPost(UrlBuyBack, reqPurchase)))
                return;

            BuyBackPage itemConfirm = new BuyBackPage(reqResponse);

            string reqConfirm = $"__VIEWSTATE={itemConfirm.ViewState}&__VIEWSTATEGENERATOR={itemConfirm.ViewStateGenerator}&" +
                                        "__VIEWSTATEENCRYPTED=&" +
                                        $"__EVENTVALIDATION={itemConfirm.EventValidation}&btnConfirmYes={BuyBackPage.Confirm}";

            await SendPost(UrlBuyBack, reqConfirm);
        }

        private async Task<string[]> GetItemHtml(string lastRequestedPage, string item, int cap)
        {
            string[] ret = new string[2];

            for (int i = 1; i <= cap; i++)
            {
                BuyBackPage p = new BuyBackPage(lastRequestedPage);
                string data = $"__EVENTTARGET={BuyBackPage.EventTarget}&__EVENTARGUMENT=Page%24{i}&" +
                              $"__VIEWSTATE={p.ViewState}&__VIEWSTATEGENERATOR={p.ViewStateGenerator}&" +
                              $"__VIEWSTATEENCRYPTED=&__EVENTVALIDATION={p.EventValidation}";

                string response = await SendPost(UrlBuyBack, data);
                lastRequestedPage = response;

                foreach (string line in response.Split('\n'))
                {
                    if (line.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        ret[0] = line;
                        ret[1] = response;
                        return ret;
                    }
                }
            }

            return ret;
        }

        private async Task<string> SendPost(string url, string postData)
        {
            try
            {
                return HttpUtility.HtmlDecode(await _client.PostAsync(url, new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"))
                    .Result.Content.ReadAsStringAsync());
            }
            catch { return string.Empty; }
        }

        private async Task<string> SendGet(string url)
        {
            try
            {
                return HttpUtility.HtmlDecode(await _client.GetStringAsync(url));
            }
            catch { return string.Empty; }
        }

        public void Dispose()
        {
            SendGet("logout.aspx").Wait();
            _client.Dispose();
        }
    }
}
