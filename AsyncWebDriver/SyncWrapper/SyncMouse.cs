// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebBrowser.AsyncInteractions;
using Zu.WebBrowser.BasicTypes;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncMouse
    {
        private readonly IMouse _mouse;
        public SyncMouse(IMouse mouse)
        {
            _mouse = mouse;
        }

        public void Click(ICoordinates where) => _mouse.Click(where).Wait();

        public void ContextClick(ICoordinates where) => _mouse.ContextClick(where).Wait();

        public void DoubleClick(ICoordinates where) => _mouse.DoubleClick(where).Wait();

        public void MouseDown(ICoordinates where) => _mouse.MouseDown(where).Wait();

        public void MouseMove(ICoordinates where) => _mouse.MouseMove(where).Wait();

        public void MouseUp(ICoordinates where) => _mouse.MouseUp(where).Wait();

        public void Click(WebPoint where) => _mouse.Click(where).Wait();

        public void ContextClick(WebPoint where) => _mouse.ContextClick(where).Wait();

        public void DoubleClick(WebPoint where) => _mouse.DoubleClick(where).Wait();

        public void MouseDown(WebPoint where) => _mouse.MouseDown(where).Wait();

        public void MouseMove(WebPoint where) => _mouse.MouseMove(where).Wait();

        public void MouseUp(WebPoint where) => _mouse.MouseUp(where).Wait();
    }
}