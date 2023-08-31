using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Zu.AsyncWebDriver.Remote
{
    internal static class AsyncToSyncHelper
    {
        public static List<SyncWebElement> GetSyncResult(this Task<ReadOnlyCollection<IWebElement>> task)
        {
            return task.GetAwaiter().GetResult()?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }
        public static SyncWebElement GetSyncResult(this Task<IWebElement> task) => task.GetAwaiter().GetResult() is AsyncWebElement e ? new SyncWebElement(e) : null;

        public static SyncWebDriver GetSyncResult(this Task<IWebDriver> task) => task.GetAwaiter().GetResult() is WebDriver d ? new SyncWebDriver(d) : null;
    }
}