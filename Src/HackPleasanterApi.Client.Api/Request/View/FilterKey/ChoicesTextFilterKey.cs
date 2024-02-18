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
    /// 選択肢文字列を取得
    /// </summary>
    public class ChoicesTextElement
    {

        public readonly string ChoicesText;

        public ChoicesTextElement(string ChoicesText)
        {

            this.ChoicesText = ChoicesText;

        }
    }


    /// <summary>
    /// 列に対する 検索キー条件
    /// </summary>
    public class ChoicesTextFilterKey<DataType> : ColumnFilterHashGenerateInterface<DataType>
    {

        // 識別文字列
        private string DescriptionName;

        /// <summary>
        /// 検索対象文字列
        /// 指定された文字列に対してlike検索となる
        /// </summary>
        public List<ChoicesTextElement>? SearchConditions = null;

        public ChoicesTextFilterKey(string DescriptionName)
        {
            this.DescriptionName = DescriptionName;
        }

        /// <summary>
        /// 検索条件をリセットする
        /// </summary>
        public void Reset()
        {
            this.SearchConditions = null;
        }

        /// <summary>
        /// 検索条件を文字列変換して該当データを置換する
        /// </summary>
        /// <param name="hash"></param>
        public void Merge(Dictionary<string, string> hash)
        {
            // 分類Aが "みかん" or "ブドウ"
            // "ClassA":"[\"みかん\",\"ブドウ\"]"


            // データの内容に応じて変換をかけてくい
            var sb = new StringBuilder();
            sb.Append("[");

            foreach (var ele in SearchConditions ?? new List<ChoicesTextElement>())
            {
                // 値だけ指定されてた場合
                sb.AppendDoubleQuote();
                sb.Append(ele.ChoicesText);
                sb.AppendDoubleQuote();

                sb.Append(",");
            }
            // 行末に,が残っていたら消す
            var ts = sb.ToString();
            Regex reg2 = new Regex(",$");
            ts = reg2.Replace(ts, "");

            // カッコを閉じる
            ts = ts + "]";

            hash[DescriptionName] = ts;
        }
    }

}
