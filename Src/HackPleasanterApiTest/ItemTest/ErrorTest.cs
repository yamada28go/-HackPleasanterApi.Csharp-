using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static HackPleasanterApi.Client.Api.Helper.Expansions.DateTimeExpansion;
using HackPleasanterApi.Client.Api.Logging;
using HackPleasanterApi.Client.Api.Exceptions;
using HackPleasanterApi.Client.Api.Response.ApiResults;
using HackPleasanterApi.Client.Api.Response.ResponseData.Item;
using CsharpSamples.Generated.Models;

namespace HackPleasanterApiTest.ItemTest
{
    [TestClass]
    public class ErrorTest : TestBase
    {

        [TestInitialize]
        public void TestInitialize()
        {
            //ロガー関数の設定を行う
            LoggerManager.GetInstance().LogLevel = LogLevel.Debug;

            LoggerManager.GetInstance().LoginDebug = (x)=> Console.WriteLine(x);
            LoggerManager.GetInstance().LoginInfo = (x) => Console.WriteLine(x);
        }

        [TestMethod]
        public async Task 正常系_作成_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

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

            // 対象例外を発生させる
            CreateItemException targrteExp = null;
            try
            {
                // itemを生成する
                var x = await s.CreateItem(data);
            }
            catch (CreateItemException exp) {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
        }


        [TestMethod]
        public async Task 正常系_更新_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            CreateItemException targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.UpdateItem(x.Id,data);
            }
            catch (CreateItemException exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。", targrteExp.CreateItemResponse.Message);
        }


        [TestMethod]
        public async Task 正常系_取得_1件_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            GetItemException<ItemApiResults<SingleItemResponse>> targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.GetItem(x.Id);
            }
            catch (GetItemException<ItemApiResults<SingleItemResponse>> exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。",targrteExp.ItemApiResults.Message);
        }


        [TestMethod]
        public async Task 正常系_取得_複数件_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            GetItemException<ItemApiResults<MultipleItemResponse>> targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.FindItems(new  HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>());
            }
            catch (GetItemException<ItemApiResults<MultipleItemResponse>> exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。", targrteExp.ItemApiResults.Message);
        }


        [TestMethod]
        public async Task 正常系_削除_1件_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            ChangeItemResultsException targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.DeleteItem(x.Id);
            }
            catch (ChangeItemResultsException exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。", targrteExp.ChangeItemResults.Message);
        }


        [TestMethod]
        public async Task 正常系_削除_全件_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            ChangeItemResultsException targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.DeleteALL(true);
            }
            catch (ChangeItemResultsException exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。", targrteExp.ChangeItemResults.Message);
        }


        [TestMethod]
        public async Task 正常系_削除_複数_エラー発生試験()
        {

            var cfg = MakeTestConfig();

            var s = new RecordingTableService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL();

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

            // 試験用のデータを作成する
            // itemを生成する
            var x = await s.CreateItem(data);

            // --- --- ---

            // ★　APIエラーを発生させる
            cfg.ApiKey = cfg.ApiKey + "a";

            // 対象例外を発生させる
            ChangeItemResultsException targrteExp = null;
            try
            {
                // itemを生成する
                var x2 = await s.DeleteByConditions(new DeleteAllItemsRequest<RecordingTableModel>());
            }
            catch (ChangeItemResultsException exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual("認証できませんでした。", targrteExp.ChangeItemResults.Message);
        }


    }
}

