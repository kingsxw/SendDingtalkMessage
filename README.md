## 通过钉钉企业内部应用/机器人/自定义机器人发送单聊/群聊/工作通知



#### **使用方法**

NuGet包管理器搜索SendDingtalkMessage

或

```
dotnet add package SendDingtalkMessage
```



------



#### 20231211 V1.0.3 错误修复

- 修复部分SendMessageToGroup方法错误引用SendMessageToUser
- 修改目标框架，支持.NET7.0和.NET 8.0

------



#### 20231113 V1.0.2 错误修复

- 修复撤回功能，补全之前遗漏的x-acs-dingtalk-access-token头
- 拆分和修正RecallPrivateChatMessage和RecallGroupMessage方法



------



#### 20230925 V1.0.1 增加发送DING的功能(需专属钉钉或者专业版钉钉)

###### *具体信息参见钉钉文档[发送DING消息](https://open.dingtalk.com/document/orgapp/robot-sends-nail-message)*

- **发送DING**

```c#
#发送应用内DING
await Client.SendNailText(string messageText);

#发送短信DING
await Client.SendNailSMS(string messageText);

#发送电话DING
await Client.SendNailCall(string messageText);
```

- **撤回DING：**

```C#
var openDingId = Client.SendNailText("text");
Client.RecallNailMessage(openDingId);
```



------



#### 通过企业内部应用/机器人发送消息

- **初始化单聊/群聊请求：**

```c#
var request = new ChatBotRequest
{
    AgentId = 1xxxx,
    AppKey = "dingxxxx",
    AppSecret = "xxxx-xxxx-xxx",
    UserMobiles = new List<long>
                {
                    13xxxx,
                    18xxxx
                }，
    IsToAll = false		//是否@所有人，默认false
};

#初始化conversation信息，群聊必须
var conversation = new DingtalkConversationInfo
{
    ConversationId = "cidxxxx"
};

var client = new ChatBotClient(request); #单聊
var client = new ChatBotClient(request,conversation); #单聊+群聊
```

- **发送单聊/群聊消息到用户：**

###### *具体消息格式参见钉钉文档[机器人发送消息的类型 - 钉钉开放平台 (dingtalk.com)](https://open.dingtalk.com/document/orgapp/types-of-messages-sent-by-robots)*

```c#
#撤回消息((可撤回多条，自行创建List<string> queryKeys传递)
await RecallMessage(List<string> queryKeys); #单人
await RecallGroupMessage(List<string> queryKeys); #群
#例如:
var key = Client.SendText("text"); 
await Client.RecallMessage(key.Select(c => c.ToString()).ToList()); 

#发送Text消息
await Client.SendText(string messageText); #单人
await Client.SendGroupText(string messageText); #群

#发送Markdown消息
await Client.SendMarkdown(string messageTitle, string messageText); #单人
await Client.SendGroupMarkdown(string messageTitle, string messageText); #群

#发送Image消息
await Client.SendImage(string photoURL); #单人
await Client.SendGroupImage(string photoURL); #群

#发送Link消息
await Client.SendLink(string messageTitle, string messageText, string picUrl, string messageUrl); #单人
await Client.SendGroupLink(string messageTitle, string messageText, string picUrl, string messageUrl); #群

#发送ActionCard消息
await Client.SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, [string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5, string actionTitle6, string actionURL6]); #单人,支持1-6
await Client.SendActionCard(string messageTitle, string messageText, string actionTitle1, string actionURL1, [string actionTitle2, string actionURL2, string actionTitle3, string actionURL3, string actionTitle4, string actionURL4, string actionTitle5, string actionURL5, string actionTitle6, string actionURL6]); #群，支持1-6

#发送Audio消息
await Client.SendAudio(string mediaId, long duration) #单人
await Client.SendGroupAudio(string mediaId, long duration) #群

#发送File消息
await Client.SendFile(string mediaId, string fileName, string fileType) #单人
await Client.SendGroupFile(string mediaId, string fileName, string fileType) #群

#发送Video消息
await Client.SendVideo(string messageTitle, string messageText, string picUrl, string messageUrl) #单人
await Client.SendGroupVideo(string messageTitle, string messageText, string picUrl, string messageUrl) #群
```

- **发送工作通知：**

###### *具体消息格式参见钉钉文档[发送工作通知 - 钉钉开放平台 (dingtalk.com)](https://open.dingtalk.com/document/orgapp/asynchronous-sending-of-enterprise-session-messages)*

```c#
#撤回消息：
await RecallJobNotificationMessage(string msgTaskId);
##例如:
var key = Client.SendJobNotificationText("text"); #事先获取task_id
await Client.RecallJobNotificationMessage(key); 

#发送Text消息
await Client.SendJobNotificationText(string messageText);

#发送Markdown消息
await Client.SendJobNotificationMarkdown(string messageTitle, string messageText);

#发送Image消息
await Client.SendJobNotificationImage(string mediaId);

#发送Link消息
await Client.SendJobNotificationLink(string messageTitle, string messageText, string picUrl, string messageUrl);

#发送ActionCard消息
await Client.SendJobNotificationActionCard(string messageTitle, string messageMarkdownText, string singleTitle, string singleURL, string actionUrl, string buttonTitle, string btnOrientation);

#发送Voice消息
await Client.SendJobNotificationVoice(string mediaId, long duration);

#发送File消息
await Client.SendJobNotificationFile(string mediaId);

#发送OA消息
await Client.SendJobNotificationOA(string headBgColor, string headText, string pcMessageUrl, string statusValue, string statusBg, string fileCount, string image, string formValue, string formKey, string author, string richUnit, string richNum, string messageTitle, string messageText, string messageUrl);
```



#### 通过企业内部应用/机器人发送消息

- **初始化自定义机器人请求：**

```c#
var request = new CustomBotRequest
{
    AccessToken = "7fb3xxxx",
    Secret = "SECxxxx",		//加签密钥，可选
    IsAtAll = false,		//是否@所有人，默认false
    UserMobiles = new List<long>
    {
        13xxxx,
        18xxxx
    }
};
var client = new CustomBotClient(request);
```

- **发送群聊消息：**

###### *具体消息格式参见钉钉文档[自定义机器人发送群消息 - 钉钉开放平台 (dingtalk.com)](https://open.dingtalk.com/document/orgapp/custom-robots-send-group-messages)*

```c#
#发送Text消息
await Client.SendText(string messageText);

#发送Markdown消息
await Client.SendMarkdown(string messageTitle, string messageText);

#发送Link消息
await Client.SendLink(string messageTitle,string messageText,string picUrl,string messageUrl);

#发送整体跳转ActionCard消息
await Client.SendActionCard(string messageTitle, string messageText,string btnOrientation,string singleTitle,string singleUrl);

#发送独立跳转ActionCard消息
await Client.SendActionCard(string messageTitle, string messageText, string btnOrientation, List<Btn> btns);

#发送FeedCard消息
await Client.SendFeedCard(List<FeedCardLink> links);
```

