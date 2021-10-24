using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackPleasanterApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var cfg = new ServiceConfig
            {
                uri = new Uri("http://localhost"),
                ApiKey = "cf169e5bca512d7158093fdb1030c15265d6abc08ed54fd181f6ec64c7015b304ad409222190605a2a93b587a343650d2de196827ef7917b9a3c44e8cfac873a",
                ApiVersion="1.1"
            };

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();


            var data = new CsharpSamples.Generated.Models.RecordingTableModel();

            // data.BasicItemData.Title = "タイトル";
            //data.BasicItemData.Body = "本文";

            // 個別の試験用データを設定する
            data.ExtensionElements.CheckA = true;
            data.ExtensionElements.DataA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MaxValue;
            data.ExtensionElements.StringA = "StringA";
            data.ExtensionElements.TypeA = "TypeA";


            // itemを生成する
            var x = await s.CreateItem(data);

            // 情報を更新する
            data.ExtensionElements.CheckA = false;
            data.ExtensionElements.DataA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MinValue;
            data.ExtensionElements.StringA = "StringA +1";
            data.ExtensionElements.TypeA = "TypeA +1";

            var ts = await s.UpdateItem(x.Id , data);

            // 比較用に取得する
            var r =await s.GetItem(x.Id);

         //   Assert.AreEqual(r.ExtensionElements.DataA, data.ExtensionElements.DataA);


        }
    }
}

