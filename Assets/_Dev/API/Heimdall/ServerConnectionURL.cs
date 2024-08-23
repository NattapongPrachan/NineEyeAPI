using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grandora.ServerConnect
{
    [Serializable]
    public class ServerConnectionURL
    {
        public string publicURL;
        public string internalURL;
        public ServerConnected serverConnected;

        public string GetURL()
        {
            string url = publicURL;
            if (Application.isBatchMode)
            {
                url = internalURL;
                Debug.Log("Linux Platform");

            }
            else
            {
                url = publicURL;
            }

            //if (NetworkManager.singleton != null)
            //{
            //    if (NetworkManager.singleton.mode == NetworkManagerMode.ServerOnly)
            //    {
            //        url = internalURL;
            //    }
            //}

            return url;
        }
    }


    public enum ServerConnected
    {
        PRODUCTION = 0,
        DEVELOPER = 1
    }
}