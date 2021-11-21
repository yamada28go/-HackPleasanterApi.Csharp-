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


    public class Logger
    {
        /// <summary>
        /// 対象ログレベル
        /// </summary>
        private LogLevel logLevel;

        private string LogPrefix;

        #region ロギング関数

        private Action<string> LoginInfo = null;
        private Action<string> LoginError = null;
        private Action<string> LoginDebug = null;

        #endregion


        public Logger(
         LogLevel LogLevel,
         string LogPrefix,
         Action<string> LoginError,
         Action<string> LoginInfo,
         Action<string> LoginDebug
            )
        {
            this.logLevel = LogLevel;
            this.LogPrefix = LogPrefix;
            this.LoginError = LoginError;
            this.LoginInfo = LoginInfo;
            this.LoginDebug = LoginDebug;
        }

        public void Error(Exception exp)
        {

            if (this.logLevel != LogLevel.NoLog
                )
            {

                try
                {
                    this?.LoginError($"{LogPrefix}Error! { exp.Message}");
                }
                catch
                {
                    // ログエラーは捨てる
                }
            }
        }

        public void Error(Func<string> makeLog)
        {

            if (this.logLevel != LogLevel.NoLog
                )
            {

                try
                {
                    this?.LoginError($"{LogPrefix}{makeLog()}");
                }
                catch
                {
                    // ログエラーは捨てる
                }
            }
        }

        public void Info(Func<string> makeLog)
        {
            if (this.logLevel == LogLevel.Info ||
                this.logLevel == LogLevel.Error)
            {
                try
                {
                    this?.LoginInfo($"{LogPrefix}{makeLog()}");
                }
                catch
                {
                    // ログエラーは捨てる
                }
            }
        }


        public void Debug(Func<string> makeLog)
        {

            if (this.logLevel == LogLevel.Error ||
                this.logLevel == LogLevel.Info ||
                this.logLevel == LogLevel.Debug
                )
            {

                try
                {
                    this?.LoginDebug($"{LogPrefix}{makeLog()}");
                }
                catch
                {
                    // ログエラーは捨てる
                }
            }
        }

    }
}
