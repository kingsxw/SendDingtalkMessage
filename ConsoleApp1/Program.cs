// See https://aka.ms/new-console-template for more information
using SendDingtalkMessage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
var dtRequest = new ChatBotRequest
{
    AgentId = 1806457340,
    AppKey = "dingo6qb6r2iaxlyi6me",
    AppSecret = "rjAsgamasSB-rGowQxs1swFCxwpYSlCrz6QoigslKe7LBY6BO52ADKXaPhvN-5q2",
    UserMobiles = new List<long>
                {
                    13656691808,
                    18458111190
                },
    IsToAll = false
};
var dtconv = new DingtalkConversationInfo
{
    ConversationId = "cidbvbYvP8ec/JZeQFVW6K9Kw=="
};



string key = "sampleMarkdown";
string title = "File upload complete notification";
string text = "@13656691808 @13250841818 #### **<font color=#E45959>新受监控类型文件test.hprof上传完成</font>** \n- 目录路径: \n **<font color=#808069>\\\\\\\\\\\\192.168.11.8\\\\sumpay_cifs_server\\\\Incoming\\\\debug\\\\192.168.61.32\\\\\\\\</font>** \n- 文件路径: \n **<font color=#808069>\\\\\\\\\\\\192.168.11.8\\\\sumpay_cifs_server\\\\Incoming\\\\debug\\\\192.168.61.32\\\\\\\\test.hprof</font>**";
string key1 = "sampleText";
string text1 = "testtttttt";
//var Client
//    = new ChatBotClient(dtRequest, dtconv);
//cl.SendText(text);
//string a = await Client.SendText(text1);
//await Client.RecallMessage(a.Select(c => c.ToString()).ToList());
////var t1 = await cl.SendText(text1);
//var t2 = await cl.SendJobNotificationText("下班了");
////await cl.SendText(text1);
//Console.WriteLine(t2);

var request2 = new CustomBotRequest
{
    AccessToken = "10d673d0c09a49a006b2e41bf47d7d1923c75f7d873316aa1f1d27475bf184a8",
    Secret = "SEC34faae2b481ee7267753193b60daf3592f67f49bd05215374406259476bf2fd3",
    IsAtAll = false,
    UserMobiles = new List<long>
    {
        13656691808,
        13250841818
    }
};
var crc = new CustomBotClient(request2);
var t = await crc.SendMarkdown(text1,text);
Console.WriteLine(t.errcode);
Console.WriteLine(t.errmsg);