using CsharpSamples.Generated.Models;
using HackPleasanterApi.Client.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;


namespace CsharpSamples.Generated.Service
{
    /// <summary>
    /// ?L?^?e?[?u???A?N?Z?X?T?[?r?X
    /// </summary>
    class RecordingTableService : ItmeServiceBase<RecordingTableModel, Models.RecordingTableModel.RecordingTableModelExtensionElements>
    {
        /// <summary>
        /// ?T?C?gID
        /// </summary>
        private static readonly long SITE_ID_CONSTANT = 3;


        public RecordingTableService(ServiceConfig config) : base(config, SITE_ID_CONSTANT )
        {
        }


        /// <summary>
        /// ?T?C?gId??????????
        /// </summary>
        /// <returns></returns>
        public static long GetSiteId()
        {
            return SITE_ID_CONSTANT ;
        }

    }
}

