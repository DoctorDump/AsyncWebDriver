// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Threading;
using Zu.WebBrowser.AsyncInteractions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncNavigation
    {
        private readonly INavigation _navigation;
        public SyncNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void Back()
        {
            _navigation.Back().GetAwaiter().GetResult();
            Thread.Sleep(50);
        }

        public void GoToUrl(string url)
        {
            _navigation.GoToUrl(url).GetAwaiter().GetResult();
            Thread.Sleep(200);
        }

        public void GoToUrl(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            _navigation.GoToUrl(url).GetAwaiter().GetResult();
            Thread.Sleep(50);
        }

        public void Forward()
        {
            _navigation.Forward().GetAwaiter().GetResult();
            Thread.Sleep(50);
        }

        public void Refresh()
        {
            _navigation.Refresh().GetAwaiter().GetResult();
            Thread.Sleep(50);
        }
    }
}