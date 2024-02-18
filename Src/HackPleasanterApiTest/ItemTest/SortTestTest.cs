using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using HackPleasanterApi.Client.Api.Request.View.FilterKey;
using HackPleasanterApi.Client.Api.Request.View;
using CsharpSamples.Generated.Models;

namespace HackPleasanterApiTest.ItemTest
{
    /// <summary>
    /// ソートテスト
    /// </summary>
    [TestClass]
    public class SortTestTest : TestBase
    {
        private new readonly DateTime CONST_BaseDataTime = new DateTime(2020, 1, 1, 6, 30, 0);

        #region テスト用のデータを生成する

        /// <summary>
        /// テストにおいて、検索対象となる情報を生成する
        /// </summary>
        /// <returns></returns>
        private async Task<List<CsharpSamples.Generated.Models.記録テーブルModel>> MakeTestTargetData()
        {

            var cfg = MakeTestConfig();

            var rl = new List<CsharpSamples.Generated.Models.記録テーブルModel>();

            // テストデータを作る
            {
                var s = new 記録テーブルService(cfg);

                // テストデータはすべて消去する
                await s.DeleteALL(true);

                var BaseDataTime = CONST_BaseDataTime;

                for (int i = 1; i <= 10; i++)
                {

                    var data = new CsharpSamples.Generated.Models.記録テーブルModel();
                    data.BasicItemData.Title = "タイトルてすと";
                    data.BasicItemData.Body = "本文";
                    data.BasicItemData.Comments = "コメント";

                    // テストで検索対象となるデータを作っていく

                    data.ExtensionElements.StringA = "test" + i.ToString();
                    data.ExtensionElements.TypeA = "Class" + i.ToString();

                    data.ExtensionElements.NumA = i;

                    data.ExtensionElements.CheckA = i % 2 == 0;
                    data.ExtensionElements.DataA = BaseDataTime;
                    BaseDataTime = BaseDataTime.AddDays(1);

                    await s.CreateItem(data);

                    rl.Add(data);
                }
            }

            return rl;
        }

        #endregion

#if false
        #region DescriptionFilterKey

        [TestMethod]
        public async Task 正常系_種別_DescriptionFilterKey_検索試験()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            // Like検索
            var findString = "test10";

            var fa = RecordingTableService.FilterKeys.StringA;
            fa.SearchCondition = findString;

            var v = new HackPleasanterApi.Client.Api.Request.View.View();
            v.ColumnFilter = new System.Collections.Generic.List<HackPleasanterApi.Client.Api.Request.View.FilterKey.ColumnFilterHashGenerateInterface>();
            v.ColumnFilter.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(1, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.StringA == findString).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }

        #endregion

        #region ClassFilterKey

        [TestMethod]
        public async Task 正常系_種別_ClassFilterKey_検索試験()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            // Like検索
            var findString = "Class10";

            var fa = RecordingTableService.FilterKeys.TypeA;
            fa.SearchConditions = new List<string>();
            fa.SearchConditions.Add(findString);

            var v = new HackPleasanterApi.Client.Api.Request.View.View();
            v.ColumnFilter = new System.Collections.Generic.List<HackPleasanterApi.Client.Api.Request.View.FilterKey.ColumnFilterHashGenerateInterface>();
            v.ColumnFilter.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(1, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.TypeA == findString).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }

        #endregion

#endif

        #region NumFilterKey

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_ソート試験_降順()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            var sortKey = 記録テーブルService.ColumnSorterKeys.NumA;
            sortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Desc;
            v.Add(sortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            //　値は大きい順で指定されている
            for (int i = 0; i < correctList.Count; i++)
            {
                var tr = r[i];
                Assert.AreEqual(tr.ExtensionElements.NumA, correctList.Count - i);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_ソート試験_昇順()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            var sortKey = 記録テーブルService.ColumnSorterKeys.NumA;
            sortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Asc;
            v.Add(sortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            //　値は大きい順で指定されている
            for (int i = 1; i <= 10; i++)
            {
                var tr = r[i - 1];
                Assert.AreEqual(tr.ExtensionElements.NumA, i);
            }
        }

        #endregion

        #region CheckFilterKey

        [TestMethod]
        public async Task 正常系_種別_CheckSortKey_ソート試験_昇順()
        {

            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            // チェックを第一要素に
            var chSortKey = 記録テーブルService.ColumnSorterKeys.CheckA;
            chSortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Desc;
            v.Add(chSortKey);

            // Numを第２要素にする
            var numSortKey = 記録テーブルService.ColumnSorterKeys.NumA;
            numSortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Desc;
            v.Add(numSortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            // 二重の条件でソートされてくる
            // 検索結果の上部にはtrueが集まっている
            Assert.AreEqual(r[0].ExtensionElements.NumA, 10);
            Assert.AreEqual(r[1].ExtensionElements.NumA, 8);
            Assert.AreEqual(r[2].ExtensionElements.NumA, 6);
            Assert.AreEqual(r[3].ExtensionElements.NumA, 4);
            Assert.AreEqual(r[4].ExtensionElements.NumA, 2);

            // trueの後にfalseが集まっている
            Assert.AreEqual(r[5].ExtensionElements.NumA, 9);
            Assert.AreEqual(r[6].ExtensionElements.NumA, 7);
            Assert.AreEqual(r[7].ExtensionElements.NumA, 5);
            Assert.AreEqual(r[8].ExtensionElements.NumA, 3);
            Assert.AreEqual(r[9].ExtensionElements.NumA, 1);

        }

        [TestMethod]
        public async Task 正常系_種別_CheckSortKey_ソート試験_降順()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            // チェックを第一要素に
            var chSortKey = 記録テーブルService.ColumnSorterKeys.CheckA;
            chSortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Asc;
            v.Add(chSortKey);

            // Numを第２要素にする
            var numSortKey = 記録テーブルService.ColumnSorterKeys.NumA;
            numSortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Desc;
            v.Add(numSortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            // 二重の条件でソートされてくる
            // 検索結果の上部にはtrueが集まっている
            Assert.AreEqual(r[5].ExtensionElements.NumA, 10);
            Assert.AreEqual(r[6].ExtensionElements.NumA, 8);
            Assert.AreEqual(r[7].ExtensionElements.NumA, 6);
            Assert.AreEqual(r[8].ExtensionElements.NumA, 4);
            Assert.AreEqual(r[9].ExtensionElements.NumA, 2);

            // trueの後にfalseが集まっている
            Assert.AreEqual(r[0].ExtensionElements.NumA, 9);
            Assert.AreEqual(r[1].ExtensionElements.NumA, 7);
            Assert.AreEqual(r[2].ExtensionElements.NumA, 5);
            Assert.AreEqual(r[3].ExtensionElements.NumA, 3);
            Assert.AreEqual(r[4].ExtensionElements.NumA, 1);
        }

        #endregion

        #region DateFilterKey


        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_ソート試験_降順()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            var sortKey = 記録テーブルService.ColumnSorterKeys.DataA;
            sortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Desc;
            v.Add(sortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            //　値は大きい順で指定されている
            for (int i = 0; i < correctList.Count; i++)
            {
                var tr = r[i];
                Assert.AreEqual(tr.ExtensionElements.NumA, correctList.Count - i);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_ソート試験_昇順()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new 記録テーブルService(MakeTestConfig());

            var v = new HackPleasanterApi.Client.Api.Request.View.View<記録テーブルModel>();

            var sortKey = 記録テーブルService.ColumnSorterKeys.DataA;
            sortKey.ColumnSorterType = HackPleasanterApi.Client.Api.Request.View.ColumnSorterType.Asc;
            v.Add(sortKey);

            // ★　検索実行
            var r = (await s.FindItems(v)).ToList();

            // 結果を確認
            Assert.AreEqual(10, r.ToList().Count());

            //　値は大きい順で指定されている
            for (int i = 1; i <= 10; i++)
            {
                var tr = r[i - 1];
                Assert.AreEqual(tr.ExtensionElements.NumA, i);
            }
        }


        #endregion

    }
}

