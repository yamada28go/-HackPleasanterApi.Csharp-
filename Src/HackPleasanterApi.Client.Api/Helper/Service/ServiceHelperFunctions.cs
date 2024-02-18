using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HackPleasanterApi.Client.Api.Definition;
using HackPleasanterApi.Client.Api.Exceptions;
using HackPleasanterApi.Client.Api.Logging;

namespace HackPleasanterApi.Client.Api.Helper.Service
{
    public static class ServiceHelperFunctions
    {
        /// <summary>
        /// APIに対してリトライを実行する
        /// </summary>
        /// <param name="act"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static async Task<T> DoReyry<T>(Func<Task<T>> act, int num = DefaultConfiguration.RetryCount)
        {
            var L = LoggerManager.GetInstance().Logger;

            var exps = new List<Exception>();

            // 該当処理を実行する
            L.Debug(() => $"start API Call With retry count max count is : {num} ");


            for (int i = 0; i < num; i++)
            {
                try
                {
                    // 該当処理を実行する
                    L.Debug(() => $"start API Call retry count  : {i}");
                    var r = await act();
                    L.Debug(() => $"end API Call retry count  : {i}");
                    return r;
                }
                catch (Exception exp)
                {
                    L.Error(exp);
                    L.Debug(() => $"API Call retry count  : {i}");
                    exps.Add(exp);
                }
            }

            L.Error(() => $"Api Retry Faild!");
            throw new HackPleasanterApiExceptions(exps);
        }
    }
}
