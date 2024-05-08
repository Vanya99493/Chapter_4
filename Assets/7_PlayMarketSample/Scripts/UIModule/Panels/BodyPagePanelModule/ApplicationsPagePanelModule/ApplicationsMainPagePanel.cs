using System;
using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.Infrastructure.Services;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BasePagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.SortedConfigs;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.BodyPagePanelModule.ApplicationsPagePanelModule
{
    public class ApplicationsMainPagePanel : BaseMainPagePanel
    {
        [SerializeField] protected ApplicationSortedConfigSO[] _applicationsSortedConfigs;

        public override void Initialize(ApplicationListSO applicationListSO, Action<AppSO> OnAppItemButtonClick)
        {
            for (int i = 0; i < _applicationsSortedConfigs.Length; i++)
            {
                ItemContainer container = Instantiate(PrefabsProvider.Instance.ItemContainerPrefab, _contentContainer);
                List<AppSO> applications = _applicationsSortedConfigs[i].GetSortedApplicationsList(applicationListSO);
                container.Initialize(applications, _applicationsSortedConfigs[i].Description, OnAppItemButtonClick);
            }
        }
    }
}