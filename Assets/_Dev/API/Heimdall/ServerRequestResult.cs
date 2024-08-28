using Grandora.ServerConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Grandora.Heimdall
{
     public class ServerRequestResult 
    {
        static string CurrentDateTimeFieldName => ServerConnector.Instance.Config.currentDateTimeFieldName;
        static string StatusFieldName => ServerConnector.Instance.Config.statusCodeFieldName;
        static string MessageFieldName => ServerConnector.Instance.Config.messageFieldName;
        static string DataFieldName => ServerConnector.Instance.Config.dataFieldName;
        static string TokenFiledName => ServerConnector.Instance.Config.tokenFieldName;
        public int code;
        public object fullJson;
        public object dataJson;
        public JObject jsonObject;
        public string message;
        public string currentDateTime;
        public enum Status
        {
            ServerReturnSuccess,ServerReturnFail,ConnectionFail
        }
        public Status status;
        
        public ServerRequestResult(){}
        public ServerRequestResult(UnityWebRequest unityWebRequest)
        {
            code = (int)unityWebRequest.responseCode;
            SetStatus(code);
            TryInitResultJson(unityWebRequest);
        }

        private void TryInitResultJson(UnityWebRequest request)
        {
            Debug.Log("---------ServerRequestResult---------");
            if(request == null)
                Debug.LogError("request is null");
            if(request.downloadHandler == null)
                Debug.LogError("request.downloadHandler is null");
            if(request.downloadHandler.text == null)
                Debug.LogError("request.downloadHander.text is null");
           ///HardCode If Backend not send Object format to me
            Debug.Log("raw text "+request.downloadHandler.text);
            // var justMockObject = new JustMockObject{
            //     statusCode = "200",
            //     message = "aaaa",
            //     data = request.downloadHandler.text
            // };
            ///---------------///
            if (status == Status.ServerReturnSuccess)
            {
                var deserializeString = request.downloadHandler.text;
                fullJson = JsonConvert.SerializeObject(deserializeString, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                jsonObject = JObject.Parse(deserializeString);
                //#region try to get Token
                //    var tokenJson = GetStringValue(jsonObject,TokenFiledName);
                //    if(!string.IsNullOrEmpty(tokenJson))
                //    {
                //        var token = JsonConvert.DeserializeObject<TokenData>(tokenJson);
                //        ServerConnector.Instance.SetTokenData(token);
                //       // GraphConnector.Instance.SetTokenData(token);
                //    }
                //#endregion
                message = request.error;
                var messageFormResponse = GetStringValue(jsonObject,MessageFieldName);
                if(!string.IsNullOrEmpty(messageFormResponse))
                {
                    message = messageFormResponse;
                }
                dataJson = GetDataJsonString(jsonObject);
            }
        }
        void SetStatus(Status value)
        {
            status = value;
        }
        void SetStatus(int code)
        {
            var isSuccessCode = ServerStatusCodeRange.IsBetweenRange(code,ServerConnector.Instance.Config.successStatusCodeRange);
            var isServerFailCode = ServerStatusCodeRange.IsBetweenRange(code, ServerConnector.Instance.Config.serverFailStatusCodeRange);
            var isConnectionFailCode = ServerStatusCodeRange.IsBetweenRange(code, ServerConnector.Instance.Config.connectionFailStatusCodeRange);
            if(isSuccessCode)
                SetStatus(Status.ServerReturnSuccess);
            else if(isServerFailCode)
                SetStatus(Status.ServerReturnFail);
            else
                SetStatus(Status.ConnectionFail);
        }
        string GetDataJsonString(JObject json)
        {
            JToken jToken;
            if(json.TryGetValue(DataFieldName,System.StringComparison.CurrentCulture,out jToken))
            {
                return jToken.ToString();
            }
            return string.Empty;
        }
        public ResponseData GetResponseData()
        {
            return JsonConvert.DeserializeObject<ResponseData>((string)fullJson);
        }
        public bool IsSuccess()
        {
            return (bool)jsonObject.GetValue("success");
        }
        string GetStringValue(JObject jObject ,string key)
        {
            JToken jToken;
            if (jObject.TryGetValue(key, System.StringComparison.CurrentCulture, out jToken))
            {
                return jToken.ToString();
            }
            return string.Empty;
        }
    }
}
