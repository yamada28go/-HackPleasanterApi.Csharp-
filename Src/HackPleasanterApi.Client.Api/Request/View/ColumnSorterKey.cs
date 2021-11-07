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

namespace HackPleasanterApi.Client.Api.Request.View
{
    // --- 取得要素ソート関係
    // 列のそーと種別
    public enum ColumnSorterType
    {
        /// <summary>
        /// 昇順
        /// </summary>
        Asc,
        /// <summary>
        /// 降順
        /// </summary>
        Desc
    }

    public static class ColumnSorterTypeHelper
    {

        public static string ToStringEx(this ColumnSorterType data)
        {

            switch (data)
            {

                case ColumnSorterType.Asc:
                    return "asc";
                case ColumnSorterType.Desc:
                    return "desc";
                default:
                    throw new ArgumentException();
            }
        }
    }

    // カラム列のソート用キー種別
    public class ColumnSorterKeyImp
    {
        // 識別文字列
        public string DescriptionName;

        // 対象ソート種別
        public ColumnSorterType ColumnSorterType;

        public ColumnSorterKeyImp(
            // 識別文字列
            String DescriptionName,
            // 対象ソート種別
            ColumnSorterType ColumnSorterType = ColumnSorterType.Asc
        )
        {
            this.DescriptionName = DescriptionName;
            this.ColumnSorterType = ColumnSorterType;
        }

        // 検索対象配列とマージする
        public void Merge(Dictionary<string, string> hash)
        {
            hash[DescriptionName] = ColumnSorterType.ToStringEx();
        }

    }

    // カラム列のソート用キー種別
    public class ColumnSorterKey<TypeTableModel> : ColumnSorterKeyImp
    {
        public ColumnSorterKey(
            String DescriptionName, ColumnSorterType ColumnSorterType = ColumnSorterType.Asc)
            : base(DescriptionName, ColumnSorterType)
        {
        }
    }
}

