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

            var cfg = new ServiceConfig
            {
                uri = new Uri("http://localhost"),
                ApiKey = "67e88eff585b9b02b6103de751f2affe2cc9b4ff608533c91bad06477f082d3f306f74f9500a27ed2044b037f922f4c092280b4b99327333882022fd04bbdcf5",
                ApiVersion = "1.1"
            };

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
        protected async Task<List<CsharpSamples.Generated.Models.RecordingTableModel>> MakeTestTargetData(int makeItems = 10)
        {

            var cfg = MakeTestConfig();

            var rl = new List<CsharpSamples.Generated.Models.RecordingTableModel>();

            // テストデータを作る
            {
                var s = new RecordingTableService(cfg);

                // テストデータはすべて消去する
                await s.DeleteALL(true);

                var BaseDataTime = CONST_BaseDataTime;

                for (int i = 1; i <= makeItems; i++)
                {

                    var data = new CsharpSamples.Generated.Models.RecordingTableModel();
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
                    data.ExtensionElements.DateA = BaseDataTime;
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
