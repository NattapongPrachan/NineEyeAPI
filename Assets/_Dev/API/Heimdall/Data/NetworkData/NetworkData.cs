using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Grandora.Heimdall
    {
    public abstract class NetworkData
    {
        string configId;
        public abstract string UserId{get;}
    }
}
