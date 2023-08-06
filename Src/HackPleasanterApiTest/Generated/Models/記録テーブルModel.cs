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

        public 記録テーブルModel ()
        {
            this.rawData = new ItemRawData();
            InternalData();
        }


        public 記録テーブルModel (ItemRawData rawData)
        {
            this.rawData = rawData;
            InternalData();
        }

        /// <summary>
        /// 内部データを初期化する
        /// </summary>
        private void InternalData()
        {
            // ユーザー拡張データ構造の定義
            this.ExtensionElements = new 記録テーブルModel.記録テーブルModelExtensionElements ();
            this.ExtensionElements.rawData = new WeakReference<ItemRawData>(this.rawData);

            this.BasicItemData = new BasicItemData();
            this.BasicItemData.rawData = new WeakReference<ItemRawData>(this.rawData);
        }

        /// <summary>
        /// 個別の拡張要素
        /// </summary>
        public class 記録テーブルModelExtensionElements : ExtensionElementsBase
        {
            #region 自動生成

            #region Class区分



               /// <summary>
               /// 
                /// </summary>
                public string TypeA
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
                            if (obj.ClassHash == null)
                            {
                                obj.ClassHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.ClassHash();
                            }

                            obj.ClassHash.ClassA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion

            #region Num区分



               /// <summary>
               /// 
               /// サーバー戻り値では値を持っていない可能性があるので、
               /// get系はnullable型の別名にする。
               /// </summary>
                public decimal? NumA_value
                {
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
               /// 
               /// </summary>
                public decimal NumA
                {
                    set
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {
                            if (obj.NumHash == null)
                            {
                                obj.NumHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.NumHash();
                            }

                            obj.NumHash.NumA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion

            #region Date区分



               /// <summary>
               /// 
               ///
               /// サーバー戻り値では値を持っていない可能性があるので、
               /// get系はnullable型の別名にする。
               /// </summary>
                public DateTime? DataA_value
                {
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
               /// 
               /// </summary>
                public DateTime DataA
                {
                    set
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {
                            if (obj.DateHash == null)
                            {
                                obj.DateHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DateHash();
                            }

                            obj.DateHash.DateA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion

            #region Description区分



               /// <summary>
               /// 
               /// </summary>
                public string StringA
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
                            if (obj.DescriptionHash == null)
                            {
                                obj.DescriptionHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.DescriptionHash();
                            }

                            obj.DescriptionHash.DescriptionA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion

            #region Check区分



               /// <summary>
               /// 
               ///
               /// サーバー戻り値では値を持っていない可能性があるので、
               /// get系はnullable型の別名にする。
               /// </summary>
                public bool? CheckA_value
                {
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
               /// 
               /// </summary>
                public bool CheckA
                {
                    set
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {

                            if (obj.CheckHash == null)
                            {
                                obj.CheckHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.CheckHash();
                            }

                            obj.CheckHash.CheckA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion


            #region Attachments区分



               /// <summary>
               /// 
               /// </summary>
                public List<Attachments> AttachmentA
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
                            if (obj.AttachmentsHash == null)
                            {
                                obj.AttachmentsHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.AttachmentsHash();
                            }

                            obj.AttachmentsHash.AttachmentsA = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                

               /// <summary>
               /// 
               /// </summary>
                public List<Attachments> AttachmentB
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
                            if (obj.AttachmentsHash == null)
                            {
                                obj.AttachmentsHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.AttachmentsHash();
                            }

                            obj.AttachmentsHash.AttachmentsB = value;

                            return ;
                        }

                        throw new ApplicationException("参照エラー");

                    }
                }
                
            #endregion


#endregion
        }

    }
}

