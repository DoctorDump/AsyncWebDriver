// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using Zu.WebBrowser.BasicTypes;
using Zu.WebBrowser.BrowserOptions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncCookieJar
    {
        private readonly ICookieJar _cookies;
        public SyncCookieJar(ICookieJar cookies)
        {
            _cookies = cookies;
        }

        public void AddCookie(Cookie cookie) => _cookies.AddCookie(cookie).Wait();

        public ReadOnlyCollection<Cookie> AllCookies() => _cookies.AllCookies().GetAwaiter().GetResult();

        public void DeleteAllCookies() => _cookies.DeleteAllCookies().Wait();

        public void DeleteCookie(Cookie cookie) => _cookies.DeleteCookie(cookie).Wait();

        public void DeleteCookieNamed(string name) => _cookies.DeleteCookieNamed(name).Wait();

        public Cookie GetCookieNamed(string name) => _cookies.GetCookieNamed(name).GetAwaiter().GetResult();
    }
}