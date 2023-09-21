using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public class Common
    {

    }
    public class DingtalkToken
    {
        public int errcode { get; set; }
        public string access_token { get; set; }
        public string errmsg { get; set; }
        public int expires_in { get; set; }
        public DateTime expires_at { get; set; }
    }

    public class ChatBotRequest
    {
        public long AgentId { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public bool IsToAll { get; set; } = false;
        public List<long>? UserMobiles { get; set; }
    }
    public class CustomBotRequest
    {

        public string AccessToken { get; set; }
        public string Secret { get; set; }
        public bool IsAtAll { get; set; } = false;
    
        public List<long> UserMobiles { get; set; }
    }
    public class CustomBotMessageResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
    public class DingtalkUserInfo
    {
        public List<string> UserIds { get; set; } = new List<string>();

    }
    public class DingtalkConversationInfo
    {
        public string ConversationId { get; set; }
    }
}
