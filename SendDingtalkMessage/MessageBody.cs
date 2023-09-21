using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SendDingtalkMessage
{
    public partial class SendJobNotificationBody
    {
        public Msg msg { get; set; } = new();
        public bool to_all_user { get; set; }
        public long agent_id { get; set; }
        public string dept_id_list { get; set; }
        public string userid_list { get; set; }
    }

    public partial class Msg
    {
        public Voice voice { get; set; } = new();
        public File image { get; set; } = new();
        public Oa oa { get; set; } = new();
        public File file { get; set; } = new();
        public ActionCard action_card { get; set; } = new();
        public Link link { get; set; } = new();
        public Markdown markdown { get; set; } = new();
        public Text text { get; set; } = new();
        public string msgtype { get; set; }
    }

    public partial class ActionCard
    {
        public BtnJsonList btn_json_list { get; set; } = new();
        public string single_url { get; set; }
        public string btn_orientation { get; set; }
        public string single_title { get; set; }
        public string markdown { get; set; }
        public string title { get; set; }
    }

    public partial class BtnJsonList
    {
        public string action_url { get; set; }
        public string title { get; set; }
    }

    public partial class File
    {
        public string media_id { get; set; }
    }

    public partial class Link
    {
        public string picUrl { get; set; }
        public string messageUrl { get; set; }
        public string text { get; set; }
        public string title { get; set; }
    }

    public partial class Markdown
    {
        public string text { get; set; }
        public string title { get; set; }
    }

    public partial class Oa
    {
        public Head head { get; set; } = new();
        public string pc_message_url { get; set; }
        public StatusBar status_bar { get; set; } = new();
        public Body body { get; set; } = new();
        public string message_url { get; set; }
    }

    public partial class Body
    {
        public string file_count { get; set; }
        public string image { get; set; }
        public Form form { get; set; } = new();
        public string author { get; set; }
        public Rich rich { get; set; } = new();
        public string title { get; set; }
        public string content { get; set; }
    }

    public partial class Form
    {
        public string value { get; set; }
        public string key { get; set; }
    }

    public partial class Rich
    {
        public string unit { get; set; }
        public string num { get; set; }
    }

    public partial class Head
    {
        public string bgcolor { get; set; }
        public string text { get; set; }
    }

    public partial class StatusBar
    {
        public string status_value { get; set; }
        public string status_bg { get; set; }
    }

    public partial class Text
    {
        public string content { get; set; }
    }

    public partial class Voice
    {
        public long duration { get; set; }
        public string media_id { get; set; }
    }
    public partial class SendCustomBotTextBody
    {
        public At at { get; set; } = new();
        public Text text { get; set; } = new();
        public string msgtype { get; } = "text";

        public static implicit operator JsonObject(SendCustomBotTextBody v)
        {
            throw new NotImplementedException();
        }
    }

    public partial class At
    {
        public List<long> atMobiles { get; set; }
        public bool isAtAll { get; set; }
    }

    public partial class SendCustomBotLinkBody
    {
        public string msgtype { get; } = "link";
        public Link link { get; set; } = new();
    }
    public partial class SendCustomBotMarkdownBody
    {
        public string msgtype { get; } = "markdown";
        public Markdown markdown { get; set; } = new();
        public At at { get; set; } = new();
    }
    public partial class SendCustomBotOverallActionCardBody
    {
        public OverallActionCard actionCard { get; set; } = new();
        public string msgtype { get; } = "auctionCard";
    }

    public partial class OverallActionCard
    {
        public string title { get; set; }
        public string text { get; set; }
        public string btnOrientation { get; set; }
        public string singleTitle { get; set; }
        public string singleUrl { get; set; }
    }

    public partial class SendCustomBotSeparateActionCardBody
    {
        public string msgtype { get; } = "auctionCard";
        public SeparateActionCard actionCard { get; set; } = new();
    }

    public partial class SeparateActionCard
    {
        public string title { get; set; }
        public string text { get; set; }
        public string btnOrientation { get; set; }
        public List<Btn> btns { get; set; } = new();
    }

    public partial class Btn
    {
        public string title { get; set; }
        public string actionUrl { get; set; }
    }
    public partial class SendCustomBotFeedCardBody
    {
        public string msgtype { get; } = "feedCard";
        public FeedCard feedCard { get; set; } = new();
    }

    public partial class FeedCard
    {
        public List<FeedCardLink> links { get; set; } = new();
    }

    public partial class FeedCardLink
    {
        public string title { get; set; }
        public string messageUrl { get; set; }
        public string picUrl { get; set; }
    }
}

