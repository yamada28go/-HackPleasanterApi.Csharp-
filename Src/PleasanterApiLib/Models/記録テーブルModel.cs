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
    /// 記録テーブル DTOクラス
    /// </summary>
    public class 記録テーブルModel : DTOBase<記録テーブルModel.記録テーブルModelExtensionElements>
    {

        public 記録テーブルModel() : base(new ItemRawData())
        {
            this.ExtensionElements = new 記録テーブルModelExtensionElements(this.rawData);
            this.BasicItemData = new BasicItemData(this.rawData);
        }


        public 記録テーブルModel(ItemRawData rawData) : base(rawData)
        {
            this.ExtensionElements = new 記録テーブルModelExtensionElements(this.rawData);
            this.BasicItemData = new BasicItemData(this.rawData);
        }

        /// <summary>
        /// 個別の拡張要素
        /// </summary>
        public class 記録テーブルModelExtensionElements : ExtensionElementsBase
        {
            public 記録テーブルModelExtensionElements(ItemRawData _rawData) : base(_rawData)
            {
            }


            #region 自動生成

            #region Class区分



            /// <summary>
            /// 
            /// </summary>
            public string? TypeA
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.ClassHash?.ClassA;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {

                        if (obj.ClassHash is null)
                        {
                            obj.ClassHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.ClassHash();
                        }

                        obj.ClassHash.ClassA = value;

                        return;

                    }

                    throw new ApplicationException("参照エラー");

                }
            }


            /// <summary>
            /// テストデータ_分類B
            /// </summary>
            public string? テストデータ_分類B
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.ClassHash?.ClassB;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {

                        if (obj.ClassHash is null)
                        {
                            obj.ClassHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.ClassHash();
                        }

                        obj.ClassHash.ClassB = value;

                        return;

                    }

                    throw new ApplicationException("参照エラー");

                }
            }

            #endregion

            #region Num区分




            /// <summary>
            /// 
            /// </summary>
            public decimal? NumA
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.NumHash is null)
                        {
                            obj.NumHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.NumHash();
                        }

                        obj.NumHash.NumA = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.NumHash?.NumA;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }



            /// <summary>
            /// テストデータ_数値B
            /// </summary>
            public decimal? テストデータ_数値B
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.NumHash is null)
                        {
                            obj.NumHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.NumHash();
                        }

                        obj.NumHash.NumB = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.NumHash?.NumB;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }

            #endregion

            #region Date区分



            /// <summary>
            /// 
            /// </summary>
            public DateTime? DataA
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.DateHash is null)
                        {
                            obj.DateHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DateHash();
                        }

                        obj.DateHash.DateA = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.DateHash?.DateA;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }


            /// <summary>
            /// テストデータ_日付B
            /// </summary>
            public DateTime? テストデータ_日付B
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.DateHash is null)
                        {
                            obj.DateHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DateHash();
                        }

                        obj.DateHash.DateB = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.DateHash?.DateB;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }

            #endregion

            #region Description区分



            /// <summary>
            /// 
            /// </summary>
            public string? StringA
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.DescriptionHash?.DescriptionA;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.DescriptionHash is null)
                        {
                            obj.DescriptionHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DescriptionHash();
                        }

                        obj.DescriptionHash.DescriptionA = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }
            }


            /// <summary>
            /// テストデータ_説明B
            /// </summary>
            public string? テストデータ_説明B
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.DescriptionHash?.DescriptionB;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.DescriptionHash is null)
                        {
                            obj.DescriptionHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DescriptionHash();
                        }

                        obj.DescriptionHash.DescriptionB = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }
            }

            #endregion

            #region Check区分



            /// <summary>
            /// 
            /// </summary>
            public bool? CheckA
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {

                        if (obj.CheckHash is null)
                        {
                            obj.CheckHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.CheckHash();
                        }

                        obj.CheckHash.CheckA = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.CheckHash?.CheckA;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }


            /// <summary>
            /// テストデータ_チェックB
            /// </summary>
            public bool? テストデータ_チェックB
            {
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {

                        if (obj.CheckHash is null)
                        {
                            obj.CheckHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.CheckHash();
                        }

                        obj.CheckHash.CheckB = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }

                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.CheckHash?.CheckB;
                    }
                    throw new ApplicationException("参照エラー");

                }

            }

            #endregion


            #region Attachments区分



            /// <summary>
            /// テストデータ_添付ファイルA
            /// </summary>
            public List<Attachments>? テストデータ_添付ファイルA
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.AttachmentsHash?.AttachmentsA;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.AttachmentsHash is null)
                        {
                            obj.AttachmentsHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.AttachmentsHash();
                        }

                        obj.AttachmentsHash.AttachmentsA = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }
            }


            /// <summary>
            /// テストデータ_添付ファイルB
            /// </summary>
            public List<Attachments>? テストデータ_添付ファイルB
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.AttachmentsHash?.AttachmentsB;
                    }
                    throw new ApplicationException("参照エラー");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.AttachmentsHash is null)
                        {
                            obj.AttachmentsHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.AttachmentsHash();
                        }

                        obj.AttachmentsHash.AttachmentsB = value;

                        return;
                    }

                    throw new ApplicationException("参照エラー");

                }
            }

            #endregion


            #endregion
        }

    }
}

