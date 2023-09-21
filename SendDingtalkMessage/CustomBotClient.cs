using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SendDingtalkMessage
{
    public partial class CustomBotClient
    {
        private CustomBotRequest request = new CustomBotRequest();
        private DingtalkToken token = new DingtalkToken();
        private HttpClient client = new HttpClient();
        public CustomBotClient(CustomBotRequest _request)
        {
            request = _request;
        }
        private Uri GetCustomRobotUri()
        {
            Uri uri;
            if (string.IsNullOrWhiteSpace(request.Secret))
            {
                uri = new Uri("https://oapi.dingtalk.com/robot/send" + $"?access_token={request.AccessToken}");
            }
            else
            {
                long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                string stringToSign = timestamp + "\n" + request.Secret;
                var hmacsha = new HMACSHA256
                {
                    Key = Encoding.UTF8.GetBytes(request.Secret)
                };
                var signData = Convert.ToBase64String(hmacsha.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                var sign = UrlEncoder.Default.Encode(signData);                
                uri = new Uri("https://oapi.dingtalk.com/robot/send" + $"?access_token={request.AccessToken}" + $"&timestamp={timestamp}" + $"&sign={sign}");
            }
            return uri;
        }
    }
}
