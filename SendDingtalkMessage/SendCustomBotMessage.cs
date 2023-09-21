using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class CustomBotClient
    {

        private async Task<CustomBotMessageResponse?> SendCustomBotMessage<T>(T msgBody)
        {
            var uri = GetCustomRobotUri();
            var response = await client.PostAsJsonAsync(uri, msgBody);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                //var json = JsonObject.Parse(responseBody);
                //Console.WriteLine(responseBody);
                return JsonSerializer.Deserialize<CustomBotMessageResponse>(responseBody);
                
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                return null;
            }
        }
        public async Task<CustomBotMessageResponse?> SendText(string messageText)
        {
            SendCustomBotTextBody body = new();
            body.at.atMobiles = request.UserMobiles;
            body.at.isAtAll = request.IsAtAll;
            body.text.content = messageText;
            return await SendCustomBotMessage(body);
        }
        public async Task<CustomBotMessageResponse?> SendLink(string messageTitle,string messageText,string picUrl,string messageUrl)
        {
            SendCustomBotLinkBody body = new();
            body.link.text = messageText;
            body.link.title = messageTitle;
            body.link.picUrl = picUrl;
            body.link.messageUrl = messageUrl;
            return await SendCustomBotMessage(body);
        }
        public async Task<CustomBotMessageResponse?> SendMarkdown(string messageTitle, string messageText)
        {
            SendCustomBotMarkdownBody body = new();
            body.at.atMobiles = request.UserMobiles;
            body.at.isAtAll = request.IsAtAll;
            body.markdown.title= messageTitle;
            body.markdown.text= messageText;
            return await SendCustomBotMessage(body);
        }
        public async Task<CustomBotMessageResponse?> SendActionCard(string messageTitle, string messageText,string btnOrientation,string singleTitle,string singleUrl)
        {
            SendCustomBotOverallActionCardBody body = new();
            body.actionCard.title = messageTitle;
            body.actionCard.text = messageText;
            body.actionCard.btnOrientation = btnOrientation;
            body.actionCard.singleTitle = singleTitle;
            body.actionCard.singleUrl = singleUrl;
            return await SendCustomBotMessage(body);
        }
        public async Task<CustomBotMessageResponse?> SendActionCard(string messageTitle, string messageText, string btnOrientation, List<Btn> btns)
        {
            SendCustomBotSeparateActionCardBody body = new();
            body.actionCard.title = messageTitle;
            body.actionCard.text = messageText;
            body.actionCard.btnOrientation = btnOrientation;
            body.actionCard.btns = btns;
            return await SendCustomBotMessage(body);
        }
        public async Task<CustomBotMessageResponse?> SendFeedCard(List<FeedCardLink> links)
        {
            SendCustomBotFeedCardBody body = new();
            body.feedCard.links = links;
            return await SendCustomBotMessage(body);
        }
    }
}
