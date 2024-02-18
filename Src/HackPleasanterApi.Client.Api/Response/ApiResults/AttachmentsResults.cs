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
namespace HackPleasanterApi.Client.Api.Response.ApiResults
{
    /// <summary>
    /// 添付ファイル詳細データ型
    /// </summary>
    public class Response
    {
        public long? ReferenceId { get; set; }
        public string? BinaryType { get; set; }
        public string? Base64 { get; set; }
        public string? Guid { get; set; }
        public string? FileName { get; set; }
        public string? Extension { get; set; }
        public int? Size { get; set; }
        public string? ContentType { get; set; }
        public long? Creator { get; set; }
        public long? Updator { get; set; }
        public string? CreatedTime { get; set; }
        public string? UpdatedTime { get; set; }
    }

    /// <summary>
    /// 添付ファイルを管理するデータ型
    /// </summary>
    public class AttachmentsResults : ChangeItemResults
    {
        public Response? Response { get; set; }

    }
}
