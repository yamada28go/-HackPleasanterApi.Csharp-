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
    /// Num列に対する 検索キー条件
    /// </summary>
    public class DateFilterKey<DataType> : ColumnFilterHashGenerateInterface<DataType>
    {

        public class Range
        {

            /// <summary>
            /// 値域の開始
            /// </summary>
            public DateTime? Start;

            /// <summary>
            /// 値域の終了
            /// </summary>
            public DateTime? End;

            /// <summary>
            /// 単独の値
            /// </summary>
            public DateTime? Value;

        }

        // 識別文字列
        private string DescriptionName;

        /// <summary>
        /// Num列に対する検索条件
        /// </summary>
        public List<Range>? SearchConditions = null;


        public DateFilterKey(string DescriptionName)
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

        // 時刻なので、検索範囲の指定は「範囲」で行う。
        // 時刻だけピンポイントの指定は出来ない
#if false

        /// <summary>
        /// 単項での検索条件指定
        /// </summary>
        /// <param name="data"></param>
        public void AddKey(DateTime data)
        {
            if (this.SearchConditions == null)
            {
                this.SearchConditions = new List<Range>();
            }

            var d = new Range { Value = data };
            this.SearchConditions.Add(d);
        }
#endif


        /// <summary>
        /// 指定さけた範囲で値を検索
        /// </summary>
        /// <param name="start">値域の開始(この値も検索結果に含む)</param>
        /// <param name="end">値域の終了(この値も検索結果に含む)</param>
        public void AddKeyRange(DateTime start, DateTime end)
        {

            if (this.SearchConditions == null)
            {
                this.SearchConditions = new List<Range>();
            }

            var d = new Range { Start = start, End = end };
            this.SearchConditions.Add(d);
        }

        /// <summary>
        /// 指定値 以上で検索
        /// </summary>
        /// <param name="value">上限値(この値も結果に含む)</param>
        public void AddKeyOver(DateTime value)
        {
            if (this.SearchConditions == null)
            {
                this.SearchConditions = new List<Range>();
            }

            var d = new Range { Start = value };
            this.SearchConditions.Add(d);
        }

        /// <summary>
        /// 指定値 以下で検索
        /// </summary>
        /// <param name="data">下限値(この値も結果に含む)</param>
        public void AddKeyUnder(DateTime data)
        {
            if (this.SearchConditions == null)
            {
                this.SearchConditions = new List<Range>();
            }

            var d = new Range { End = data };
            this.SearchConditions.Add(d);
        }



        /// <summary>
        /// 検索条件を文字列変換して該当データを置換する
        /// </summary>
        /// <param name="hash"></param>
        public void Merge(Dictionary<string, string> hash)
        {
            // [Memo]
            //公式ドキュメントの指定は以下となっている
            //
            // 日付Aが2021 / 1 / 31(終日)
            //
            //JSON
            //"DateA":"[\"2021/01/31 00:00:00,2021/01/31 23:59:59\"]"
            //日付Aが2021 / 1 / 1以降
            //
            //    JSON
            //"DateA":"[\"2021/01/01 00:00:00,\"]"
            //
            // しかし、実際にはフォーマット形式が異なっており、
            // 以下のような指定する
            // 
            // "DateA":"[\"2020-01-09T06:30:00\"]"

            if (0 != SearchConditions?.Count)
            {
                // データの内容に応じて変換をかけてくい
                var sb = new StringBuilder();
                sb.Append("[");

                foreach (var ele in SearchConditions ?? new List<Range>())
                {

                    if (true == ele.Value.HasValue)
                    {
                        // 値だけ指定されてた場合
                        sb.AppendDoubleQuote();
                        sb.Append(ele.Value.Value.ToStringForApiRequest());
                        sb.AppendDoubleQuote();

                        sb.Append(",");
                        continue;
                    }
                    else if (true == ele.Start.HasValue &&
                       false == ele.End.HasValue)
                    {
                        // ある値より大きい場合
                        sb.AppendDoubleQuote();
                        sb.Append(ele.Start.Value.ToStringForApiRequest());
                        sb.Append(",");
                        sb.AppendDoubleQuote();
                        sb.Append(",");

                        continue;
                    }
                    else if (false == ele.Start.HasValue &&
                      true == ele.End.HasValue)
                    {
                        // ある値より小さい場合
                        sb.AppendDoubleQuote();
                        sb.Append(",");
                        sb.Append(ele.End.Value.ToStringForApiRequest());
                        sb.AppendDoubleQuote();
                        sb.Append(",");

                        continue;
                    }
                    if (true == ele.Start.HasValue &&
                      true == ele.End.HasValue)
                    {
                        sb.AppendDoubleQuote();
                        sb.Append(ele.Start.Value.ToStringForApiRequest());
                        sb.Append(",");
                        sb.Append(ele.End.Value.ToStringForApiRequest());
                        sb.AppendDoubleQuote();
                        sb.Append(",");

                        continue;
                    }
                    else
                    {
                        //想定外の条件
                        throw new ApplicationException("Num 検索条件の指定方法が間違っています。");
                    }
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

}
