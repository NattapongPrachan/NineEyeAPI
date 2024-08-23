using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grandora.Heimdall
{
    public class ClientEndpointRequest : ClientRequest
    {
        public string endpoint;
        public override string Destination => endpoint;
        public ClientEndpointRequest(string endpoint,
                                    HTTPVerb verb,
                                    ParameterType parameterType,
                                    bool isShowLoading = false,
                                    bool useThisEndpointOnly = false,
                                    ServerDebugMode debugMode = default,
                                    ExtensionServices extensions = default,
                                    object jsonPostData = null,
                                    Action<ServerRequestResult> onServerReturnSuccess = null,
                                    Action<ServerRequestResult> onServerReturnFail = null,
                                    Action<ServerRequestResult> onConnectionFail = null)
                                    : base(verb, parameterType, isShowLoading, useThisEndpointOnly, debugMode, extensions, jsonPostData, onServerReturnSuccess, onServerReturnFail, onConnectionFail)
        {
            this.endpoint = endpoint;
        }
        public ClientEndpointRequest(
                                    ClientEndpointTemplate template,
                                    object jsonPostData = null,
                                    Action<ServerRequestResult> onServerReturnSuccess = null,
                                    Action<ServerRequestResult> onServerReturnFail = null,
                                    Action<ServerRequestResult> onConnectionFail = null)
                                    : base(template.verb, template.parameterType, template.isShowLoading, template.useThisEndpointOnly, template.debugMode, template.extensionServices, jsonPostData, onServerReturnSuccess, onServerReturnFail, onConnectionFail)
        {
            this.endpoint = template.endpoint;
        }
    }
}
