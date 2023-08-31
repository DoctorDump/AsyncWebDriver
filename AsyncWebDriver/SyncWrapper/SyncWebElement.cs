// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Collections.Generic;
using System.Linq;
using Zu.WebBrowser.BasicTypes;

namespace Zu.AsyncWebDriver.Remote
{
    public class SyncWebElement
    {
        public SyncWebElement(AsyncWebElement element)
        {
            AsyncElement = element;
        }

        public AsyncWebElement AsyncElement { get; }

        public string Id => AsyncElement?.Id;
        public string TagName => GetTagName();
        public string Text => GetText();
        public bool Enabled => GetEnabled();
        public bool Selected => GetSelected();
        public WebPoint Location => GetLocation();
        public WebSize Size => GetSize();
        public bool Displayed => GetDisplayed();
        public WebPoint LocationOnScreenOnceScrolledIntoView => GetLocationOnScreenOnceScrolledIntoView();
        public SyncCoordinates Coordinates => new SyncCoordinates(AsyncElement.Coordinates);
        public string OuterHtml => GetProperty("outerHTML");
        public string InnerHtml => GetProperty("innerHTML");
        public SyncWebElement First => GetChildren()?.FirstOrDefault();
        public SyncWebElement Last => GetChildren()?.FirstOrDefault();
        public List<SyncWebElement> Children => GetChildren();
        public override string ToString() => AsyncElement?.ToString() ?? "AsyncElement = null";

        public string GetTagName() => AsyncElement.TagName().GetAwaiter().GetResult();

        public string GetText() => AsyncElement.Text().GetAwaiter().GetResult();

        public bool GetEnabled() => AsyncElement.Enabled().GetAwaiter().GetResult();

        public bool GetSelected() => AsyncElement.Selected().GetAwaiter().GetResult();

        public WebPoint GetLocation() => AsyncElement.Location().GetAwaiter().GetResult();

        public WebSize GetSize() => AsyncElement.Size().GetAwaiter().GetResult();

        public bool GetDisplayed() => AsyncElement.Displayed().GetAwaiter().GetResult();

        public WebPoint GetLocationOnScreenOnceScrolledIntoView() => AsyncElement.LocationOnScreenOnceScrolledIntoView().GetAwaiter().GetResult();

        public void Clear() => AsyncElement.Clear().Wait();

        public void SendKeys(string text) => AsyncElement.SendKeys(text).Wait();

        public void Submit() => AsyncElement.Submit().Wait();

        public void Click() => AsyncElement.Click().Wait();

        public string GetAttribute(string attributeName) => AsyncElement.GetAttribute(attributeName).GetAwaiter().GetResult();

        public string GetProperty(string propertyName) => AsyncElement.GetProperty(propertyName).GetAwaiter().GetResult();

        public string GetCssValue(string propertyName) => AsyncElement.GetCssValue(propertyName).GetAwaiter().GetResult();

        public List<SyncWebElement> GetChildren() => AsyncElement.Children().GetSyncResult();

        public List<SyncWebElement> FindElements(By by) => AsyncElement.FindElements(by).GetSyncResult();

        public SyncWebElement FindElement(By by) => AsyncElement.FindElement(by).GetSyncResult();

        public SyncWebElement FindElementByLinkText(string linkText) => AsyncElement.FindElementByLinkText(linkText).GetSyncResult();

        public SyncWebElement FindElementByLinkTextOrDefault(string linkText) => AsyncElement.FindElementByLinkTextOrDefault(linkText).GetSyncResult();

        public List<SyncWebElement> FindElementsByLinkText(string linkText) => AsyncElement.FindElementsByLinkText(linkText).GetSyncResult();

        public SyncWebElement FindElementById(string id) => AsyncElement.FindElementById(id).GetSyncResult();

        public SyncWebElement FindElementByIdOrDefault(string id) => AsyncElement.FindElementByIdOrDefault(id).GetSyncResult();

        public SyncWebElement FindElementByIdStartsWith(string id) => AsyncElement.FindElementByIdStartsWith(id).GetSyncResult();

        public SyncWebElement FindElementByIdStartsWithOrDefault(string id) => AsyncElement.FindElementByIdStartsWithOrDefault(id).GetSyncResult();

        public SyncWebElement FindElementByIdEndsWith(string id) => AsyncElement.FindElementByIdEndsWith(id).GetSyncResult();

        public SyncWebElement FindElementByIdEndsWithOrDefault(string id) => AsyncElement.FindElementByIdEndsWithOrDefault(id).GetSyncResult();

        public List<SyncWebElement> FindElementsById(string id) => AsyncElement.FindElementsById(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByIdStartsWith(string id) => AsyncElement.FindElementsByIdStartsWith(id).GetSyncResult();

        public List<SyncWebElement> FindElementsByIdEndsWith(string id) => AsyncElement.FindElementsByIdEndsWith(id).GetSyncResult();

        public SyncWebElement FindElementByName(string name) => AsyncElement.FindElementByName(name).GetSyncResult();

        public SyncWebElement FindElementByNameOrDefault(string name) => AsyncElement.FindElementByNameOrDefault(name).GetSyncResult();

        public List<SyncWebElement> FindElementsByName(string name) => AsyncElement.FindElementsByName(name).GetSyncResult();

        public SyncWebElement FindElementByTagName(string tagName) => AsyncElement.FindElementByTagName(tagName).GetSyncResult();

        public SyncWebElement FindElementByTagNameOrDefault(string tagName) => AsyncElement.FindElementByTagNameOrDefault(tagName).GetSyncResult();

        public List<SyncWebElement> FindElementsByTagName(string tagName) => AsyncElement.FindElementsByTagName(tagName).GetSyncResult();

        public SyncWebElement FindElementByClassName(string className) => AsyncElement.FindElementByClassName(className).GetSyncResult();

        public SyncWebElement FindElementByClassNameOrDefault(string className) => AsyncElement.FindElementByClassNameOrDefault(className).GetSyncResult();

        public List<SyncWebElement> FindElementsByClassName(string className) => AsyncElement.FindElementsByClassName(className).GetSyncResult();

        public SyncWebElement FindElementByXPath(string xpath) => AsyncElement.FindElementByXPath(xpath).GetSyncResult();

        public SyncWebElement FindElementByXPathOrDefault(string xpath) => AsyncElement.FindElementByXPathOrDefault(xpath).GetSyncResult();

        public List<SyncWebElement> FindElementsByXPath(string xpath) => AsyncElement.FindElementsByXPath(xpath).GetSyncResult();

        public SyncWebElement FindElementByPartialLinkText(string partialLinkText) => AsyncElement.FindElementByPartialLinkText(partialLinkText).GetSyncResult();

        public SyncWebElement FindElementByPartialLinkTextOrDefault(string partialLinkText) => AsyncElement.FindElementByPartialLinkTextOrDefault(partialLinkText).GetSyncResult();

        public List<SyncWebElement> FindElementsByPartialLinkText(string partialLinkText) => AsyncElement.FindElementsByPartialLinkText(partialLinkText).GetSyncResult();

        public SyncWebElement FindElementByCssSelector(string cssSelector) => AsyncElement.FindElementByCssSelector(cssSelector).GetSyncResult();

        public SyncWebElement FindElementByCssSelectorOrDefault(string cssSelector) => AsyncElement.FindElementByCssSelectorOrDefault(cssSelector).GetSyncResult();

        public List<SyncWebElement> FindElementsByCssSelector(string cssSelector) => AsyncElement.FindElementsByCssSelector(cssSelector).GetSyncResult();

        public Screenshot GetScreenshot() => AsyncElement.GetScreenshot().GetAwaiter().GetResult();

        protected SyncWebElement FindElement(string mechanism, string value) => AsyncElement.FindElement(mechanism, value).GetSyncResult();

        protected List<SyncWebElement> FindElements(string mechanism, string value) => AsyncElement.FindElements(mechanism, value).GetSyncResult();

        public string UploadFile(string localFile) => AsyncElement.UploadFile(localFile).GetAwaiter().GetResult();

        public Dictionary<string, object> ToElementReference() => AsyncElement.ToElementReference();
    }
}