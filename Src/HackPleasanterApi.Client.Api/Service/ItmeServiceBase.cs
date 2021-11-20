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

using HackPleasanterApi.Client.Api.Definition;
using HackPleasanterApi.Client.Api.Exceptions;
using HackPleasanterApi.Client.Api.Helper.Expansions;
using HackPleasanterApi.Client.Api.Helper.Service;
using HackPleasanterApi.Client.Api.Interface;
using HackPleasanterApi.Client.Api.Logging;
using HackPleasanterApi.Client.Api.Models.ItemModel;
using HackPleasanterApi.Client.Api.Models.ItemModel.Hash;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Response;
using HackPleasanterApi.Client.Api.Response.ApiResults;
using HackPleasanterApi.Client.Api.Response.ResponseData.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackPleasanterApi.Client.Api.Service
{
    /// <summary>
    /// アイテム情報にアクセスするための基底クラス
    /// </summary>
    public abstract class ItmeServiceBase<DataType, ExtensionElementsType> :
        ServiceBase where DataType : DTOBase<ExtensionElementsType>, new()
        where ExtensionElementsType : ExtensionElementsBase

    {

        /// <summary>
        /// 対象としているサイトID
        /// </summary>
        protected long SiteId;

        /// <summary>
        /// ロガーオブジェクト
        /// </summary>
        protected Logger L;

        public ItmeServiceBase(ServiceConfig config, long SiteId) : base(config)
        {
            this.SiteId = SiteId;
            this.L = LoggerManager.GetInstance().Logger;
        }

        /// <summary>
        /// アイテムを1個だけ取得する
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<DataType> GetItem(long itemID)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start GetItem id : {itemID}");

                var r = GenerateRequestBase<RequestBase>();

                HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/items/{itemID}/get", r);
                var targetData = await response.Content.ReadAsAsync<ItemApiResults<SingleItemResponse>>();

                // 実行成功判定
                if (true == response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK)
                {

                    var ps = targetData.Response.Data.Select(e =>
                    {
                        var t = new DataType();
                        t.rawData = e;
                        return t;
                    });

                    // 取れてくるのは1個だけなので
                    return ps.FirstOrDefault();
                }

                // 実行エラー発生
                throw new GetItemException<ItemApiResults<SingleItemResponse>>(targetData);
            });
        }

        /// <summary>
        /// 送信用の検索条件を設定する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private Request.View.ViewSend MakeSendViewData<T>(T request) where T : Request.View.View<DataType>, new()
        {
            if (null == request)
            {
                return null;
            }

            var View = new Request.View.ViewSend();

            // フィルタ条件は文字列で受け付けるので、文字列形式に変換する
            if (null != request.ColumnFilter)
            {
                var hash = new Dictionary<string, string>();
                foreach (var ele in request.ColumnFilter)
                {
                    ele.Merge(hash);
                }
                View.ColumnFilterHash = hash;
            }

            // ソート条件を指定
            if (null != request.ColumnSorter)
            {
                var hash = new Dictionary<string, string>();
                foreach (var ele in request.ColumnSorter)
                {
                    ele.Merge(hash);
                }
                View.ColumnSorterHash = hash;
            }

            return View;
        }

        /// <summary>
        /// アイテムを複数個取得する(検索を含む)
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DataType>> FindItems<T>(T request) where T : Request.View.View<DataType>, new()
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start FindItems id : {request.ToString()}");

                // 検索条件を設定
                var r = GenerateRequestBase<FindItemsRequest>();
                r.Offset = 0;
                r.ApiKey = serviceConfig.ApiKey;
                r.ApiVersion = serviceConfig.ApiVersion;

                // 検索条件を設定する
                r.View = MakeSendViewData(request);

                HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/items/{SiteId}/get", r);
                // API呼び出しを実行
                var targetData = await response.Content.ReadAsAsync<ItemApiResults<MultipleItemResponse>>();

                if (response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK)
                {
                    var ps = targetData.Response.Data.Select(e =>
                    {
                        var t = new DataType();
                        t.rawData = e;
                        return t;
                    });

                    // 存在するデータは全部とれる
                    return ps;
                }

                // 実行エラー発生
                throw new GetItemException<ItemApiResults<MultipleItemResponse>>(targetData);
            });

        }


        /// <summary>
        /// 添付ファイルを取得する
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<AttachmentsResults> GetAttachments(Attachments attachments)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start GetAttachments id ");

                var r = GenerateRequestBase<RequestBase>();

                HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/binaries/{attachments.Guid}/get", r);
                if (response.IsSuccessStatusCode)
                {
                    // API呼び出しを実行
                    var targetData = await response.Content.ReadAsAsync<AttachmentsResults>();
                    return targetData;
                }

                return null;

            });

        }


        /// <summary>
        /// アイテムを消去する
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<DeleteApiResults> DeleteItem(long itemID)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start DeleteItem id : {itemID}");

                var r = GenerateRequestBase<RequestBase>();

                HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/items/{itemID}/delete", r);
                // API呼び出しを実行
                var targetData = await response.Content.ReadAsAsync<DeleteApiResults>();

                if (response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK)
                {
                    return targetData;
                }
                // 実行エラー発生
                throw new ChangeItemResultsException(targetData);

            });
        }

        /// <summary>
        /// 指定条件で削除する
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<DeleteAllItemsResults> DeleteByConditions(DeleteAllItemsRequest<DataType> req)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start DeleteALL ");

                var r = req.ToDeleteAllItemsRequestSend();

                r.ApiKey = serviceConfig.ApiKey;
                r.ApiVersion = serviceConfig.ApiVersion;

                // 検索条件を設定する
                r.View = MakeSendViewData(req?.View);

                HttpResponseMessage response = await client.PostAsJsonAsync($"/api/items/{SiteId}/bulkdelete", r);
                // API呼び出しを実行
                var targetData = await response.Content.ReadAsAsync<DeleteAllItemsResults>();

                // 実行成功判定
                if (true == response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK
                    )
                {
                    return targetData;
                }

                // 実行エラー発生
                throw new ChangeItemResultsException(targetData);
            });

        }

        /// <summary>
        /// アイテムを一括削除する
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public async Task<DeleteAllItemsResults> DeleteALL(bool PhysicalDelete = false)
        {
                var rqe = new DeleteAllItemsRequest<DataType>();
                rqe.All = true;
                rqe.PhysicalDelete = PhysicalDelete;

                return await DeleteByConditions(rqe);
        }

        /// <summary>
        /// アイテムを作成する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private CreateItemRequest MakeCreateItemResponse(ItemRawData data)
        {

            var r = this.Mapper.Map<CreateItemRequest>(data);
            r.ApiKey = this.serviceConfig.ApiKey;
            return r;
        }

        private StringContent MakeStringContentSendNotNUll(object r)
        {

            // Attachments列にNULL列をそのまま設定してもエラーとなってしまう。
            // HttpClientのデフォルト設定だとNullは送信する事となっているので、
            // ここでは、NULLを送信しないように調整する
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(r, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }

        /// <summary>
        /// アイテムを作成する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<CreateItemResults> CreateItem(DataType data)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start CreateItem ");

                // 対象データを変換する
                var r = MakeCreateItemResponse(data.rawData);

                // Attachments列にNULL列をそのまま設定してもエラーとなってしまう。
                // HttpClientのデフォルト設定だとNullは送信する事となっているので、
                // ここでは、NULLを送信しないように調整する
                //var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                //var json = JsonConvert.SerializeObject(r, settings);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                var content = MakeStringContentSendNotNUll(r);

                //HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/items/{SiteId}/create", r);
                HttpResponseMessage response = await client.PostAsync($"pleasanter/api/items/{SiteId}/create", content);

                // API呼び出しを実行
                var targetData = await response.Content.ReadAsAsync<CreateItemResults>();

                // 実行成功判定
                if (true == response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK
                    )
                {
                    return targetData;
                }

                // 実行エラー発生
                throw new CreateItemException(targetData);
            });
        }

        /// <summary>
        /// アイテム情報更新
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<CreateItemResults> UpdateItem(long itemID, DataType data)
        {
            return await ServiceHelperFunctions.DoReyry(async () =>
            {

                L.Info(() => $"Start UpdateItem ");

                // 対象データを変換する
                var r = MakeCreateItemResponse(data.rawData);

                var content = MakeStringContentSendNotNUll(r);

                //HttpResponseMessage response = await client.PostAsJsonAsync($"pleasanter/api/items/{itemID}/update", r);
                HttpResponseMessage response = await client.PostAsync($"pleasanter/api/items/{itemID}/update", content);

                // API呼び出しを実行
                var targetData = await response.Content.ReadAsAsync<CreateItemResults>();

                // 実行成功判定
                if (true == response.IsSuccessStatusCode &&
                    targetData?.StatusCode == (int)StatusCode.OK
                    )
                {
                    return targetData;
                }

                // 実行エラー発生
                throw new CreateItemException(targetData);
            });
        }
    }
}
