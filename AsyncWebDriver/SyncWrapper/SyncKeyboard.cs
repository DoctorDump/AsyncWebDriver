// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebBrowser.AsyncInteractions;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncKeyboard
    {
        private readonly IKeyboard _keyboard;
        public SyncKeyboard(IKeyboard keyboard)
        {
            _keyboard = keyboard;
        }

        public void PressKey(string keyToPress) => _keyboard.PressKey(keyToPress).Wait();

        public void SendKeys(string keySequence) => _keyboard.SendKeys(keySequence).Wait();

        public void ReleaseKey(string keyToRelease) => _keyboard.ReleaseKey(keyToRelease).Wait();
    }
}