using Grandora.Heimdall;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIPromotionAllData : NetworkDataListHolder<PromotionAllData>
{
    public ClientEndpointTemplate PromotionAllEndpoint;
    
    [Button]
    public void PromotionAll()
    {
        var request = CreateRequest(PromotionAllEndpoint, null, ResultSuccess =>
        {
            RefreshByJSON(ResultSuccess.jsonObject);
        });
        ServerConnector.Instance.Request(request);
    }
}
