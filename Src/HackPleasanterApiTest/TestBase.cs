using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackPleasanterApiTest
{
    /// <summary>
    /// テスト処理の基底クラス
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// テスト用のサーバー設定を生成する
        /// </summary>
        /// <returns></returns>
        protected ServiceConfig MakeTestConfig()
        {

            var cfg = new ServiceConfig(
                new Uri("http://localhost:8081"),
                "285f6bfc13564d4f44ae3245559fdf049833e9bb83fd295234e295ac01f4eca2ee1833593645a3b508155d1712b1edcd09d12b8f4cfe3f357d8d15560a1b63b2");

            return cfg;

        }

        #region テスト用のデータを生成する

        /// <summary>
        /// 試験対象の基準時間
        /// </summary>
        protected readonly DateTime CONST_BaseDataTime = new DateTime(2020, 1, 1, 6, 30, 0);

        /// <summary>
        /// テストにおいて、検索対象となる情報を生成する
        /// </summary>
        /// <returns></returns>
        protected async Task<List<CsharpSamples.Generated.Models.記録テーブルModel>> MakeTestTargetData(int makeItems = 10)
        {

            var cfg = MakeTestConfig();

            var rl = new List<CsharpSamples.Generated.Models.記録テーブルModel>();

            // テストデータを作る
            {
                var s = new 記録テーブルService(cfg);

                // テストデータはすべて消去する
                await s.DeleteALL(true);

                var BaseDataTime = CONST_BaseDataTime;

                for (int i = 1; i <= makeItems; i++)
                {

                    var data = new CsharpSamples.Generated.Models.記録テーブルModel();
                    data.BasicItemData.Title = "タイトルてすと";
                    data.BasicItemData.Body = "本文";
                    data.BasicItemData.Comments = "コメント";

                    // テストで検索対象となるデータを作っていく

                    data.ExtensionElements.StringA = "test" + i.ToString();

                    if (i % 3 == 0)
                    {
                        data.ExtensionElements.TypeA = "ClassC";
                    }

                    else if (i % 2 == 0)
                    {
                        data.ExtensionElements.TypeA = "ClassB";
                    }
                    else
                    {
                        data.ExtensionElements.TypeA = "ClassA";
                    }


                    data.ExtensionElements.NumA = i;

                    data.ExtensionElements.CheckA = i % 2 == 0;
                    data.ExtensionElements.DataA = BaseDataTime;
                    BaseDataTime = BaseDataTime.AddDays(1);

                    var r = await s.CreateItem(data);
                    Assert.IsNotNull(r);

                    // 取得できたIDで更新
                    data.BasicItemData.ResultId = r.Id;

                    rl.Add(data);
                }
            }

            return rl;
        }

        #endregion


    }
}
