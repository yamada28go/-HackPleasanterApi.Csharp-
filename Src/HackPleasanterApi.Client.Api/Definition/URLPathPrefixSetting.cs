using System;
namespace HackPleasanterApi.Client.Api.Definition
{
    /// <summary>
    /// URLのパスにプレフィックスを追加すための修飾オブジェクト
    /// </summary>
    public class URLPathPrefixSetting
    {
        //修飾用のプレフィックスを指定する
        public string Prefix
        {
            get
            {
                return this._prefix;
            }
        }

        private String _prefix;


        /// <summary>
        /// APIの実行パスにプレフィックスを指定する。
        ///
        /// 0.0.6 までは、以下値が指定されていた。
		/// 必用に応じて、この値を指定する
		/// 
        /// pleasanter/
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        public URLPathPrefixSetting(String prefix = "")
        {
            this._prefix = prefix;
        }
    }
}

