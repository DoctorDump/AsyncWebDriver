// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Zu.WebBrowser.AsyncInteractions;
using Zu.WebBrowser.BasicTypes;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncCoordinates
    {
        private ICoordinates coordinates;
        public SyncCoordinates(ICoordinates coordinates)
        {
            this.coordinates = coordinates;
        }

        public WebPoint LocationOnScreen()
        {
            WebPoint res = null;
            var MRes = new ManualResetEventSlim(true);
            MRes.Reset();
            Exception exception = null;
            Task.Run(async () =>
            {
                try
                {
                    res = await coordinates.LocationOnScreen().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                MRes.Set();
            }

            );
            MRes.Wait();
            if (exception != null)
                ExceptionDispatchInfo.Capture(exception).Throw();
            return res;
        }

        public WebPoint LocationInViewport()
        {
            WebPoint res = null;
            var MRes = new ManualResetEventSlim(true);
            MRes.Reset();
            Exception exception = null;
            Task.Run(async () =>
            {
                try
                {
                    res = await coordinates.LocationInViewport().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                MRes.Set();
            }

            );
            MRes.Wait();
            if (exception != null)
                ExceptionDispatchInfo.Capture(exception).Throw();
            return res;
        }

        public WebPoint LocationInDom()
        {
            WebPoint res = null;
            var MRes = new ManualResetEventSlim(true);
            MRes.Reset();
            Exception exception = null;
            Task.Run(async () =>
            {
                try
                {
                    res = await coordinates.LocationInDom().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                MRes.Set();
            }

            );
            MRes.Wait();
            if (exception != null)
                ExceptionDispatchInfo.Capture(exception).Throw();
            return res;
        }

        public string AuxiliaryLocator => coordinates.AuxiliaryLocator;
    }
}