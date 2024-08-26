using Grandora.Heimdall;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AuthSignupData : NetworkData
{
    public override string UserId => "";
}
[System.Serializable]
public struct SignupData
{
    public string name;
    public string email;
    public string password;

}
[System.Serializable]
public class SignpResponse
{
    public GameUser user;
    public string token;
}
[System.Serializable]
public class GameUser
{
    //[JsonProperty("id")]
    public string id;
    public string name;
    public string email;
    public string userType;
    public string lls;
    public string token;
}