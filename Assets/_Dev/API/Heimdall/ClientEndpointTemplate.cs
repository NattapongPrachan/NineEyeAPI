using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grandora.Heimdall
{
    [System.Serializable]
    public class ClientEndpointTemplate 
    {
        public string endpoint;
        public HTTPVerb verb;
        public ParameterType parameterType;
        public bool isShowLoading = false;
        public bool useThisEndpointOnly = false;
        public ServerDebugMode debugMode;
        public ExtensionServices extensionServices;
        public ClientEndpointTemplate(string endpoint,HTTPVerb verb,ParameterType parameterType, bool isShowLoading,ServerDebugMode debugMode = default, ExtensionServices extensions = default)
        {
            this.endpoint = endpoint;
            this.verb = verb;
            this.parameterType = parameterType;
            this.isShowLoading = isShowLoading;
            this.debugMode = debugMode;
            this.extensionServices = extensions;
        }
        public ClientEndpointTemplate(ClientEndpointTemplate templateCopy)
        {
            this.endpoint = templateCopy.endpoint;
            this.verb = templateCopy.verb;
            this.parameterType = templateCopy.parameterType;
            this.isShowLoading = templateCopy.isShowLoading;
            this.debugMode = templateCopy.debugMode;
            this.extensionServices = templateCopy.extensionServices;
        }
    }
}
