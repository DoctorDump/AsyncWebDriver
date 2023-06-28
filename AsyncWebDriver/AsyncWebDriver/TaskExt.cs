// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Zu.AsyncWebDriver.Remote
{
    public static class TaskExt
    {
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, int timeout)
        {
            //var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout /*, timeoutCancellationTokenSource.Token*/)).ConfigureAwait(false);
            if (completedTask == task)
            {
                //timeoutCancellationTokenSource.Cancel();
                return await task.ConfigureAwait(false);
            }

            // Since we timed out and would not wait for possible exception, we should ignore it or UnobservedTaskException could happen.
            IgnoreExceptions(task);

            throw new TimeoutException("The operation has timed out.");
        }

        private static void IgnoreExceptions(Task task)
        {
            task.ContinueWith(t => Trace.TraceWarning($"{t.Exception} was ignored"), TaskContinuationOptions.OnlyOnFaulted);
        }

        public static async Task TimeoutAfter(this Task task, int timeout)
        {
            //var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout /*, timeoutCancellationTokenSource.Token*/)).ConfigureAwait(false);
            if (completedTask == task)
            {
                await task.ConfigureAwait(false);
                return;
            }

            // Since we timed out and would not wait for possible exception, we should ignore it or UnobservedTaskException could happen.
            IgnoreExceptions(task);

            throw new TimeoutException("The operation has timed out.");
        }
    //todo. It not working
    //public static TResult DoSync<TResult>(this Task<TResult> task)
    //{
    //    var res = default(TResult);
    //    var mRes = new ManualResetEventSlim(true);
    //    mRes.Reset();
    //    Task.Run(async () =>
    //        {
    //            res = await task;
    //            mRes.Set();
    //        }
    //    );
    //    mRes.Wait();
    //    return res;
    //}
    //todo. It not working
    //public static void DoSync(this Task task)
    //{
    //    var mRes = new ManualResetEventSlim(true);
    //    mRes.Reset();
    //    Task.Run(async () =>
    //        {
    //            await task;
    //            mRes.Set();
    //        }
    //    );
    //    mRes.Wait();
    //}
    }
}