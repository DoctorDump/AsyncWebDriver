﻿// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunicationLib.Communication.MarionetteComands
{
    public class SendKeysToDialogCommand : MarionetteDebuggerCommand
    {
        public SendKeysToDialogCommand(string text, int id = 0, string commandName = "sendKeysToDialog") : base(id, commandName)
        {
            Text = text;
        }
        public string Text { get; set; }

        public override void ProcessResponse(JToken response)
        {
            base.ProcessResponse(response);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(
                new object[]
                {
                   0,
                   Id,
                   CommandName,
                   new {
                        text = Text
                   }

                });

        }

    }
}
