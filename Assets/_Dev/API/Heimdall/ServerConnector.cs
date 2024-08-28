using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Grandora.ServerConnect;
using Newtonsoft.Json;

namespace Grandora.Heimdall
{
    public class ServerConnector : MonoSingleton<ServerConnector>
    {
        [Header("Settings")]
        [SerializeField] ServerConnectorConfig config;
        public ServerConnectorConfig Config => config;
        string AccessTokenFieldname => config.accessTokenFieldName;
        string AccessTokenPrefix => config.accessTokenPrefix;
        string URL => config.URL;
        int TimeoutInSeconds => config.timeoutInSeconds;
        string accessToken;
        public TokenData tokenData;
        public void SetAccessToken(string value) => accessToken = value;
        public Action onShowLoading;
        public Action onHideLoading;
        public Action onAnyConnectionStart;
        Action<ServerRequestResult> onAnyConnectionFinish;

        protected override void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Request(ClientRequest clientRequest)
        {
            StartCoroutine(RequestAndReceiveRoutine(clientRequest));
        }
        IEnumerator RequestAndReceiveRoutine(ClientRequest clientRequest)
        {
            Debug.Log("RequestAndReceiveRoutine ");
            var unityWebRequest = CreateAndStartUnityWebRequest();
            yield return WaitForResponse();
            ReceiveServerResponse();
            UnityWebRequest CreateAndStartUnityWebRequest()
            {
                var webRequest = CreateUnityWebRequest(clientRequest);
                LogStartWebRequest(clientRequest, webRequest);
                if (clientRequest.isShowLoading)
                    ShowLoading();
                NotifyConnectionStart();
                return webRequest;
            }
            IEnumerator WaitForResponse()
            {
                yield return unityWebRequest.SendWebRequest();
            }
            void ReceiveServerResponse()
            {
                print("receiveServerRespone");
                var serverRequestResult = new ServerRequestResult(unityWebRequest);
                var endpointText = GetEndpointLogText(clientRequest);
                var resultJsonString = serverRequestResult.fullJson == null
                    ? "null"
                    : serverRequestResult.fullJson.ToString();
                if (config.isShowingLog)
                {
                    Debug.Log($"{endpointText} : Code {serverRequestResult.code} \n {resultJsonString}");
                }
                if (serverRequestResult.status == ServerRequestResult.Status.ServerReturnSuccess)
                {
                    clientRequest.onServerReturnSuccess?.Invoke(serverRequestResult);
                }
                else if (serverRequestResult.status == ServerRequestResult.Status.ServerReturnFail)
                {
                    clientRequest.onServerReturnFail?.Invoke(serverRequestResult);
                }
                else if (serverRequestResult.status == ServerRequestResult.Status.ConnectionFail)
                {
                    clientRequest.onConnectionFail?.Invoke(serverRequestResult);
                    return;
                }
                NotifyConnectionFinish(serverRequestResult);
                if (clientRequest.isShowLoading)
                    HideLoading();
            }
        }
        UnityWebRequest CreateUnityWebRequest(ClientRequest clientRequest)
        {
            
            var fullURL = GetFullURL(clientRequest);
            var result = new UnityWebRequest(fullURL, clientRequest.verb.ToString());
            InjectJsonIntoUnityWebRequest(clientRequest, result);
            InjectAccessTokenAndAdditionalRequestHeaders(result);
            result.downloadHandler = new DownloadHandlerBuffer();
            result.timeout = TimeoutInSeconds;
            return result;
        }
        string GetFullURL(ClientRequest clientRequest)
        {
            var fullURL = clientRequest.Destination;

            if (clientRequest is ClientEndpointRequest tryGetEndpointRequest)
            {
                if (!tryGetEndpointRequest.useThisEndpointOnly)
                    fullURL = GetBaseURL(clientRequest) + tryGetEndpointRequest.endpoint;
            }
            return fullURL;
        }
        #region add dataform
        void InjectJsonIntoUnityWebRequest(ClientRequest clientRequest, UnityWebRequest unityWebRequest)
        {
            var json = JsonConvert.SerializeObject(clientRequest.jsonPostData);
            Debug.Log("Json postJsonData" + clientRequest.jsonPostData);
            if (json == null)
                return;

            var rawData = CreateUnityWebRequestRawData(clientRequest, json, unityWebRequest);
            print("rawData " + rawData);
            if (rawData == null)
                return;

            unityWebRequest.uploadHandler = new UploadHandlerRaw(rawData);
        }
        byte[] CreateUnityWebRequestRawData
        (
            ClientRequest clientRequest,
            object json,
            UnityWebRequest request
        )
        {
            return CreateRawDataBaseOnParameterType(clientRequest, json, request);
        }
        private static UploadHandler CreateUploadHandler(object dataForm)
        {
            var data = JsonUtility.ToJson(dataForm);
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(data.ToCharArray());
            return new UploadHandlerRaw(postData);
        }
        byte[] CreateRawDataBaseOnParameterType
        (
            ClientRequest clientRequest,
            object json,
            UnityWebRequest request
        )
        {
            byte[] rawData = null;
            switch (clientRequest.parameterType)
            {
                case ParameterType.Query:
                    //AssignQueryTypeURL(json, request);
                    break;
                case ParameterType.Body:
                    rawData = CreateBodyTypeRequestRawData(json, request);
                    break;
                case ParameterType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return rawData;
        }
        static byte[] CreateBodyTypeRequestRawData(object json, UnityWebRequest request)
        {
            Debug.Log("json " + json);
            var rawData = Encoding.UTF8.GetBytes(json.ToString());
            Debug.Log("rawdata " + rawData);
            return rawData;
        }
        #endregion
        #region add AccessToken
        public void SetTokenData(TokenData tokenData)
        {
            this.tokenData = tokenData;
            SetAccessToken(tokenData.AccessToken);
        }
        void InjectAccessTokenAndAdditionalRequestHeaders(UnityWebRequest request)
        {
            InjectAccessTokenHeader(request);
            InjectAdditionalRequestHeaders(request);
        }

        void InjectAccessTokenHeader(UnityWebRequest request)
        {
            bool IsShouldUseEditorAccessToken()
            {
                return Application.isEditor && config.isUseEditorAccessToken;
            }
            var accessTokenToInject = IsShouldUseEditorAccessToken() ? config.editorAccessToken : accessToken;
            request.SetRequestHeader(AccessTokenFieldname, accessTokenToInject);
            print("requestHeader " + AccessTokenFieldname);
            print("AccessTokenPrefix " + AccessTokenPrefix);
            print("AccessToken Toinject " + accessTokenToInject);
        }
        void InjectAdditionalRequestHeaders(UnityWebRequest request)
        {
            foreach (var requestHeader in config.additionalRequestHeaders)
            {
                request.SetRequestHeader(requestHeader.key, requestHeader.value);
            }
        }
        static string GetNullSafeString(string accessTokenToInject)
        {
            return string.IsNullOrEmpty(accessTokenToInject) ? string.Empty : accessTokenToInject;
        }
        #endregion
        #region add URL

        public string GetBaseURL()
        {
            ServerConnectionURL connection = config.serverConnectionURL.FirstOrDefault(url => url.serverConnected == config.targetServer);
            //Depug.LogColor(connection.IsNull().ToString(),Color.red);
            string baseUrl = connection.GetURL();
            return baseUrl;
        }

        public string GetBaseURL(ClientRequest clientRequest)
        {
            string baseUrl = string.Empty;
            if(clientRequest.extensions == ExtensionServices.Default)
            {
                ServerConnectionURL connection = config.serverConnectionURL.FirstOrDefault(url => url.serverConnected == config.targetServer);
                Debug.Log("connectrion " + connection);
                baseUrl = connection.GetURL();
            }
            else
            {
                ExtensionServicesURL extensionConnection = config.extensionServerConnectionURL
                    .FirstOrDefault(extent => extent.extensionServices == clientRequest.extensions);

                ServerConnectionURL connection = extensionConnection.serverURL.FirstOrDefault(url => url.serverConnected == config.targetServer);
                baseUrl = connection.GetURL();

            }
                   

            return baseUrl;
        }
        public void SetTargetServer(ServerConnected server)
        {
            config.targetServer = server;
        }
        #endregion
        #region Log
        private void LogStartWebRequest(ClientRequest clientRequest, UnityWebRequest webRequest)
        {
            var startWebRequestLog = GetStartRequestLogText(clientRequest, webRequest);
            if (config.isShowingLog)
                Debug.Log(startWebRequestLog);
        }

        private object GetStartRequestLogText(ClientRequest clientRequest, UnityWebRequest webRequest)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(GetEndpointLogText(clientRequest));
            stringBuilder.Append("Start Request : \n");
            if (clientRequest.jsonPostData != null)
                stringBuilder.Append(clientRequest.jsonPostData.ToString());
            stringBuilder.Append("\n\n >> ");
            stringBuilder.Append(webRequest.url);
            stringBuilder.Append("\n");
            stringBuilder.Append("\n");
            stringBuilder.Append(webRequest.downloadHandler.text);
            return stringBuilder.ToString();
        }

        string GetEndpointLogText(ClientRequest clientRequest)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("ENDPOINT : ");
            stringBuilder.Append(clientRequest.verb.ToString());
            stringBuilder.Append(" ");
            stringBuilder.Append(clientRequest.Destination);
            stringBuilder.Append(" => ");
            return stringBuilder.ToString();
        }

        void ShowLoading()
        {
            onShowLoading?.Invoke();
        }
        void HideLoading()
        {
            onHideLoading?.Invoke();
        }
        void NotifyConnectionStart()
        {
            onAnyConnectionStart?.Invoke();
        }
        void NotifyConnectionFinish(ServerRequestResult result)
        {
            onAnyConnectionFinish?.Invoke(result);
        }
        #endregion
    }
}
