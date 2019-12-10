using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

namespace NUtility.NHelper
{
    public static class JsonHelper
    {
        public static JsonData FromJson(string json)
        {
            return JsonMapper.ToObject(json);
        }

        public static string ToJson<T>(T[] array)
        {
            return JsonMapper.ToJson(array);
        }
    }
}

