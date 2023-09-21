using SendDingtalkMessage;

namespace SendDingtalkMessageTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            Console.WriteLine("Hello, World!");
            var dtRequest = new DingtalkRequest
            {
                AppKey = "dingejtowemsbhdyokuh",
                AppSecret = "maq8JM4xWaqjf1myYGocFQedKI-cV-qN_CpqI6WAXS7xzywQy3XfKWOWW4dNhyUM",
                UserMobiles = new List<long>
                {
                    13656691808
                }
            };
            string key = "sampleMarkdown";
            string title = "File upload complete notification";
            string text = "#### **<font color=#E45959>新受监控类型文件test.hprof上传完成</font>** \n- 目录路径: \n **<font color=#808069>\\\\\\\\\\\\192.168.11.8\\\\sumpay_cifs_server\\\\Incoming\\\\debug\\\\192.168.61.32\\\\\\\\</font>** \n- 文件路径: \n **<font color=#808069>\\\\\\\\\\\\192.168.11.8\\\\sumpay_cifs_server\\\\Incoming\\\\debug\\\\192.168.61.32\\\\\\\\test.hprof</font>**";
            string key1 = "sampleText";
            var cl = new DingtalkClient(dtRequest);
            await cl.SendMessageByRobot(key1, title, text);

        }
    }
}
