using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static HackPleasanterApi.Client.Api.Helper.Expansions.DateTimeExpansion;
using HackPleasanterApi.Client.Api.Logging;
using CsharpSamples.Generated.Models;
using HackPleasanterApi.Client.Api.Request.View;

namespace HackPleasanterApiTest.ItemTest
{
    /// <summary>
    /// 削除系APIのテスト
    /// </summary>
    [TestClass]
    public class DeleteTest : TestBase
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
        public async Task 正常系_1件だけの削除試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            var del = await s.DeleteALL();

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


        [TestMethod]
        public async Task 正常系_全件物理消去()
        {
            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            var del = await s.DeleteALL();

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

            // itemを生成する
            var dr = await s.DeleteByConditions(new DeleteAllItemsRequest<CsharpSamples.Generated.Models.RecordingTableModel>
            {
                All = true,
                PhysicalDelete = true
            }); ; ;

            Assert.IsNotNull(dr);

        }


        [TestMethod]
        public async Task 正常系_IDを指定して削除()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var cfg = MakeTestConfig();
            var s = new RecordingTableService(cfg);

            //削除対象を取得
            var delTarget = correctList.Take(2).ToList();

            // 指定されたIDのitemを消去する
            var dr = await s.DeleteByConditions(new DeleteAllItemsRequest<CsharpSamples.Generated.Models.RecordingTableModel>
            {
                All = false,
                PhysicalDelete = false,
                 Selected = delTarget.Select(x=>x.BasicItemData.ResultId).ToList()
            }); 
            Assert.IsNotNull(dr);

            // 指定したデータだけが削除されているか確認する
            var read = await s.FindItems(new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>());
            Assert.AreEqual(8, read.Count());

            Assert.IsFalse(read.Select(x => x.BasicItemData.ResultId).ToList().Contains(delTarget[0].BasicItemData.ResultId));
            Assert.IsFalse(read.Select(x => x.BasicItemData.ResultId).ToList().Contains(delTarget[1].BasicItemData.ResultId));
        }


        [TestMethod]
        public async Task 正常系_条件指定削除()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // 検索条件を設定
            // Like検索
            var findString = "test10";

            var fa = RecordingTableService.FilterKeys.StringA;
            fa.SearchCondition = findString;

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // 指定条件で削除する
            var dr = await s.DeleteByConditions(new DeleteAllItemsRequest<CsharpSamples.Generated.Models.RecordingTableModel>
            {
                All = false,
                PhysicalDelete = false,
                View = v
            }); ; ;

            Assert.IsNotNull(dr);

            // 指定したデータだけが削除されているか確認する
            var read = await s.FindItems(new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>());
            Assert.AreEqual(9, read.Count());


        }



    }
}

