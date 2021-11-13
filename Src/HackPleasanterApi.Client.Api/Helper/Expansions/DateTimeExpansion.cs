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
using System.Text;

namespace HackPleasanterApi.Client.Api.Helper.Expansions
{
    /// <summary>
    /// DateTime用する拡張
    /// </summary>
    public static class DateTimeExpansion
    {
        /// <summary>
        /// API問い合わせ時に使用する文字列形式に変換する
        /// </summary>
        /// <param name="sb"></param>
        public static string ToStringForApiRequest(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public static DateTime ToJst(this DateTime utc)
        {
            // Memo
            // https://tech.tanaka733.net/entry/2020/02/timezone-id

            /*
            var jstZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
            return TimeZoneInfo.ConvertTimeFromUtc(utc, jstZoneInfo);
            */

            //タイムゾーン変換する
            return utc.AddHours(-9);
        }

    }

}
