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
    /// 記録テーブルアクセスサービス
    /// </summary>
    public class 記録テーブルService : ItmeServiceBase<記録テーブルModel,記録テーブルModel.記録テーブルModelExtensionElements>
    {
        /// <summary>
        /// サイトID
        /// </summary>
        private static readonly long SITE_ID_CONSTANT = 2;


        public 記録テーブルService (ServiceConfig config) : base(config, SITE_ID_CONSTANT )
        {
        }


        /// <summary>
        /// サイトIdを取得する
        /// </summary>
        /// <returns></returns>
        public static long GetSiteId()
        {
            return SITE_ID_CONSTANT ;
        }

            // -- 検索条件指定
            /// <summary>
        /// 検索キー条件
        /// </summary>
        public static class FilterKeys
        {


            public static CheckFilterKey<記録テーブルModel> CheckA
            {
                get
                {
                    return new CheckFilterKey<記録テーブルModel>("CheckA");
                }
            }

        

            public static ChoicesTextFilterKey<記録テーブルModel> TypeA
            {
                get
                {
                    return new ChoicesTextFilterKey<記録テーブルModel>("ClassA");
                }
            }

        


            // 項目の検索選択肢
            public class TypeA_Choices
            {
            
                    public static ChoicesTextElement ClassA { get { return new ChoicesTextElement("ClassA"); } }
                
                    public static ChoicesTextElement ClassB { get { return new ChoicesTextElement("ClassB"); } }
                
                    public static ChoicesTextElement ClassC { get { return new ChoicesTextElement("ClassC"); } }
                

            }
        

            public static DateFilterKey<記録テーブルModel> DataA
            {
                get
                {
                    return new DateFilterKey<記録テーブルModel>("DateA");
                }
            }

        

            public static DescriptionFilterKey<記録テーブルModel> StringA
            {
                get
                {
                    return new DescriptionFilterKey<記録テーブルModel>("DescriptionA");
                }
            }

        

            public static NumFilterKey<記録テーブルModel> NumA
            {
                get
                {
                    return new NumFilterKey<記録テーブルModel>("NumA");
                }
            }

        
        }

    // -- ソートオーダーの指定


        // -- ソートオーダーの指定
        public static class ColumnSorterKeys
        {

    // AttachmentsHash は未対応



            // CheckA用のソート条件
            public static ColumnSorterKey<記録テーブルModel> CheckA
            {
                get
                {
                    return new ColumnSorterKey<記録テーブルModel>("CheckA");
                }
            }

        

            // TypeA用のソート条件
            public static ColumnSorterKey<記録テーブルModel> TypeA
            {
                get
                {
                    return new ColumnSorterKey<記録テーブルModel>("ClassA");
                }
            }

        

            // DataA用のソート条件
            public static ColumnSorterKey<記録テーブルModel> DataA
            {
                get
                {
                    return new ColumnSorterKey<記録テーブルModel>("DateA");
                }
            }

        

            // StringA用のソート条件
            public static ColumnSorterKey<記録テーブルModel> StringA
            {
                get
                {
                    return new ColumnSorterKey<記録テーブルModel>("DescriptionA");
                }
            }

        

            // NumA用のソート条件
            public static ColumnSorterKey<記録テーブルModel> NumA
            {
                get
                {
                    return new ColumnSorterKey<記録テーブルModel>("NumA");
                }
            }

        

        }
    }
}

