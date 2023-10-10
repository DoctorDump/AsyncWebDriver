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

        public void Click(ICoordinates where) => _mouse.Click(where).GetAwaiter().GetResult();

        public void ContextClick(ICoordinates where) => _mouse.ContextClick(where).GetAwaiter().GetResult();

        public void DoubleClick(ICoordinates where) => _mouse.DoubleClick(where).GetAwaiter().GetResult();

        public void MouseDown(ICoordinates where) => _mouse.MouseDown(where).GetAwaiter().GetResult();

        public void MouseMove(ICoordinates where) => _mouse.MouseMove(where).GetAwaiter().GetResult();

        public void MouseUp(ICoordinates where) => _mouse.MouseUp(where).GetAwaiter().GetResult();

        public void Click(WebPoint where) => _mouse.Click(where).GetAwaiter().GetResult();

        public void ContextClick(WebPoint where) => _mouse.ContextClick(where).GetAwaiter().GetResult();

        public void DoubleClick(WebPoint where) => _mouse.DoubleClick(where).GetAwaiter().GetResult();

        public void MouseDown(WebPoint where) => _mouse.MouseDown(where).GetAwaiter().GetResult();

        public void MouseMove(WebPoint where) => _mouse.MouseMove(where).GetAwaiter().GetResult();

        public void MouseUp(WebPoint where) => _mouse.MouseUp(where).GetAwaiter().GetResult();
    }
}