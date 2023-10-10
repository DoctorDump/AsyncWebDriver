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

        public void Open() => AsyncDriver.Open().GetAwaiter().GetResult();

        public string Context => GetContext();

        public string GetContext() => AsyncDriver.GetContext().GetAwaiter().GetResult();

        public void SetContextChrome() => AsyncDriver.SetContextChrome().GetAwaiter().GetResult();

        public void SetContextContent() => AsyncDriver.SetContextContent().GetAwaiter().GetResult();

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

        private static object[] ReplaceWebElementsInArgs(object[] args)
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

        public void ClickElement(string elementId) => AsyncDriver.ClickElement(elementId).GetAwaiter().GetResult();

        public void ClearElement(string elementId) => AsyncDriver.ClearElement(elementId).GetAwaiter().GetResult();

        public SyncWebElement FindElement(By by) => AsyncDriver.FindElement(by).GetSyncResult();

        public SyncWebElement FindElementOrDefault(By by) => AsyncDriver.FindElementOrDefault(by).GetSyncResult();

        public SyncWebElement FindElementByClassName(string className) => AsyncDriver.FindElementByClassName(className).GetSyncResult();

        public SyncWebElement FindElementByClassNameOrDefault(string className) => AsyncDriver.FindElementByClassNameOrDefault(className).GetSyncResult();

        public SyncWebElement FindElementByCssSelector(string cssSelector) => AsyncDriver.FindElementByCssSelector(cssSelector).GetSyncResult();

        public SyncWebElement FindElementByCssSelectorOrDefault(string cssSelector) => AsyncDriver.FindElementByCssSelectorOrDefault(cssSelector).GetSyncResult();

        public SyncWebElement FindElementById(string id) => AsyncDriver.FindElementById(id).GetSyncResult();

        public SyncWebElement FindElementByIdOrDefault(string id) => AsyncDriver.FindElementByIdOrDefault(id).GetSyncResult();

        public SyncWebElement FindElementByIdStartsWith(string id) => AsyncDriver.FindElementByIdStartsWith(id).GetSyncResult();

        public SyncWebElement FindElementByIdStartsWithOrDefault(string id) => AsyncDriver.FindElementByIdStartsWithOrDefault(id).GetSyncResult();

        public SyncWebElement FindElementByIdEndsWith(string id) => AsyncDriver.FindElementByIdEndsWith(id).GetSyncResult();

        public SyncWebElement FindElementByIdEndsWithOrDefault(string id) => AsyncDriver.FindElementByIdEndsWithOrDefault(id).GetSyncResult();

        public SyncWebElement FindElementByLinkText(string linkText) => AsyncDriver.FindElementByLinkText(linkText).GetSyncResult();

        public SyncWebElement FindElementByLinkTextOrDefault(string linkText) => AsyncDriver.FindElementByLinkTextOrDefault(linkText).GetSyncResult();

        public SyncWebElement FindElementByName(string name) => AsyncDriver.FindElementByName(name).GetSyncResult();

        public SyncWebElement FindElementByNameOrDefault(string name) => AsyncDriver.FindElementByNameOrDefault(name).GetSyncResult();

        public SyncWebElement FindElementByPartialLinkText(string partialLinkText) => AsyncDriver.FindElementByPartialLinkText(partialLinkText).GetSyncResult();

        public SyncWebElement FindElementByPartialLinkTextOrDefault(string partialLinkText) => AsyncDriver.FindElementByPartialLinkTextOrDefault(partialLinkText).GetSyncResult();

        public SyncWebElement FindElementByTagName(string tagName) => AsyncDriver.FindElementByTagName(tagName).GetSyncResult();

        public SyncWebElement FindElementByTagNameOrDefault(string tagName) => AsyncDriver.FindElementByTagNameOrDefault(tagName).GetSyncResult();

        public SyncWebElement FindElementByXPath(string xpath) => AsyncDriver.FindElementByXPath(xpath).GetSyncResult();

        public SyncWebElement FindElementByXPathOrDefault(string xpath) => AsyncDriver.FindElementByXPathOrDefault(xpath).GetSyncResult();

        public List<SyncWebElement> FindElements(By by) => AsyncDriver.FindElements(by).GetSyncResult();

        public List<SyncWebElement> Children() => AsyncDriver.Children().GetSyncResult();

        public List<SyncWebElement> FindElementsByClassName(string className) => AsyncDriver.FindElementsByClassName(className).GetSyncResult();

        public List<SyncWebElement> FindElementsByCssSelector(string cssSelector) => AsyncDriver.FindElementsByCssSelector(cssSelector).GetSyncResult();

        public List<SyncWebElement> FindElementsById(string id) => AsyncDriver.FindElementsById(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByIdOrDefault(string id) => AsyncDriver.FindElementsById(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByIdStartsWith(string id) => AsyncDriver.FindElementsByIdStartsWith(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByIdEndsWith(string id) => AsyncDriver.FindElementsByIdEndsWith(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByLinkText(string linkText) => AsyncDriver.FindElementsByLinkText(linkText).GetSyncResult();

        public List<SyncWebElement> FindElementsByName(string name) => AsyncDriver.FindElementsByName(name).GetSyncResult();

        public List<SyncWebElement> FindElementsByPartialLinkText(string partialLinkText) => AsyncDriver.FindElementsByPartialLinkText(partialLinkText).GetSyncResult();

        public List<SyncWebElement> FindElementsByTagName(string tagName) => AsyncDriver.FindElementsByTagName(tagName).GetSyncResult();

        public List<SyncWebElement> FindElementsByXPath(string xpath) => AsyncDriver.FindElementsByXPath(xpath).GetSyncResult();

        public string Url => GetUrl();

        public string GetUrl() => AsyncDriver.GetUrl().GetAwaiter().GetResult();

        public Screenshot GetScreenshot() => AsyncDriver.GetScreenshot().GetAwaiter().GetResult();

        public string GoToUrl(string url) => AsyncDriver.GoToUrl(url).GetAwaiter().GetResult();

        public SyncOptions Options() => new SyncOptions(AsyncDriver.Options());
        public SyncNavigation Navigate() => new SyncNavigation(AsyncDriver.Navigate());
        public SyncKeyboard Keyboard => new SyncKeyboard(AsyncDriver.Keyboard);
        public SyncMouse Mouse => new SyncMouse(AsyncDriver.Mouse);
        public string PageSource() => AsyncDriver.PageSource().GetAwaiter().GetResult();

        public void Quit() => AsyncDriver.Quit().GetAwaiter().GetResult();

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

        public void PerformActions(IList<ActionSequence> actionSequenceList) => AsyncDriver.PerformActions(actionSequenceList).GetAwaiter().GetResult();

        public void ResetInputState() => AsyncDriver.ResetInputState().GetAwaiter().GetResult();
    }
}