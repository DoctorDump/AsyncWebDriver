// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Zu.WebBrowser.BasicTypes;
using System.Collections;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncWebDriver
    {
        public SyncWebDriver(WebDriver asyncDriver)
        {
            AsyncDriver = asyncDriver;
        }

        public WebDriver AsyncDriver { get; }

        public void Close() => AsyncDriver.CloseSync();

        public void Open() => AsyncDriver.Open().Wait();

        public string Context => GetContext();

        public string GetContext() => AsyncDriver.GetContext().GetAwaiter().GetResult();

        public void SetContextChrome() => AsyncDriver.SetContextChrome().Wait();

        public void SetContextContent() => AsyncDriver.SetContextContent().Wait();

        public string CurrentWindowHandle => GetCurrentWindowHandle();

        public string GetCurrentWindowHandle() => AsyncDriver.CurrentWindowHandle().GetAwaiter().GetResult();

        public void Dispose() => AsyncDriver.Dispose();

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return ReplaceWebElements(AsyncDriver.ExecuteAsyncScript(script, default, ReplaceWebElementsInArgs(args)).GetAwaiter().GetResult());
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return ReplaceWebElements(AsyncDriver.ExecuteScript(script, default, ReplaceWebElementsInArgs(args)).GetAwaiter().GetResult());
        }

        private object[] ReplaceWebElementsInArgs(object[] args)
        {
            return args == null ? new object[] { null } : args.Select(ReplaceWebElementsInArg).ToArray();
        }

        private static object ReplaceWebElementsInArg(object obj)
        {
            switch (obj)
            {
                case SyncWebElement element:
                    return element.AsyncElement;
                case IDictionary dic:
                    return dic
                        .Cast<DictionaryEntry>()
                        .ToDictionary(item => item.Key.ToString(), item => ReplaceWebElementsInArg(item.Value));
                case IEnumerable col when !(col is string):
                    return col.Cast<object>().Select(ReplaceWebElementsInArg).ToList();
                default:
                    return obj;
            }
        }

        private static object ReplaceWebElements(object obj)
        {
            switch (obj)
            {
                case AsyncWebElement element:
                    return new SyncWebElement(element);
                case IDictionary dic:
                    return dic
                        .Cast<DictionaryEntry>()
                        .ToDictionary(item => item.Key.ToString(), item => ReplaceWebElements(item.Value));
                case IEnumerable col when !(col is string):
                    return new ReadOnlyCollection<object>(col.Cast<object>().Select(ReplaceWebElements).ToList());
                default:
                    return obj;
            }
        }

        public void ClickElement(string elementId) => AsyncDriver.ClickElement(elementId).Wait();

        public void ClearElement(string elementId) => AsyncDriver.ClearElement(elementId).Wait();

        public SyncWebElement FindElement(By by)
        {
            return AsyncDriver.FindElement(by).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementOrDefault(By by)
        {
            return AsyncDriver.FindElementOrDefault(by).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByClassName(string className)
        {
            return AsyncDriver.FindElementByClassName(className).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByClassNameOrDefault(string className)
        {
            return AsyncDriver.FindElementByClassNameOrDefault(className).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByCssSelector(string cssSelector)
        {
            return AsyncDriver.FindElementByCssSelector(cssSelector).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByCssSelectorOrDefault(string cssSelector)
        {
            return AsyncDriver.FindElementByCssSelectorOrDefault(cssSelector).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementById(string id)
        {
            return AsyncDriver.FindElementById(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByIdOrDefault(string id)
        {
            return AsyncDriver.FindElementByIdOrDefault(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByIdStartsWith(string id)
        {
            return AsyncDriver.FindElementByIdStartsWith(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByIdStartsWithOrDefault(string id)
        {
            return AsyncDriver.FindElementByIdStartsWithOrDefault(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByIdEndsWith(string id)
        {
            return AsyncDriver.FindElementByIdEndsWith(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByIdEndsWithOrDefault(string id)
        {
            return AsyncDriver.FindElementByIdEndsWithOrDefault(id).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByLinkText(string linkText)
        {
            return AsyncDriver.FindElementByLinkText(linkText).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByLinkTextOrDefault(string linkText)
        {
            return AsyncDriver.FindElementByLinkTextOrDefault(linkText).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByName(string name)
        {
            return AsyncDriver.FindElementByName(name).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByNameOrDefault(string name)
        {
            return AsyncDriver.FindElementByNameOrDefault(name).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return AsyncDriver.FindElementByPartialLinkText(partialLinkText).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByPartialLinkTextOrDefault(string partialLinkText)
        {
            return AsyncDriver.FindElementByPartialLinkTextOrDefault(partialLinkText).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByTagName(string tagName)
        {
            return AsyncDriver.FindElementByTagName(tagName).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByTagNameOrDefault(string tagName)
        {
            return AsyncDriver.FindElementByTagNameOrDefault(tagName).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByXPath(string xpath)
        {
            return AsyncDriver.FindElementByXPath(xpath).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public SyncWebElement FindElementByXPathOrDefault(string xpath)
        {
            return AsyncDriver.FindElementByXPathOrDefault(xpath).GetAwaiter().GetResult() is AsyncWebElement element ? new SyncWebElement(element) : null;
        }

        public List<SyncWebElement> FindElements(By by)
        {
            var r = AsyncDriver.FindElements(by).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement((AsyncWebElement)v)).ToList();
        }

        public List<SyncWebElement> Children()
        {
            var r = AsyncDriver.Children().GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByClassName(string className)
        {
            var r = AsyncDriver.FindElementsByClassName(className).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByCssSelector(string cssSelector)
        {
            var r = AsyncDriver.FindElementsByCssSelector(cssSelector).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsById(string id)
        {
            var r = AsyncDriver.FindElementsById(id).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByIdOrDefault(string id)
        {
            var r = AsyncDriver.FindElementsById(id).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByIdStartsWith(string id)
        {
            var r = AsyncDriver.FindElementsByIdStartsWith(id).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByIdEndsWith(string id)
        {
            var r = AsyncDriver.FindElementsByIdEndsWith(id).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByLinkText(string linkText)
        {
            var r = AsyncDriver.FindElementsByLinkText(linkText).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByName(string name)
        {
            var r = AsyncDriver.FindElementsByName(name).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            var r = AsyncDriver.FindElementsByPartialLinkText(partialLinkText).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByTagName(string tagName)
        {
            var r = AsyncDriver.FindElementsByTagName(tagName).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public List<SyncWebElement> FindElementsByXPath(string xpath)
        {
            var r = AsyncDriver.FindElementsByXPath(xpath).GetAwaiter().GetResult();
            return r?.Where(a => a is AsyncWebElement).Select(v => new SyncWebElement(v as AsyncWebElement)).ToList();
        }

        public string Url => GetUrl();

        public string GetUrl() => AsyncDriver.GetUrl().GetAwaiter().GetResult();

        public Screenshot GetScreenshot() => AsyncDriver.GetScreenshot().GetAwaiter().GetResult();

        public string GoToUrl(string url) => AsyncDriver.GoToUrl(url).GetAwaiter().GetResult();

        public SyncOptions Options() => new SyncOptions(AsyncDriver.Options());
        public SyncNavigation Navigate() => new SyncNavigation(AsyncDriver.Navigate());
        public SyncKeyboard Keyboard => new SyncKeyboard(AsyncDriver.Keyboard);
        public SyncMouse Mouse => new SyncMouse(AsyncDriver.Mouse);
        public string PageSource() => AsyncDriver.PageSource().GetAwaiter().GetResult();

        public void Quit() => AsyncDriver.Quit().Wait();

        public SyncRemoteTargetLocator SwitchTo() => new SyncRemoteTargetLocator(AsyncDriver.SwitchTo());
        public string Title() => AsyncDriver.Title().GetAwaiter().GetResult();

        public List<string> WindowHandles() => AsyncDriver.WindowHandles().GetAwaiter().GetResult();

        //public bool WaitForElementWithId(string id, string notWebElementId = null, int attemptsCount = 20, int delayMs = 500)
        //{
        //    if (notWebElementId != null) return WaitForWebElement(() => FindElementById(id), attemptsCount, delayMs);
        //    else return WaitForWebElement(() => FindElementById(id), notWebElementId, attemptsCount, delayMs);
        //}
        //private bool WaitForWebElement(Func<SyncWebElement> func, int attemptsCount = 20, int delayMs = 500)
        //{
        //    for (int i = 0; i < attemptsCount; i++)
        //    {
        //        Thread.Sleep(delayMs);
        //        var el = func.Invoke();
        //        if (!string.IsNullOrWhiteSpace(el?.AsyncElement?.Id)) return true;
        //    }
        //    return false;
        //}
        //private bool WaitForWebElement(Func<SyncWebElement> func, string notWebElementId, int attemptsCount = 20, int delayMs = 500)
        //{
        //    for (int i = 0; i < attemptsCount; i++)
        //    {
        //        Thread.Sleep(delayMs);
        //        var el = func.Invoke();
        //        if (notWebElementId != null && el?.Id == notWebElementId) continue;
        //        if (!string.IsNullOrWhiteSpace(el?.AsyncElement?.Id)) return true;
        //    }
        //    return false;
        //}
        public bool IsActionExecutor() => AsyncDriver.IsActionExecutor().GetAwaiter().GetResult();

        public void PerformActions(IList<ActionSequence> actionSequenceList) => AsyncDriver.PerformActions(actionSequenceList).Wait();

        public void ResetInputState() => AsyncDriver.ResetInputState().Wait();
    }
}