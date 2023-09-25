using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class ChatBotClient
    {
        private async Task<string?> SendNailMessage(int type, string messageText)
        {
            await GetUserId();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/ding/send");
            client.DefaultRequestHeaders.Add("x-acs-dingtalk-access-token", token.access_token);
            var body = new
            {
                robotCode = request.AppKey,
                userIds = userInfo.UserIds,
                remindType = type,
                receiverUserIdList = userInfo.UserIds,
                content = messageText
            };
            var response = await client.PostAsJsonAsync(uri, body);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonObject.Parse(responseBody);
                //Console.WriteLine(responseBody);
                return (string)json["openDingId"];
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                return "-1";
            }
        }
        public async Task<string?> SendNailText(string messageText)
        {
            return await SendNailMessage(1, messageText);
        }
        public async Task<string?> SendNailSMS(string messageText)
        {
            return await SendNailMessage(2, messageText);
        }
        public async Task<string?> SendNailCall(string messageText)
        {
            return await SendNailMessage(3, messageText);
        }
    }
}
