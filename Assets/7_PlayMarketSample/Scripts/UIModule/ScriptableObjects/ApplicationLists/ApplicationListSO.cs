using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists
{
    [CreateAssetMenu(fileName = "ApplicationListSO", menuName = "AppList/ApplicationListSO")]
    public class ApplicationListSO : ScriptableObject
    {
        public ApplicationType ApplicationType;
        public List<AppSO> Applications;
    }
}