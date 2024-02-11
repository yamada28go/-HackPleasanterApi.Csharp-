using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HackPleasanterApi.Client.Api.Helper.Expansions;

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


namespace HackPleasanterApi.Client.Api.Request.View.FilterKey
{

    /// <summary>
    /// Check列に対する 検索キー条件
    /// </summary>
    public class CheckFilterKey<DataType> : ColumnFilterHashGenerateInterface<DataType>
    {
        // 識別文字列
        private string DescriptionName;

        /// <summary>
        /// Check列に対する検索条件
        /// </summary>
        public bool? Check;


        public CheckFilterKey(string DescriptionName)
        {
            this.DescriptionName = DescriptionName;
        }

        /// <summary>
        /// 検索条件をリセットする
        /// </summary>
        public void Reset()
        {
            this.Check = null;
        }


        /// <summary>
        /// 単項での検索条件指定
        /// </summary>
        /// <param name="data"></param>
        public void AddKey(bool data)
        {
            this.Check = data;
        }


        /// <summary>
        /// 検索条件を文字列変換して該当データを置換する
        /// </summary>
        /// <param name="hash"></param>
        public void Merge(Dictionary<string, string> hash)
        {
            var val = this.Check?.ToString();
            if (val is not null)
            {
                if (true == this.Check.HasValue)
                {
                    hash[DescriptionName] = val;
                }
            }
        }
    }

}
