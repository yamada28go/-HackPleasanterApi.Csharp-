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


using HackPleasanterApi.Client.Api.Interface;
using HackPleasanterApi.Client.Api.Models.ItemModel;
using HackPleasanterApi.Client.Api.Models.ItemModel.Hash;
using System;
using System.Collections.Generic;
using System.Text;


namespace CsharpSamples.Generated.Models
{
    /// <summary>
    /// API試験用 DTOクラス
    /// </summary>
    public class API試験用Model : DTOBase<API試験用Model.API試験用ModelExtensionElements>
    {

        public API試験用Model() : base(new ItemRawData())
        {
            this.ExtensionElements = new API試験用Model.API試験用ModelExtensionElements(this.rawData);
            this.BasicItemData = new BasicItemData(this.rawData);
        }


        public API試験用Model(ItemRawData rawData) : base(rawData)
        {
            this.ExtensionElements = new API試験用Model.API試験用ModelExtensionElements(this.rawData);
            this.BasicItemData = new BasicItemData(this.rawData);
        }

        /// <summary>
        /// 個別の拡張要素
        /// </summary>
        public class API試験用ModelExtensionElements : ExtensionElementsBase
        {
            public API試験用ModelExtensionElements(ItemRawData _rawData) : base(_rawData)
            {
            }


            #region 自動生成

            #region Class区分


            #endregion

            #region Num区分


            #endregion

            #region Date区分


            #endregion

            #region Description区分


            #endregion

            #region Check区分


            #endregion


            #region Attachments区分


            #endregion


            #endregion
        }


    }
}

