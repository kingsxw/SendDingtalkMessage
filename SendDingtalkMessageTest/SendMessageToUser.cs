using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class DingtalkClient
    {
        private async Task SendMessageToUser(object body)
        {
            await GetUserId();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/oToMessages/batchSend");
            client.DefaultRequestHeaders.Add("x-acs-dingtalk-access-token", token.access_token);
            var response = await client.PostAsJsonAsync(uri, body);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public async Task SendText(string messageText)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleText",
                msgParam = "{\u0022content\u0022: \u0022" + messageText + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendMarkdown(string messageTitle, string messageText)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleMarkdown",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendImage(string photoURL)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleImageMsg",
                msgParam = "{\u0022photoURL\u0022: \u0022" + photoURL + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendLink(string messageTitle, string messageText, string picUrl, string messageUrl)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleLink",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022picUrl\u0022: \u0022" + picUrl + "\u0022,\u0022messageUrl\u0022: \u0022" + messageUrl + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string singleTitle, string singleURL)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022singleTitle\u0022: \u0022" + singleTitle + "\u0022,\u0022singleURL\u0022: \u0022" + singleURL + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard2",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard3",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard4",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard5",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022,\u0022actionTitle5\u0022: \u0022" + actionTitle5 + "\u0022,\u0022actionURL5\u0022: \u0022" + actionURL5 + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5, string actionTitle6, string actionURL6)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleActionCard6",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022,\u0022actionTitle5\u0022: \u0022" + actionTitle5 + "\u0022,\u0022actionURL5\u0022: \u0022" + actionURL5 + "\u0022,\u0022actionTitle6\u0022: \u0022" + actionTitle6 + "\u0022,\u0022actionURL6\u0022: \u0022" + actionURL6 + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendAudio(string mediaId, int duration)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleAudio",
                msgParam = "{\u0022mediaId\u0022: \u0022" + mediaId + "\u0022,\u0022duration\u0022: \u0022" +duration + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendFile(string mediaId, string messageText, string picUrl, string messageUrl)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleFile",
                msgParam = "{\u0022mediaId\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022picUrl\u0022: \u0022" + picUrl + "\u0022,\u0022messageUrl\u0022: \u0022" + messageUrl + "\u0022}"
            };
            await SendMessageToUser(body);
        }
        public async Task SendVideo(string messageTitle, string messageText, string picUrl, string messageUrl)
        {
            object body = new
            {
                robotCode = request.AppKey,
                userIds = userinfo.UserIds,
                msgKey = "sampleVideo",
                msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022picUrl\u0022: \u0022" + picUrl + "\u0022,\u0022messageUrl\u0022: \u0022" + messageUrl + "\u0022}"
            };
            await SendMessageToUser(body);
        }
    }
}
