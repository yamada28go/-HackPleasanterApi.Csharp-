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
    public interface IRequestBase
    {
        /// <summary>
        /// 対象とするAPIバージョン
        /// </summary>
        string ApiVersion { get; set; }
        /// <summary>
        /// アクセス用のAPIキー
        /// </summary>
        string ApiKey { get; set; }

    }


    public class RequestBase : IRequestBase
    {
        /// <summary>
        /// 対象とするAPIバージョン
        /// </summary>
        public string ApiVersion { get; set; }
        /// <summary>
        /// アクセス用のAPIキー
        /// </summary>
        public string ApiKey { get; set; }

        public RequestBase(string _ApiVersion, string _ApiKey)
        {

            this.ApiVersion = _ApiVersion;
            this.ApiKey = _ApiKey;

        }
    }
}
