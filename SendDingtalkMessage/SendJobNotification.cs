using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

        private async Task<string?> SendJobNotification(SendJobNotificationBody msgBody)
        {
            await GetUserId();
            msgBody.agent_id = request.AgentId;
            msgBody.userid_list = string.Join(",", userInfo.UserIds);
            msgBody.to_all_user = request.IsToAll;
            var uri = new Uri("https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2" + $"?access_token={token.access_token}");
            //client.DefaultRequestHeaders.Add("x-acs-dingtalk-access-token", token.access_token);
            var response = await client.PostAsJsonAsync(uri, msgBody);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonObject.Parse(responseBody);
                //Console.WriteLine(responseBody);
                return (string)json["task_id"];
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                return "-1";
            }
        }
        public async Task<string?> SendJobNotificationText(string messageText)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "text";
            body.msg.text.content = messageText;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationMarkdown(string messageTitle, string messageText)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "markdown";
            body.msg.markdown.title = messageTitle;
            body.msg.markdown.text = messageText;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationImage(string mediaId)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "image";
            body.msg.image.media_id = mediaId;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationLink(string messageTitle, string messageText, string picUrl, string messageUrl)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "link";
            body.msg.link.title = messageTitle;
            body.msg.link.text = messageText;
            body.msg.link.picUrl = picUrl;
            body.msg.link.messageUrl = messageUrl;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationActionCard(string messageTitle, string messageMarkdownText, string singleTitle, string singleURL, string actionUrl, string buttonTitle, string btnOrientation)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "auction_card";
            body.msg.action_card.single_url = singleURL;
            body.msg.action_card.single_title = singleTitle;
            body.msg.action_card.btn_json_list.action_url = actionUrl;
            body.msg.action_card.btn_json_list.title = buttonTitle;
            body.msg.action_card.btn_orientation = btnOrientation;
            body.msg.action_card.markdown = messageMarkdownText;
            body.msg.action_card.title = messageTitle;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationVoice(string mediaId, long duration)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "voice";
            body.msg.voice.media_id = mediaId;
            body.msg.voice.duration = duration;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationFile(string mediaId)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "file";
            body.msg.file.media_id = mediaId;
            return await SendJobNotification(body);
        }
        public async Task<string?> SendJobNotificationOA(string headBgColor, string headText, string pcMessageUrl, string statusValue, string statusBg, string fileCount, string image, string formValue, string formKey, string author, string richUnit, string richNum, string messageTitle, string messageText, string messageUrl)
        {
            SendJobNotificationBody body = new();
            body.msg.msgtype = "oa";
            body.msg.oa.head.bgcolor = headBgColor;
            body.msg.oa.head.text = headText;
            body.msg.oa.pc_message_url = pcMessageUrl;
            body.msg.oa.status_bar.status_value = statusValue;
            body.msg.oa.status_bar.status_bg = statusBg;
            body.msg.oa.body.file_count = fileCount;
            body.msg.oa.body.image = image;
            body.msg.oa.body.form.value = formValue;
            body.msg.oa.body.form.key = formKey;
            body.msg.oa.body.author = author;
            body.msg.oa.body.rich.unit = richUnit;
            body.msg.oa.body.rich.num = richNum;
            body.msg.oa.body.title = messageTitle;
            body.msg.oa.body.content = messageText;
            body.msg.oa.message_url = messageUrl;
            return await SendJobNotification(body);
        }
    }
}

