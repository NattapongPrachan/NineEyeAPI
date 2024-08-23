using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Grandora.Heimdall;
using UnityEngine;
namespace Grandora.Heimdall
{
    public class NetworkDataListHolder<T> : NetworkStructureListHolder<T> where T : NetworkData
    {
        protected override Dictionary<string, T> CreateDictFromList()
        {
            var index = 0;
            return elementList?.ToDictionary(keySelector: t => string.IsNullOrEmpty(t.UserId) ? "" + (index++) : t.UserId, elementSelector: t => t);
        }

        protected override object CreateGetRequestJSON()
        {
            return null;
        }
    }
}
