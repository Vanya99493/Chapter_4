using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications
{
    [CreateAssetMenu(fileName = "ApplicationSO", menuName = "App/ApplicationSO")]
    public class ApplicationSO : AppSO
    {
        public ApplicationCategory ApplicationCategory;
    }
}