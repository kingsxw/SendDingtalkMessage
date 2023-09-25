using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class ChatBotClient
    {

        public async Task RecallMessage(List<string> queryKeys)
        {
            await GetToken();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/otoMessages/batchRecall");
            var body = new
            {
                robotCode = request.AppKey,
                processQueryKeys = queryKeys
            };
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
        public async Task RecallNailMessage(string openDingId)
        {
            await GetToken();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/ding/recall");
            var body = new
            {
                robotCode = request.AppKey,
                openDingId = openDingId
            };
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
        public async Task RecallGroupMessage(List<string> queryKeys)
        {
            await GetToken();
            var uri = new Uri("https://api.dingtalk.com/v1.0/robot/privateChatMessages/batchRecall");
            var body = new
            {
                openConversationId = conversationInfo.ConversationId,
                robotCode = request.AppKey,
                processQueryKeys = queryKeys
            };

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
        public async Task RecallJobNotificationMessage(string msgTaskId)
        {
            await GetToken();
            var uri = new Uri("https://oapi.dingtalk.com/topapi/message/corpconversation/recall" + $"?access_token={token.access_token}");
            var body = new
            {
                msg_task_id = msgTaskId,
                agent_id = request.AgentId
            };
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
    }

}