using System;
using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.Infrastructure.Services;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using TMPro;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Transform _parentTransform;
        
        public void Initialize(List<AppSO> items, string description, Action<AppSO> OnAppItemButtonClick)
        {
            _descriptionText.text = description;
            
            foreach (var item in items)
            {
                ItemShortcut itemShortcut = Instantiate(PrefabsProvider.Instance.ItemShortcutPrefab, _parentTransform);
                itemShortcut.Initialize(item, OnAppItemButtonClick);
            }
        }
    }
}