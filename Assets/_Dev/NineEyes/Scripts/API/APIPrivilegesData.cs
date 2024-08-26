using Grandora.Heimdall;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIPrivilegesData : NetworkDataListHolder<PrivilegeAllData>
{
    public ClientEndpointTemplate PrivilegesAllEndpoint;
    [Button]
    public void PrivilegeAll()
    {
        var request = CreateRequest(PrivilegesAllEndpoint, null, ResultSuccess =>
        {
            RefreshByJSON(ResultSuccess.jsonObject);
        });
        ServerConnector.Instance.Request(request);
    }
}
