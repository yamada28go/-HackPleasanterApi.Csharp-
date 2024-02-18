using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using HackPleasanterApi.Client.Api.Helper.Models.ItemModel.Hash;

namespace HackPleasanterApiTest.ItemTest
{
    /// <summary>
    /// ファイル添付試験
    /// </summary>
    [TestClass]
    public class AttachmentsTest : TestBase
    {

        private string GetCurrentPass()
        {
            return Path.Combine(System.Environment.CurrentDirectory, @"data", @"attachments");

        }


        [TestMethod]
        public async Task 正常系_作成更新試験()
        {

            var cfg = MakeTestConfig();

            var s = new 記録テーブルService(cfg);

            // テストデータはすべて消去する
            await s.DeleteALL(true);


            var data = new CsharpSamples.Generated.Models.記録テーブルModel();

            data.BasicItemData.Title = "タイトルてすと";
            data.BasicItemData.Body = "本文";
            data.BasicItemData.Comments = "コメント";

            // 個別の試験用データを設定する
            data.ExtensionElements.CheckA = true;
            data.ExtensionElements.DataA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MaxValue;
            data.ExtensionElements.StringA = "StringA";
            data.ExtensionElements.TypeA = "TypeA";

            // テストデータを読み取る
            var a = AttachmentsHelper.MakeAttachmentsFromFile(Path.Combine(GetCurrentPass(), @"sky.jpg"));
            data.ExtensionElements.テストデータ_添付ファイルA = new System.Collections.Generic.List<HackPleasanterApi.Client.Api.Models.ItemModel.Hash.Attachments>();
            data.ExtensionElements.テストデータ_添付ファイルA.Add(a);

            // itemを生成する
            var x = await s.CreateItem(data);

            // 情報を更新する
            data.ExtensionElements.CheckA = false;
            data.ExtensionElements.DataA = DateTime.Now;
            data.ExtensionElements.NumA = Int32.MinValue;
            data.ExtensionElements.StringA = "StringA +1";
            data.ExtensionElements.TypeA = "TypeA +1";

            Assert.IsTrue(x.Id.HasValue);
            var ts = await s.UpdateItem(x?.Id ?? -1, data);

            // 比較用に取得する
            var r = await s.GetItem(x?.Id ?? -1);

            // そのまま更新するとitemは2個に複製される
            Assert.AreEqual(2, r.ExtensionElements.テストデータ_添付ファイルA.Count);

            // 対象のデータを取得する
            var rData = await s.GetAttachments(r.ExtensionElements.テストデータ_添付ファイルA[0]);

            Assert.AreEqual(rData.Response.Base64, a.Base64);

            Assert.AreEqual(r.ExtensionElements.CheckA, data.ExtensionElements.CheckA);

            //ToDo : タイムフオセットは調整が必要
            // Assert.AreEqual(r.ExtensionElements.DateA_value, data.ExtensionElements.DateA_value);

            Assert.AreEqual(r.ExtensionElements.NumA, data.ExtensionElements.NumA);
            Assert.AreEqual(r.ExtensionElements.StringA, data.ExtensionElements.StringA);
            Assert.AreEqual(r.ExtensionElements.TypeA, data.ExtensionElements.TypeA);


        }

    }
}

