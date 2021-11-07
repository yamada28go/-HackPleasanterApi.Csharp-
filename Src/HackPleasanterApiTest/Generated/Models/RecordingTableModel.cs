using HackPleasanterApi.Client.Api.Interface;
using HackPleasanterApi.Client.Api.Models.ItemModel;
using HackPleasanterApi.Client.Api.Models.ItemModel.Hash;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSamples.Generated.Models
{


    /// <summary>
    /// �L�^�e�[�u�� DTO�N���X
    /// </summary>
    public class RecordingTableModel : DTOBase<RecordingTableModel.RecordingTableModelExtensionElements>
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
        /// �����f�[�^������������
        /// </summary>
        private void InternalData()
        {
            // ���[�U�[�g���f�[�^�\���̒�`
            this.ExtensionElements = new RecordingTableModel.RecordingTableModelExtensionElements();
            this.ExtensionElements.rawData = new WeakReference<ItemRawData>(this.rawData);

            this.BasicItemData = new BasicItemData();
            this.BasicItemData.rawData = new WeakReference<ItemRawData>(this.rawData);
        }

        /// <summary>
        /// �ʂ̊g���v�f
        /// </summary>
        public class RecordingTableModelExtensionElements : ExtensionElementsBase
        {
            #region ��������

            #region Class�敪



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
                    throw new ApplicationException("�Q�ƃG���[");

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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }


            /// <summary>
            /// 
            /// </summary>
            public string TypeB
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.ClassHash?.ClassB;
                    }
                    throw new ApplicationException("�Q�ƃG���[");

                }
                set
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        if (obj.ClassHash == null)
                        {
                            obj.ClassHash = new HackPleasanterApi.Client.Api.Models.ItemModel.Hash.ClassHash();
                        }

                        obj.ClassHash.ClassB = value;

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion

            #region Num�敪



            /// <summary>
            /// 
            /// �T�[�o�[�߂�l�ł͒l�������Ă��Ȃ��\��������̂ŁA
            /// get�n��nullable�^�̕ʖ��ɂ���B
            /// </summary>
            public decimal? NumA_value
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.NumHash?.NumA;
                    }
                    throw new ApplicationException("�Q�ƃG���[");

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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion

            #region Date�敪



            /// <summary>
            /// 
            ///
            /// �T�[�o�[�߂�l�ł͒l�������Ă��Ȃ��\��������̂ŁA
            /// get�n��nullable�^�̕ʖ��ɂ���B
            /// </summary>
            public DateTime? DateA_value
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.DateHash?.DateA;
                    }
                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DateTime DateA
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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion

            #region Description�敪



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
                    throw new ApplicationException("�Q�ƃG���[");

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

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion

            #region Check�敪



            /// <summary>
            /// 
            ///
            /// �T�[�o�[�߂�l�ł͒l�������Ă��Ȃ��\��������̂ŁA
            /// get�n��nullable�^�̕ʖ��ɂ���B
            /// </summary>
            public bool? CheckA_value
            {
                get
                {
                    if (rawData.TryGetTarget(out var obj))
                    {
                        return obj?.CheckHash?.CheckA;
                    }
                    throw new ApplicationException("�Q�ƃG���[");

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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion


            #region Attachments�敪



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
                    throw new ApplicationException("�Q�ƃG���[");

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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

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
                    throw new ApplicationException("�Q�ƃG���[");

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

                        return;
                    }

                    throw new ApplicationException("�Q�ƃG���[");

                }
            }

            #endregion


            #endregion
        }

    }
}

