using System;
using _7_PlayMarketSample.Scripts.UIModule.Data;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base
{
    public class AppSO : ScriptableObject, IComparable<AppSO>
    {
        [Range(0, 10)] public int Rate;
        public ApplicationInfo AppInfo;

        public int CompareTo(AppSO other)
        {
            return other.Rate.CompareTo(Rate);
        }
    }
}