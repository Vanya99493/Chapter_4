using System;
using _7_PlayMarketSample.Scripts.Infrastructure.Services;
using _7_PlayMarketSample.Scripts.UIModule.Panels.BasePagePanelModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.SortedConfigs;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.BodyPagePanelModule.BooksPagePanelModule
{
    public class BooksTopChartsPagePanel : BaseTopChartsPagePanel
    {
        [SerializeField] private BookSortedConfigSO _sortedConfig;
        
        public override void Initialize(ApplicationListSO applicationListSO, Action<AppSO> OnAppItemButtonClick)
        {
            var sortedList = _sortedConfig.GetSortedBooksList(applicationListSO);
            foreach (var appSO in sortedList)
            {
                ItemPanel item = Instantiate(PrefabsProvider.Instance.ItemPanelPrefab, _parentTransform);
                item.Initialize(appSO, OnAppItemButtonClick);
            }
        }
    }
}