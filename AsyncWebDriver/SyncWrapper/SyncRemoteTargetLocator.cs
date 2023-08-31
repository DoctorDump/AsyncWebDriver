// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncRemoteTargetLocator
    {
        private readonly RemoteTargetLocator _locator;
        //private ITargetLocator targetLocator;
        public SyncRemoteTargetLocator(RemoteTargetLocator locator)
        {
            _locator = locator;
        }

        //public SyncRemoteTargetLocator(ITargetLocator targetLocator)
        //{
        //    this.targetLocator = targetLocator;
        //}
        public SyncWebElement ActiveElement() => _locator.ActiveElement().GetSyncResult();

        public SyncAlert Alert() => new SyncAlert(_locator.Alert().GetAwaiter().GetResult());

        public SyncWebDriver DefaultContent() => _locator.DefaultContent().GetSyncResult();

        public SyncWebDriver Frame(int frameIndex) => _locator.Frame(frameIndex).GetSyncResult();

        public SyncWebDriver Frame(string frameName) => _locator.Frame(frameName).GetSyncResult();

        public SyncWebDriver Frame(SyncWebElement frameElement) => _locator.Frame(frameElement.AsyncElement).GetSyncResult();

        public SyncWebDriver ParentFrame() => _locator.ParentFrame().GetSyncResult();

        public SyncWebDriver Window(string windowName) => _locator.Window(windowName).GetSyncResult();
    }
}