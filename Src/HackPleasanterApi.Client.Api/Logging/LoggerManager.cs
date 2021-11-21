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
namespace HackPleasanterApi.Client.Api.Logging
{
    /// <summary>ログ管理クラス
    /// 
    /// </summary>
    public sealed class LoggerManager
    {
        private static LoggerManager _singleInstance = new LoggerManager();

        public static LoggerManager GetInstance()
        {
            return _singleInstance;
        }

        private LoggerManager()
        {
        }

        #region ログ共通設定型

        /// <summary>
        /// ログレベル
        /// </summary>
        public LogLevel LogLevel = LogLevel.NoLog;

        #endregion

        #region ロギング関数

        public Action<string> LoginInfo = null;
        public Action<string> LoginError = null;
        public Action<string> LoginDebug = null;

        #endregion

        /// <summary>
        /// ログ出力時のプレフィックス
        /// </summary>
        public string LogPrefix = "[PleasanterApi] ";

        /// <summary>
        /// ロガーを取得する
        /// </summary>
        public Logger Logger
        {
            get
            {
                return new Logger(this.LogLevel,this.LogPrefix ,this.LoginError, this.LoginInfo, this.LoginDebug);
            }
        }

    }
}
