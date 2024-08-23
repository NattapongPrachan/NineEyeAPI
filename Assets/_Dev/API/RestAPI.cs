using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public enum RequestType{
    GET,POST
}
public class RestAPI : MonoSingleton<RestAPI>
{
    static string token = string.Empty;
    public static void UpdateToken(string _token){
        token = _token;
        Debug.Log("UpdateToken token is "+token);
        PlayerPrefs.SetString("jwt",token);
    }
    public static string GetToken(){
        return token;
    }
    public static void Request<T>(string path,object dataForm,RequestType type,Action<T> OnSuccess = null,Action<string> OnFailed = null){
        var webRequest = CreateWebRequest(path,dataForm,type);
        var ops = webRequest.SendWebRequest();
        ops.completed += (AsyncOperation operation) => {
        Debug.Log("downloadHandler.text " + webRequest.downloadHandler.text);
            if(!string.IsNullOrEmpty(webRequest.downloadHandler.text)){
                 JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                print(webRequest.downloadHandler.text);
                var result = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text,settings);
                    if(result != null){
                        if(OnSuccess != null)OnSuccess(result);
                    }else{
                        var failText = JsonConvert.DeserializeObject<JsonResponseText>(webRequest.downloadHandler.text.ToString(),settings);
                        if(OnFailed != null)
                            OnFailed(failText.responsetext);
                    }
            }
        };
    }

    public static async Task<T> AsyncRequest<T>(string path,object dataForm,RequestType type,Action<T> OnSuccess = null,Action<string> OnFailed = null)
    {
        var webRequest = CreateWebRequest(path,dataForm,type);
        var ops = webRequest.SendWebRequest();
            while(!ops.isDone)
                await Task.Yield();
        var jsonRes = webRequest.downloadHandler.text;
        if(webRequest.result != UnityWebRequest.Result.Success)
            Debug.LogError("Failed "+webRequest.error);

        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        settings.MissingMemberHandling = MissingMemberHandling.Ignore;
        try{
             var result = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text,settings);
            return result;
        }catch(Exception e){
            Debug.LogError($"Cannot prase json to Class {webRequest.downloadHandler.text}.{e.Message}");
            return default;
        }
       
    }

    
    static UnityWebRequest CreateWebRequest(string path,object dataForm,RequestType type)
    {
        var downloadHandler = new DownloadHandlerBuffer();
        var webRequest = new UnityWebRequest(path,type.ToString());
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Authorization","Bearer "+token);
        webRequest.SetRequestHeader("platform", "Android");
        webRequest.SetRequestHeader("appversion", Application.version);
        webRequest.downloadHandler = downloadHandler;
        if(dataForm != null)
            webRequest.uploadHandler = CreateUploadHandler(dataForm);
        return webRequest;
    }
    private static UploadHandler CreateUploadHandler(object dataForm)
    {
            var data = JsonUtility.ToJson(dataForm);
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(data.ToCharArray());
            return new UploadHandlerRaw(postData);
    }

    
}