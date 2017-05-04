﻿//*********************************************************//
//    Copyright (c) Microsoft. All rights reserved.
//    
//    Apache 2.0 License
//    
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    
//    Unless required by applicable law or agreed to in writing, software 
//    distributed under the License is distributed on an "AS IS" BASIS, 
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or 
//    implied. See the License for the specific language governing 
//    permissions and limitations under the License.
//
//*********************************************************//

using System;
using System.Threading;
using System.Threading.Tasks;
using Zu.WebBrowser.Commands;

namespace Zu.WebBrowser.Communication {
    public interface IDebuggerClient {
        /// <summary>
        /// Send a command to debugger.
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task SendRequestAsync(DebuggerCommand command, CancellationToken cancellationToken = new CancellationToken());

    }
}