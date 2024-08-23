using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grandora.Heimdall
{
    public enum HTTPVerb
    {
        GET, HEAD, POST, PUT, CREATE, PATCH, DELETE
    }
    public enum ParameterType
    {
        None, Query, Body
    }

    [Serializable]
    public enum ExtensionServices
    {
        Default,
        Chat
    }
    public abstract class ClientRequest
    {
        public abstract string Destination { get; }
        public HTTPVerb verb;
        public ParameterType parameterType;
        public bool isShowLoading = false;
        public bool useThisEndpointOnly = false;
        public object uploadData;
        public ServerDebugMode debugMode;
        public ExtensionServices extensions;
        public object jsonPostData = null;
        public Action<ServerRequestResult> onServerReturnSuccess = null;
        public Action<ServerRequestResult> onServerReturnFail = null;
        public Action<ServerRequestResult> onConnectionFail = null;
        public ClientRequest
        (
            HTTPVerb verb,
            ParameterType parameterType,
            bool isShowLoading = false,
            bool useThisEndpointOnly = false,
            ServerDebugMode debugMode = default,
            ExtensionServices extensions = default,
            object jsonPostData = null,
            Action<ServerRequestResult> onServerReturnSuccess = null,
            Action<ServerRequestResult> onServerReturnFail = null,
            Action<ServerRequestResult> onConnectionFail = null
        )
        {
            this.verb = verb;
            this.parameterType = parameterType;
            this.isShowLoading = isShowLoading;
            this.useThisEndpointOnly = useThisEndpointOnly;
            this.debugMode = debugMode;
            this.extensions = extensions;
            this.jsonPostData = jsonPostData;
            this.onServerReturnSuccess = onServerReturnSuccess;
            this.onServerReturnFail = onServerReturnFail;
            this.onConnectionFail = onConnectionFail;
        }
    }
}
