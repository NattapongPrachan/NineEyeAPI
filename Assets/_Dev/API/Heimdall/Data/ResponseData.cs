using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ResponseData
{
    public object data;
    public List<ErrorMessage> errors;
}

[System.Serializable]
public struct ErrorMessage
{
    public string message;
    public ErrorExtensions extensions;
}

[System.Serializable]
public struct ErrorExtensions
{
    [JsonProperty("error_code")]
    public int errorCode;
    [JsonProperty("error_data")]
    public JObject data;
}

[System.Serializable]
public struct ShopErrorData
{
    [JsonProperty("has_amount")]
    public int hasAmount;
    [JsonProperty("item_id")]
    public string itemId;

    [JsonProperty("need_amount")]
    public int needAmount;
    [JsonProperty("player_id")]
    public string playerId;
}