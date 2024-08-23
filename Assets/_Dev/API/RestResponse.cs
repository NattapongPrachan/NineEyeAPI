using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestResponse : MonoBehaviour
{
    //data response
}
[System.Serializable]
public class JsonResponse{
    public bool success;
    public object data;
    public string name;
}
public class JsonResponseText{
    public string responsetext;
}
