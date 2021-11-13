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
using HackPleasanterApi.Client.Api.Request.View;

namespace HackPleasanterApi.Client.Api.Request
{
    /// <summary>
    /// ユーザー検索用リクエスト
    /// </summary>
    ///
    public class FindItemsRequest : RequestBase , ViewSendInterface
    {
        /// <summary>
        /// 検索時のオフセット
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// 検索条件
        /// </summary>
        public Request.View.ViewSend View { get; set; }
    }
}
