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
using System.Threading.Tasks;
using CsharpSamples.Generated.Service;
using HackPleasanterApi.Client.Api.Request;
using HackPleasanterApi.Client.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static HackPleasanterApi.Client.Api.Helper.Expansions.DateTimeExpansion;
using HackPleasanterApi.Client.Api.Logging;
using HackPleasanterApi.Client.Api.Helper.Service;
using HackPleasanterApi.Client.Api.Exceptions;
using HackPleasanterApi.Client.Api.Definition;

namespace HackPleasanterApiTest.ItemTest
{
    [TestClass]
    public class ServiceHelperFunctionsTest : TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //ロガー関数の設定を行う
            LoggerManager.GetInstance().LogLevel = LogLevel.Debug;

            LoggerManager.GetInstance().LoginDebug = (x) => Console.WriteLine(x);
            LoggerManager.GetInstance().LoginInfo = (x) => Console.WriteLine(x);
        }

        [TestMethod]
        public async Task 正常系_関数の値が帰ってくることを確認()
        {
            var r = await ServiceHelperFunctions.DoReyry( async () => {
                await Task.CompletedTask;
                return 1;
            });

            Assert.AreEqual(1, r);
        }


        [TestMethod]
        public async Task 異常系_指定回数リトライカウントされることを確認()
        {

            // 対象例外を発生させる
            HackPleasanterApiExceptions targrteExp = null;
            try
            {
                var r = await ServiceHelperFunctions.DoReyry<int>(async () => {
                    await Task.CompletedTask;
                    throw new ApplicationException("Error");
                });
            }
            catch (HackPleasanterApiExceptions exp)
            {
                targrteExp = exp;
            }

            Assert.IsNotNull(targrteExp);
            Assert.AreEqual(DefaultConfiguration.RetryCount, targrteExp.InnerExceptions.Count);
            var tex = targrteExp.InnerExceptions[0] as ApplicationException;
            Assert.AreEqual("Error", tex.Message);

        }


    }
}


