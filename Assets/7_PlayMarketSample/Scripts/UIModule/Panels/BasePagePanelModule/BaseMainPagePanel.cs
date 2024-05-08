using System;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.BasePagePanelModule
{
    public abstract class BaseMainPagePanel : MonoBehaviour
    {
        [SerializeField] protected Transform _contentContainer;

        public abstract void Initialize(ApplicationListSO applicationListSO, Action<AppSO> OnAppItemButtonClick);
    }
}