using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
public struct PlayerAPI
{
    public static string ReadAll => "13.215.214.34:8080/player-services/player/readall";
    public static string FacebookAuthen => "http://192.168.120.114:8080/player-services/fb-auth";
    public static string GetPlayerProfile => "http://192.168.120.114:8080/player-services/player/read-profile";
    public static string EmailAuthen => "13.215.214.34:8080/player-services/email-auth";
}

public struct CharacterAPI
{
    public static string Create => "http://192.168.120.114:8000/character/create";
    public static string GetDataById => "http://192.168.120.114:8000/character/read/";
    public static string GetPlayerEquipment => "http://192.168.120.114:8080/player-services/character/read-player-equipment/";
}


