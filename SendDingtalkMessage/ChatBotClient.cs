using SendDingtalkMessage;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SendDingtalkMessage
{
    public partial class ChatBotClient
    {

        private ChatBotRequest request = new ChatBotRequest();
        private DingtalkToken token = new DingtalkToken();
        private DingtalkUserInfo userInfo = new DingtalkUserInfo();
        private DingtalkConversationInfo conversationInfo = new DingtalkConversationInfo();
        private HttpClient client = new HttpClient();
        public ChatBotClient(ChatBotRequest _request)
        {
            request = _request;
        }
        public ChatBotClient(ChatBotRequest _request, DingtalkConversationInfo _conversationInfo)
        {
            request = _request;
            conversationInfo = _conversationInfo;
        }
        private async Task GetToken()
        {
            if (token == null || token.expires_at < DateTime.Now.AddSeconds(30))
            {
                var uri = new Uri("https://oapi.dingtalk.com/gettoken" + $"?appkey={request.AppKey}" + $"&appsecret={request.AppSecret}");
                //client.BaseAddress = uri;
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    //var json = JsonObject.Parse(result);
                    token = JsonSerializer.Deserialize<DingtalkToken>(result);
                    //token.access_token = (string)json["access_token"];
                    //token.errcode = (int)json["errorcode"];
                    //token.errmsg = (string)json["errmsg"];
                    //token.expires_in = (int)json["exipres_in"];
                    token.expires_at = DateTime.Now.AddSeconds(token.expires_in);
                }
            }
        }
        private async Task GetUserId()
        {
            if (!userInfo.UserIds.Any())
            {
                await GetToken();
                foreach (var item in request.UserMobiles)
                {
                    var uri = new Uri("https://oapi.dingtalk.com/topapi/v2/user/getbymobile" + $"?access_token={token.access_token}" + $"&mobile={item}");
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var json = JsonObject.Parse(result);
                        string id = (string)json["result"]["userid"];
                        userInfo.UserIds.Add(id);
                    }
                }
            }
        }
    }
}






