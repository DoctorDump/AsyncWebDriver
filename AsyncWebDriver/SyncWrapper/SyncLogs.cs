// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebBrowser.BrowserOptions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncLogs
    {
        private ILogs _logs;

        public SyncLogs(ILogs logs)
        {
            _logs = logs;
        }
    }
}