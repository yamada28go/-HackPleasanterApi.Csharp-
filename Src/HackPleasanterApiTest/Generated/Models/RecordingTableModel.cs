using HackPleasanterApi.Client.Api.Interface;
using HackPleasanterApi.Client.Api.Models.ItemModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSamples.Generated.Models
{


    /// <summary>
    /// ?L?^?e?[?u?? DTO?N???X
    /// </summary>
    class RecordingTableModel : DTOBase<RecordingTableModel.RecordingTableModelExtensionElements>
    {

        public RecordingTableModel()
        {
            this.rawData = new ItemRawData();
            InternalData();
        }


        public RecordingTableModel(ItemRawData rawData)
        {
            this.rawData = rawData;
            InternalData();
        }

        /// <summary>
        /// ?????f?[?^????????????
        /// </summary>
        private void InternalData()
        {
            // ???[?U?[?g???f?[?^?\???????`
            this.ExtensionElements = new RecordingTableModel.RecordingTableModelExtensionElements();
            this.ExtensionElements.rawData = new WeakReference<ItemRawData>(this.rawData);

            this.BasicItemData = new BasicItemData();
            this.BasicItemData.rawData = new WeakReference<ItemRawData>(this.rawData);
        }

        /// <summary>
        /// ???????g???v?f
        /// </summary>
        public class RecordingTableModelExtensionElements : ExtensionElementsBase
        {
            #region ????????

            #region Class????



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
                        throw new ApplicationException("?Q???G???[");

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

                        throw new ApplicationException("?Q???G???[");

                    }
                }
                
            #endregion

            #region Num????



               /// <summary>
               /// 
               /// ?T?[?o?[?????l?????l?????????????????\?????????????A
               /// get?n??nullable?^?????????????B
               /// </summary>
                public decimal? NumA_value
                {
                    get
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {
                            return obj?.NumHash?.NumA;
                        }
                        throw new ApplicationException("?Q???G???[");

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

                        throw new ApplicationException("?Q???G???[");

                    }
                }
                
            #endregion

            #region Date????



               /// <summary>
               /// 
               ///
               /// ?T?[?o?[?????l?????l?????????????????\?????????????A
               /// get?n??nullable?^?????????????B
               /// </summary>
                public DateTime? DataA_value
                {
                    get
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {
                            return obj?.DateHash?.DateA;
                        }
                        throw new ApplicationException("?Q???G???[");

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

                        throw new ApplicationException("?Q???G???[");

                    }
                }
                
            #endregion

            #region Description????



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
                        throw new ApplicationException("?Q???G???[");

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

                        return;
                        }

                        throw new ApplicationException("?Q???G???[");

                    }
                }
                
            #endregion

            #region Check????



               /// <summary>
               /// 
               ///
               /// ?T?[?o?[?????l?????l?????????????????\?????????????A
               /// get?n??nullable?^?????????????B
               /// </summary>
                public bool? CheckA_value
                {
                    get
                    {
                        if (rawData.TryGetTarget(out var obj))
                        {
                            return obj?.CheckHash?.CheckA;
                        }
                        throw new ApplicationException("?Q???G???[");

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

                        throw new ApplicationException("?Q???G???[");

                    }
                }
                
            #endregion


            #region Attachments????


            #endregion


#endregion
        }

    }
}

