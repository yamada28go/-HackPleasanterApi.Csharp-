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
    /// �L�^�e�[�u���A�N�Z�X�T�[�r�X
    /// </summary>
    class RecordingTableService : ItmeServiceBase<RecordingTableModel, RecordingTableModel.RecordingTableModelExtensionElements>
    {
        /// <summary>
        /// �T�C�gID
        /// </summary>
        private static readonly long SITE_ID_CONSTANT = 2;


        public RecordingTableService(ServiceConfig config) : base(config, SITE_ID_CONSTANT)
        {
        }


        /// <summary>
        /// �T�C�gId���擾����
        /// </summary>
        /// <returns></returns>
        public static long GetSiteId()
        {
            return SITE_ID_CONSTANT;
        }

        // -- ���������w��
        /// <summary>
        /// �����L�[����
        /// </summary>
        public static class FilterKeys
        {


            public static CheckFilterKey<RecordingTableModel> CheckA
            {
                get
                {
                    return new CheckFilterKey<RecordingTableModel>("CheckA");
                }
            }



            public static ChoicesTextFilterKey<RecordingTableModel> TypeA
            {
                get
                {
                    return new ChoicesTextFilterKey<RecordingTableModel>("ClassA");
                }
            }




            // ���ڂ̌����I����
            public class TypeA_Choices
            {

                public static ChoicesTextElement ClassA { get { return new ChoicesTextElement("ClassA"); } }

                public static ChoicesTextElement ClassB { get { return new ChoicesTextElement("ClassB"); } }

                public static ChoicesTextElement ClassC { get { return new ChoicesTextElement("ClassC"); } }


            }

            public static ClassFilterKey<RecordingTableModel> TypeB
            {
                get
                {
                    return new ClassFilterKey<RecordingTableModel>("ClassB");
                }
            }



            public static DateFilterKey<RecordingTableModel> DateA
            {
                get
                {
                    return new DateFilterKey<RecordingTableModel>("DateA");
                }
            }



            public static DescriptionFilterKey<RecordingTableModel> StringA
            {
                get
                {
                    return new DescriptionFilterKey<RecordingTableModel>("DescriptionA");
                }
            }



            public static NumFilterKey<RecordingTableModel> NumA
            {
                get
                {
                    return new NumFilterKey<RecordingTableModel>("NumA");
                }
            }


        }

        // -- �\�[�g�I�[�_�[�̎w��


        // -- �\�[�g�I�[�_�[�̎w��
        public static class ColumnSorterKeys
        {

            // AttachmentsHash �͖��Ή�



            // CheckA�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> CheckA
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("CheckA");
                }
            }



            // TypeA�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> TypeA
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("ClassA");
                }
            }


            // TypeB�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> TypeB
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("ClassB");
                }
            }



            // DateA�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> DateA
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("DateA");
                }
            }



            // StringA�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> StringA
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("DescriptionA");
                }
            }



            // NumA�p�̃\�[�g����
            public static ColumnSorterKey<RecordingTableModel> NumA
            {
                get
                {
                    return new ColumnSorterKey<RecordingTableModel>("NumA");
                }
            }



        }
    }
}

