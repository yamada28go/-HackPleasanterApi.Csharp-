/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 * */

using System;
using System.Collections.Generic;
using System.Text;

namespace HackPleasanterApi.Client.Api.Request
{

    /// <summary>
    /// 全データ削除リクエスト
    /// </summary>
    public class DeleteAllItemsRequestBase<TableType> : RequestBase
    {
        /// <summary>
        /// 物理消去する
        /// </summary>
        public bool PhysicalDelete = false;

        /// <summary>
        /// 削除対象のitemを指定
        /// </summary>
        public List<long> Selected;

        /// <summary>
        /// 全アイテム削除
        /// </summary>
        public bool All;

    }


    /// <summary>
    /// 全データ削除リクエスト
    /// </summary>
    public class DeleteAllItemsRequest<TableType> : DeleteAllItemsRequestBase<TableType>
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public View.View<TableType> View;
    }

    /// <summary>
    /// 全データ削除リクエスト
    /// </summary>
    public class DeleteAllItemsRequestSend<TableType> : DeleteAllItemsRequestBase<TableType>
    {

        /// <summary>
        /// 検索条件
        /// </summary>
        public Request.View.ViewSend View { get; set; }

    }

    public static class DeleteAllItemsRequestHelper
    {

        public static DeleteAllItemsRequestSend<TableType> ToDeleteAllItemsRequestSend<TableType>
            (this DeleteAllItemsRequest<TableType> src)
            where TableType : new()
        {

            var r = new DeleteAllItemsRequestSend<TableType>();

            r.ApiKey = src.ApiKey;
            r.ApiVersion = src.ApiVersion;

            r.Selected = src.Selected;
            r.All = src.All;
            r.PhysicalDelete = src.PhysicalDelete;

            return r;

        }


    }

}
