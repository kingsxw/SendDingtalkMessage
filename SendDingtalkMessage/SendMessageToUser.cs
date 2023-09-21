using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class ChatBotClient
    {
        private async Task<string?> SendMessageToUser(string key, string param)
        {
            await GetUserId();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/oToMessages/batchSend");
            client.DefaultRequestHeaders.Add("x-acs-dingtalk-access-token", token.access_token);
            var body = new
            {
                robotCode = request.AppKey,
                userIds = userInfo.UserIds,
                msgKey = key,
                msgParam = param
            };
            var response = await client.PostAsJsonAsync(uri, body);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonObject.Parse(responseBody);                
                //Console.WriteLine(responseBody);
                return (string)json["processQueryKey"];
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                return "-1";
            }
        }
        public async Task<string?> SendText(string messageText)
        {
            string msgKey = "sampleText";
            string msgParam = "{\u0022content\u0022: \u0022" + messageText + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendMarkdown(string messageTitle, string messageText)
        {
           string msgKey = "sampleMarkdown";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendImage(string photoURL)
        {
            string msgKey = "sampleImageMsg";
            string msgParam = "{\u0022photoURL\u0022: \u0022" + photoURL + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendLink(string messageTitle, string messageText, string picUrl, string messageUrl)
        {
            string msgKey = "sampleLink";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022picUrl\u0022: \u0022" + picUrl + "\u0022,\u0022messageUrl\u0022: \u0022" + messageUrl + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string singleTitle, string singleURL)
        {
            string msgKey = "sampleActionCard";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022singleTitle\u0022: \u0022" + singleTitle + "\u0022,\u0022singleURL\u0022: \u0022" + singleURL + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2)
        {
            string msgKey = "sampleActionCard2";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3)
        {
            string msgKey = "sampleActionCard3";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4)
        {
            string msgKey = "sampleActionCard4";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5)
        {
            string msgKey = "sampleActionCard5";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022,\u0022actionTitle5\u0022: \u0022" + actionTitle5 + "\u0022,\u0022actionURL5\u0022: \u0022" + actionURL5 + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5, string actionTitle6, string actionURL6)
        {
            string msgKey = "sampleActionCard6";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022actionTitle1\u0022: \u0022" + actionTitle1 + "\u0022,\u0022actionURL1\u0022: \u0022" + actionURL1 + "\u0022,\u0022actionTitle2\u0022: \u0022" + actionTitle2 + "\u0022,\u0022actionURL2\u0022: \u0022" + actionURL2 + "\u0022,\u0022actionTitle3\u0022: \u0022" + actionTitle3 + "\u0022,\u0022actionURL3\u0022: \u0022" + actionURL3 + "\u0022,\u0022actionTitle4\u0022: \u0022" + actionTitle4 + "\u0022,\u0022actionURL4\u0022: \u0022" + actionURL4 + "\u0022,\u0022actionTitle5\u0022: \u0022" + actionTitle5 + "\u0022,\u0022actionURL5\u0022: \u0022" + actionURL5 + "\u0022,\u0022actionTitle6\u0022: \u0022" + actionTitle6 + "\u0022,\u0022actionURL6\u0022: \u0022" + actionURL6 + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendAudio(string mediaId, long duration)
        {
            string msgKey = "sampleAudio";
            string msgParam = "{\u0022mediaId\u0022: \u0022" + mediaId + "\u0022,\u0022duration\u0022: \u0022" + duration + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendFile(string mediaId, string fileName, string fileType)
        {
            string msgKey = "sampleFile";
            string msgParam = "{\u0022mediaId\u0022: \u0022" + mediaId + "\u0022,\u0022fileName\u0022: \u0022" + fileName + "\u0022,\u0022fileType\u0022: \u0022" + fileType + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
        public async Task<string?> SendVideo(string messageTitle, string messageText, string picUrl, string messageUrl)
        {
            string msgKey = "sampleVideo";
            string msgParam = "{\u0022title\u0022: \u0022" + messageTitle + "\u0022,\u0022text\u0022: \u0022" + messageText + "\u0022,\u0022picUrl\u0022: \u0022" + picUrl + "\u0022,\u0022messageUrl\u0022: \u0022" + messageUrl + "\u0022}";
            return await SendMessageToUser(msgKey, msgParam);
        }
    }
}
