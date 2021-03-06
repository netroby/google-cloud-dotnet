﻿// Copyright 2017 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Web;
using Xunit;

namespace Google.Cloud.Diagnostics.AspNet.Tests
{
    public class HttpContextWrapperTest
    {
        [Fact]
        public void HttpContextWrapper()
        {
            var uri = "http://google.com/";
            var request = new HttpRequest("filename.cs", uri, "");
            var response = new HttpResponse(new StreamWriter(new MemoryStream()));
            var context = new HttpContext(request, response);

            var wrapper = new HttpContextWrapper(context);
            Assert.Equal("GET", wrapper.GetHttpMethod());
            Assert.Equal(uri, wrapper.GetUri());
            Assert.Null(wrapper.GetUserAgent());
            Assert.Equal(200, wrapper.GetStatusCode());
        }

        [Fact]
        public void HttpContextWrapper_NullHttpContext()
        {
            var wrapper = new HttpContextWrapper(null);
            Assert.Null(wrapper.GetHttpMethod());
            Assert.Null(wrapper.GetUri());
            Assert.Null(wrapper.GetUserAgent());
            Assert.Equal(0, wrapper.GetStatusCode());
        }
    }
}