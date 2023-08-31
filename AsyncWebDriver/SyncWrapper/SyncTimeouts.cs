// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using Zu.WebBrowser.BrowserOptions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncTimeouts
    {
        private readonly ITimeouts _timeouts;

        public SyncTimeouts(ITimeouts timeouts)
        {
            _timeouts = timeouts;
        }

        public TimeSpan GetAsynchronousJavaScript() => _timeouts.GetAsynchronousJavaScript().GetAwaiter().GetResult();

        public TimeSpan GetImplicitWait() => _timeouts.GetImplicitWait().GetAwaiter().GetResult();

        public TimeSpan GetPageLoad() => _timeouts.GetPageLoad().GetAwaiter().GetResult();

        public void SetAsynchronousJavaScript(TimeSpan time) => _timeouts.SetAsynchronousJavaScript(time).Wait();

        public void SetImplicitWait(TimeSpan implicitWait) => _timeouts.SetImplicitWait(implicitWait).Wait();

        public void SetPageLoad(TimeSpan time) => _timeouts.SetPageLoad(time).Wait();
    }
}