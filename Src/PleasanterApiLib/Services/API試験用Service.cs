/**
 *
 * [注意]
 *  自動生成されたコードです。
 *  変更時には十分注意して変更してください。
 *
 *  [生成コマンド]
 *  https://github.com/yamada28go/HackPleasanterApiCli
 *
 *  [生成元テンプレートファイル]
 *  https://github.com/yamada28go/HackPleasanterApi.Csharp
 *
 *  [動作に必用なライブラリ]
 *  https://www.nuget.org/packages/HackPleasanterApi.Csharp
 *
 */


using CsharpSamples.Generated.Models;
using HackPleasanterApi.Client.Api.Request.View;
using HackPleasanterApi.Client.Api.Request.View.FilterKey;
using HackPleasanterApi.Client.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;


namespace CsharpSamples.Generated.Service
{

    /// <summary>
    /// API試験用アクセスサービス
    /// </summary>
    public class API試験用Service : ItmeServiceBase<API試験用Model, API試験用Model.API試験用ModelExtensionElements>
    {
        /// <summary>
        /// サイトID
        /// </summary>
        private static readonly long SITE_ID_CONSTANT = 2;


        public API試験用Service(ServiceConfig config) : base(config, SITE_ID_CONSTANT)
        {
        }


        /// <summary>
        /// サイトIdを取得する
        /// </summary>
        /// <returns></returns>
        public static long GetSiteId()
        {
            return SITE_ID_CONSTANT;
        }

        // -- 検索条件指定
        /// <summary>
        /// 検索キー条件
        /// </summary>
        public static class FilterKeys
        {






        }

        // -- ソートオーダーの指定


        // -- ソートオーダーの指定
        public static class ColumnSorterKeys
        {

            // AttachmentsHash は未対応








        }
    }
}

