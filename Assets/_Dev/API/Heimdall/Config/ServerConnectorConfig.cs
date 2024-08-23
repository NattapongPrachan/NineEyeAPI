using Grandora.ServerConnect;
using UnityEngine;
namespace Grandora.Heimdall
{
    [CreateAssetMenu(fileName = "ServerConnectorConfig", menuName = "Grandora/ServerConnectorConfig", order = 0)]
    public class ServerConnectorConfig : ScriptableObject {
        public bool isSelect = true;
        [Header("Editor Only")]
        public bool isShowingLog = true;
        public bool isUseEditorAccessToken = true;
        public string editorAccessToken;
        [Header("Server Debug Mode")]
        public bool isForceUseServerDebugModeFormThisConfig;
        public ServerDebugMode serverDebugMode;
        [Header("Connection")]
        public string URL;
        public ServerConnected targetServer;
        public ServerConnectionURL[] serverConnectionURL;
        [Header("Extension Services")]
        public ExtensionServicesURL[] extensionServerConnectionURL;
        public int timeoutInSeconds = 10;
        public float delayBetweenEachChainedREquestInSeconds = 1f;
        [Header("Client Request")]
        public string accessTokenFieldName = "accessToken";
        public string accessTokenPrefix = "bearer";
        public RequestheaderSetting[] additionalRequestHeaders;
        [Header("Server Request Result")]
        public ServerStatusCodeRange[] successStatusCodeRange;
        public ServerStatusCodeRange[] serverFailStatusCodeRange;
        public ServerStatusCodeRange[] connectionFailStatusCodeRange;
        public string messageFieldName = "message";
        public string dataFieldName = "data";
        public string statusCodeFieldName = "statusCode";
        public string currentDateTimeFieldName = "currentDateTime";
        public string tokenFieldName = "token";
        public string errorFieldName = "errors";
    }
    [System.Serializable]
    public class RequestheaderSetting
    {
        public string key;
        public string value;
    }
    public enum ServerDebugMode
    {
        Off,MockServerreturnSuccess,MockServerReturnFail,MockConnectionFailed
    }
}