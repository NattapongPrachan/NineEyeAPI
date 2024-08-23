using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct TokenData 
{
    [JsonProperty("access")]
    public string AccessToken;
    [JsonProperty("refresh")]
    public string RefreshToken;
}
