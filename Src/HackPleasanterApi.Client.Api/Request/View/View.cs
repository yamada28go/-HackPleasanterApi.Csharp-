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
using HackPleasanterApi.Client.Api.Request.View.FilterKey;

namespace HackPleasanterApi.Client.Api.Request.View
{
    public class ViewBase
    {
        // 未完了
        public bool? Incomplete;

        // 自分
        public bool? Owm;

        // 期限が近い
        public bool? NearCompletionTime;

        // 遅延
        public bool? Delay;

        // 超過期限
        public bool? Overdue;

        // 検索
        public string Search;
    }

    /// <summary>
    /// ユーザーが指定に使用するデータ型
    /// </summary>
    /// <typeparam name="TableType"></typeparam>
    public class View<TableType> : ViewBase
    {
        // [Memo]
        // テーブル型のチェックを矯正するために、
        // 直接的に公開しない

        /// <summary>
        /// 指定検索条件文字列
        /// </summary>
        internal List<ColumnFilterHashGenerateInterfaceImp> ColumnFilter;


        /// <summary>
        /// ソート条件
        /// </summary>
        internal List<ColumnSorterKeyImp> ColumnSorter;

    }

    /// <summary>
    /// 補助関数
    /// </summary>
    public static class ViewHelper
    {

        public static void Add<TableType>(this View<TableType> target, ColumnFilterHashGenerateInterface<TableType> key)
        {

            if (null == target.ColumnFilter)
            {
                target.ColumnFilter = new List<ColumnFilterHashGenerateInterfaceImp>();
            }

            target.ColumnFilter.Add(key);
        }

        public static void Add<TableType>(this View<TableType> target, ColumnSorterKey<TableType> key)
        {

            if (null == target.ColumnSorter)
            {
                target.ColumnSorter = new List<ColumnSorterKeyImp>();
            }

            target.ColumnSorter.Add(key);
        }


    }

    /// <summary>
    /// 実際に送信されるデータ型
    /// </summary>
    public class ViewSend : ViewBase
    {

        /// <summary>
        /// 検索条件
        /// </summary>
        public Dictionary<string, string> ColumnFilterHash { get; set; }


        /// <summary>
        /// ソート順序
        /// </summary>
        public Dictionary<string, string> ColumnSorterHash { get; set; }

    }
}
