// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebBrowser.AsyncInteractions;
using Zu.WebBrowser.BasicTypes;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncCoordinates
    {
        private readonly ICoordinates _coordinates;
        public SyncCoordinates(ICoordinates coordinates)
        {
            _coordinates = coordinates;
        }

        public WebPoint LocationOnScreen() => _coordinates.LocationOnScreen().GetAwaiter().GetResult();

        public WebPoint LocationInViewport() => _coordinates.LocationInViewport().GetAwaiter().GetResult();

        public WebPoint LocationInDom() => _coordinates.LocationInDom().GetAwaiter().GetResult();

        public string AuxiliaryLocator => _coordinates.AuxiliaryLocator;
    }
}