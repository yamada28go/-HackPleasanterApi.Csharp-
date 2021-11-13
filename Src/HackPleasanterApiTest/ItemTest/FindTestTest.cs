using System;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using HackPleasanterApi.Client.Api.Request.View.FilterKey;
using CsharpSamples.Generated.Models;
using HackPleasanterApi.Client.Api.Request.View;

namespace HackPleasanterApiTest.ItemTest
{
    /// <summary>
    /// 要素の検索条件テスト
    /// </summary>
    [TestClass]
    public class FindTestTest : TestBase
    {


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

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

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
            var findString = RecordingTableService.FilterKeys.TypeA_Choices.ClassA.ChoicesText;

            var fa = RecordingTableService.FilterKeys.TypeA;
            fa.SearchConditions = new List<ChoicesTextElement>();
            fa.SearchConditions.Add(RecordingTableService.FilterKeys.TypeA_Choices.ClassA);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(3, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.TypeA == findString).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }

        #endregion


        #region NumFilterKey

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_1件だけ()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            // Like検索
            var findString = 5;

            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKey(findString);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(1, r.ToList().Count());


            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == findString).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }


        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_2件だけ()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            // Like検索
            var findString1 = 5;
            var findString2 = 7;

            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKey(findString1);
            fa.AddKey(findString2);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(2, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == findString1).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == findString2).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }


        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_範囲検索_5番まで()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            // Like検索
            var findString1 = 5;

            // 算出条件として5以下を指定している
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyUnder(findString1);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 1〜5までのデータが取得されている想定
            for (int i = 1; i <= 5; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }


        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_範囲検索_6番から10番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 検索条件を設定
            var findString1 = 6;

            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyOver(findString1);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 5〜10までのデータが取得されている想定
            for (int i = 5; i <= 10; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_部分範囲検索_3番から6番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyRange(3, 6);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(4, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 3〜6までのデータが取得されている想定
            for (int i = 3; i <= 6; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_3番から6番_8番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyRange(3, 6);
            fa.AddKey(8);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 3〜6までのデータが取得されている想定
            for (int i = 3; i <= 6; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }


        }


        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_8番_3番から6番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // ★順番を入れ替えてみる
            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKey(8);
            fa.AddKeyRange(3, 6);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 3〜6までのデータが取得されている想定
            for (int i = 3; i <= 6; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }


        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_4番より小さい_8番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // ★順番を入れ替えてみる
            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyUnder(4);
            fa.AddKey(8);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 3〜6までのデータが取得されている想定
            for (int i = 1; i <= 4; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }


        }


        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_8番_4番より小さい()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // ★順番を入れ替えてみる
            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKey(8);
            fa.AddKeyUnder(4);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 3〜6までのデータが取得されている想定
            for (int i = 1; i <= 4; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_8番_9番より小さい()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // ★順番を入れ替えてみる
            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKeyOver(9);
            fa.AddKey(8);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(3, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 9〜10までのデータが取得されている想定
            for (int i = 9; i <= 10; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_NumFilterKey_検索試験_複合条件_9番より小さい_8番()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // ★順番を入れ替えてみる
            // 算出条件として指定
            var fa = RecordingTableService.FilterKeys.NumA;
            fa.AddKey(8);
            fa.AddKeyOver(9);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(3, r.ToList().Count());

            //試験データとして、1から10までの値を作っているので、
            // 9〜10までのデータが取得されている想定
            for (int i = 9; i <= 10; i++)
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == i).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            // 個別に8番が取れているはず
            {
                var correct = correctList.Where(x => x.ExtensionElements.NumA_value == 8).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }
        }



        #endregion


        #region CheckFilterKey

        [TestMethod]
        public async Task 正常系_種別_CheckFilterKey_検索試験_trueの場合()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            var fa = RecordingTableService.FilterKeys.CheckA;
            fa.AddKey(true);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            // trueとなっている条件を取得
            var trueList = correctList.Where(x => x.ExtensionElements.CheckA_value == true).ToList();
            foreach (var ele in trueList)
            {
                var x = r.Where(x => x.BasicItemData.IssueId == ele.BasicItemData.IssueId).FirstOrDefault();
                Assert.IsNotNull(x);
                Assert.AreEqual(x.ExtensionElements.CheckA_value, true);
            }
        }

        [TestMethod]
        public async Task 正常系_種別_CheckFilterKey_検索試験_falseの場合()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            var fa = RecordingTableService.FilterKeys.CheckA;
            fa.AddKey(false);

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(5, r.ToList().Count());

            // trueとなっている条件を取得
            var trueList = correctList.Where(x => x.ExtensionElements.CheckA_value == false).ToList();
            foreach (var ele in trueList)
            {
                var x = r.Where(x => x.BasicItemData.ResultId == ele.BasicItemData.ResultId).FirstOrDefault();
                Assert.IsNotNull(x);
                Assert.AreEqual(x.ExtensionElements.CheckA_value, false);
            }
        }


        #endregion


        #region DateFilterKey

        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_検索試験_1件だけ()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 時刻は期間で指定する。
            // 期間の指定は指定された値を含むので、
            // ギリギリ値が含みきらない範囲で指定を行う
            var fa = RecordingTableService.FilterKeys.DateA;            
            fa.AddKeyRange(CONST_BaseDataTime, CONST_BaseDataTime.AddDays(1).AddSeconds(-1));

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(1, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

        }

        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_検索試験_2件だけ()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 時刻は期間で指定する
            // 検索には指定時間も含まれるため、2件取得される
            var fa = RecordingTableService.FilterKeys.DateA;
            fa.AddKeyRange(CONST_BaseDataTime, CONST_BaseDataTime.AddDays(1));

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(2, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime.AddDays(1)).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.Skip(1).First().BasicItemData.IssueId);
            }


        }

        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_検索試験_期間指定_以下()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 時刻は期間で指定する
            // 検索には指定時間も含まれるため、2件取得される
            var fa = RecordingTableService.FilterKeys.DateA;
            fa.AddKeyUnder( CONST_BaseDataTime.AddDays(1));

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(2, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime.AddDays(1)).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.Skip(1).First().BasicItemData.IssueId);
            }


        }


        [TestMethod]
        public async Task 正常系_種別_DateFilterKey_検索試験_期間指定_以上()
        {
            //テスト対象データを作る
            var correctList = await MakeTestTargetData();

            var s = new RecordingTableService(MakeTestConfig());

            // 時刻は期間で指定する
            // 検索には指定時間も含まれるため、2件取得される
            var fa = RecordingTableService.FilterKeys.DateA;
            fa.AddKeyOver(CONST_BaseDataTime.AddDays(8));

            var v = new HackPleasanterApi.Client.Api.Request.View.View<RecordingTableModel>();
            v.Add(fa);

            // ★　検索実行
            var r = await s.FindItems(v);

            // 結果を確認
            Assert.AreEqual(2, r.ToList().Count());

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime.AddDays(8)).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.First().BasicItemData.IssueId);
            }

            {
                var correct = correctList.Where(x => x.ExtensionElements.DateA_value == CONST_BaseDataTime.AddDays(9)).First();
                Assert.AreEqual(correct.BasicItemData.IssueId, r.Skip(1).First().BasicItemData.IssueId);
            }


        }

        #endregion
    }
}

