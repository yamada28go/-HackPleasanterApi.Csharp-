using System;
using System.Collections.Generic;
using System.Text;

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
    /// Description列に対する 検索キー条件
    /// </summary>
    public class DescriptionFilterKey<DataType> : ColumnFilterHashGenerateInterface<DataType>
    {

        // 識別文字列
        private string DescriptionName;

        /// <summary>
        /// 検索対象文字列
        /// 指定された文字列に対してlike検索となる
        /// </summary>
        public string SearchCondition;

        public DescriptionFilterKey(string DescriptionName)
        {
            this.DescriptionName = DescriptionName;
        }

        /// <summary>
        /// 検索条件をリセットする
        /// </summary>
        public void Reset()
        {
            this.SearchCondition = null;
        }

        /// <summary>
        /// 検索条件を文字列変換して該当データを置換する
        /// </summary>
        /// <param name="hash"></param>
        public void Merge(Dictionary<string, string> hash)
        {
            // 分類Aが "みかん" or "ブドウ"
            // "ClassA":"[\"みかん\",\"ブドウ\"]"
            if (false == String.IsNullOrWhiteSpace(SearchCondition))
            {

                hash[DescriptionName] = SearchCondition;

            }
        }
    }

}
