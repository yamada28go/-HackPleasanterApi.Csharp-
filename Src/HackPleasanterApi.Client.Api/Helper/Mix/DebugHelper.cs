using System;
using System.Text.Json;

namespace HackPleasanterApi.Client.Api.Helper.Mix
{
    /// <summary>
    /// デバッグ補助
    /// </summary>
    public static class DebugHelper
    {
        /// <summary>
        /// JSON形式でダンプする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string  DumpAsJsonString<T>(this T src  ) {

            try
            {
                string jsonString = JsonSerializer.Serialize(src);
                return jsonString;
            }
            catch (Exception exp) {

            }
            return "Dump Faild!";
        }

    }
}
