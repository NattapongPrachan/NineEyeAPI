using System;
using System.Collections;
using System.Collections.Generic;
using Grandora.Heimdall;
using Newtonsoft.Json.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using Newtonsoft.Json;

namespace Grandora.Heimdall
{
    public abstract class NetworkStructureListHolder<T> : SerializedMonoBehaviour where T : NetworkData
    {
        public static Subject<T> OnElementUpdate = new Subject<T>();
        public Action<T> OnDataUpdate;
        [SerializeField]protected List<T> elementList;
        public List<T> ElementList => elementList;
        public T Data
        {
            get
            {
                if(elementList == null || elementList.Count == 0)return null;
                return elementList[0];
            }
        }
        public Dictionary<string,T> Dictionary{get;private set;}
        public void SetDictionary(Dictionary<string,T> dict) => Dictionary = dict;
        [SerializeField]protected ClientEndpointTemplate getRequestTemplate;
        public ClientEndpointTemplate GetRequestTemplate => getRequestTemplate;
        protected abstract Dictionary<string, T> CreateDictFromList();
        protected abstract object CreateGetRequestJSON();
        protected virtual void HandleOnGetSuccess(){}

        [Title("For testing")]
        [Button]
        public void RequestGetFormServer() => RequestGetFromServer(null);
        public void RequestGetFromServer(Action<Dictionary<string, T>> onServerReturnSuccess,
            Action<ServerRequestResult> onServerReturnFail = null, Action<ServerRequestResult> onConnectionFail = null)
        {
            var clientRequest = CreateGetRequest(onServerReturnSuccess, onServerReturnFail, onConnectionFail);
            ServerConnector.Instance.Request(clientRequest);
        }
        public ClientEndpointRequest CreateGetRequest(Action<Dictionary<string, T>> onServerReturnSuccess = null,
            Action<ServerRequestResult> onServerReturnFail = null, Action<ServerRequestResult> onConnectionFail = null)
        {
            return CreateRequest
            (
                getRequestTemplate,
                CreateGetRequestJSON(), //upload data
                result =>
                {
                    RefreshAndExecuteAction(onServerReturnSuccess, result.dataJson);
                    HandleOnGetSuccess();
                }
                ,
                onServerReturnFail,
                onConnectionFail
            );
        }
        public ClientEndpointRequest CreateRequest(ClientEndpointTemplate template, object json,
            Action<ServerRequestResult> onServerReturnSuccess = null, 
            Action<ServerRequestResult> onServerReturnFail = null,
            Action<ServerRequestResult> onConnectionFail = null)
        {
            return new ClientEndpointRequest
            (
                template,
                json,
                HandleOnServerReturnSuccess,
                HandleOnServerReturnFail,
                HandleOnConnectionFail
            );

            void HandleOnServerReturnSuccess(ServerRequestResult result)
            {
                onServerReturnSuccess?.Invoke(result);
            }

            void HandleOnServerReturnFail(ServerRequestResult result)
            {
                onServerReturnFail?.Invoke(result);
            }
            

            void HandleOnConnectionFail(ServerRequestResult result)
            {
                onConnectionFail?.Invoke(result);
            }
        }
        
        protected Dictionary<string, T> GetDictFromJSON(object json)
        {
            elementList = GetListFromJSON(json);
            return CreateDictFromList();
        }
        protected List<T> GetListFromJSON(object json)
        {
            var token = JToken.Parse(json.ToString());
            JArray jArray = new JArray();
            if(token is JArray)
            {
                jArray = (JArray)token;
            }else if(token is JObject)
            {
                jArray = new JArray();
                jArray.Add(token);
            }
            var resultList = new List<T>();
            foreach (var jsonObject in jArray)
                CreateNewElementAndAddToList(jsonObject);

            return resultList;
            void CreateNewElementAndAddToList(JToken json)
            {
                print("json "+json);
                print("T "+typeof(T));
                var newElement = json.ToObject<T>();
                resultList.Add(newElement);
            }
        }
        protected void RefreshAndExecuteAction(Action<Dictionary<string, T>> onServerReturnSuccess, object json)
        {
            RefreshByJSON(json);
            onServerReturnSuccess?.Invoke(Dictionary);
        }

        public void RefreshByJSON(object json)
        {
            var dict = GetDictFromJSON(json);
            OnDataUpdate?.Invoke(Data);
            SetDictionary(dict);
        }
        public void RefreshDictByList()
        {
            SetDictionary(CreateDictFromList());
        }

        protected virtual void Awake()
        {
            SetDictionary(CreateDictFromList());
        }
    }
}
