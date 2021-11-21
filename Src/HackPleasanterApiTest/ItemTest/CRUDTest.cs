using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static HackPleasanterApi.Client.Api.Helper.Expansions.DateTimeExpansion;
using HackPleasanterApi.Client.Api.Logging;

namespace HackPleasanterApiTest.ItemTest
{
    [TestClass]
    public class CRUDTest : TestBase
    {

        [TestInitialize]
        public void TestInitialize()
        {
            //ロガー関数の設定を行う
            LoggerManager.GetInstance().LogLevel = LogLevel.Debug;

            LoggerManager.GetInstance().LoginDebug = (x) => Console.WriteLine(x);
            LoggerManager.GetInstance().LoginInfo = (x) => Console.WriteLine(x);
        }

        [TestMethod]
        public async Task 正常系_作成更新試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            var del = await s.DeleteALL(true);


            var data = new CsharpSamples.Generated.Models.RecordingTableModel();

            data.BasicItemData.Title = "タイトルてすと";
            data.BasicItemData.Body = "本文";
            data.BasicItemData.Comments = "コメント";

            // 個別の試験用データを設定する
            data.ExtensionElements.CheckA = true;
            data.ExtensionElements.DateA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MaxValue;
            data.ExtensionElements.StringA = "StringA";
            data.ExtensionElements.TypeA = "TypeA";


            // itemを生成する
            var x = await s.CreateItem(data);

            // 情報を更新する
            data.ExtensionElements.CheckA = false;
            data.ExtensionElements.DateA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MinValue;
            data.ExtensionElements.StringA = "StringA +1";
            data.ExtensionElements.TypeA = "TypeA +1";

            var ts = await s.UpdateItem(x.Id, data);

            // 比較用に取得する
            var r = await s.GetItem(x.Id);
            Assert.AreEqual(r.ExtensionElements.CheckA_value, data.ExtensionElements.CheckA_value);

            // ToDo
            // タイムゾーンの問題を対応する
            /*
            {
                var d1 = r.ExtensionElements.DataA_value.Value;
                var d2 = data.ExtensionElements.DataA_value.Value.ToJst();

                Assert.IsTrue(d1== d2);
            }
            */

            Assert.AreEqual(r.ExtensionElements.NumA_value, data.ExtensionElements.NumA_value);
            Assert.AreEqual(r.ExtensionElements.StringA, data.ExtensionElements.StringA);
            Assert.AreEqual(r.ExtensionElements.TypeA, data.ExtensionElements.TypeA);


        }

        [TestMethod]
        public async Task 正常系_1件だけの削除試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            var del = await s.DeleteALL(true);


            var data = new CsharpSamples.Generated.Models.RecordingTableModel();

            data.BasicItemData.Title = "タイトルてすと";
            data.BasicItemData.Body = "本文";
            data.BasicItemData.Comments = "コメント";

            // 個別の試験用データを設定する
            data.ExtensionElements.CheckA = true;
            data.ExtensionElements.DateA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MaxValue;
            data.ExtensionElements.StringA = "StringA";
            data.ExtensionElements.TypeA = "TypeA";

            // itemを生成する
            var x = await s.CreateItem(data);

            // 削除を実行する
            var dr = await s.DeleteItem(x.Id);
            Assert.IsNotNull(dr);

        }
    }
}

