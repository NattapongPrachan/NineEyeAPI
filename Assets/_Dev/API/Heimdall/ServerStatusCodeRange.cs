using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Grandora.ServerConnect
{
    [Serializable]
    public class ServerStatusCodeRange
    {
        public int start;
        public int end;
        public bool IsBetweenRange(int value)
        {
            return start <= value && value <= end;
        }
        public static bool IsBetweenRange(int value , params ServerStatusCodeRange[] ranges)
        {
            return ranges.Any(ranges => ranges.IsBetweenRange(value));
        }
    }
}
