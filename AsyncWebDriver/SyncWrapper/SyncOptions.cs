// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebBrowser.BrowserOptions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncOptions
    {
        private readonly IOptions _options;

        public SyncOptions(IOptions options)
        {
            _options = options;
        }

        public SyncCookieJar Cookies => new SyncCookieJar(_options.Cookies);
        public SyncWindow Window => new SyncWindow(_options.Window);
        public SyncLogs Logs => new SyncLogs(_options.Logs);
        public SyncTimeouts Timeouts => new SyncTimeouts(_options.Timeouts);

    }
}