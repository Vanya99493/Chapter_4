using _7_PlayMarketSample.Scripts.Infrastructure.Services;
using _7_PlayMarketSample.Scripts.UIModule;
using _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.Infrastructure
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [Header("Apps lists")]
        [SerializeField] private ApplicationListSO _gamesList;
        [SerializeField] private ApplicationListSO _applicationsList;
        [SerializeField] private ApplicationListSO _booksList;
        [Header("Prefabs")] 
        [SerializeField] private ItemContainer _itemContainerPrefab;
        [SerializeField] private ItemShortcut _itemShortcutPrefab;
        [SerializeField] private ItemPanel _itemPanelPrefab;

        private void Start()
        {
            InitializePrefabsProvider();
            _uiController.Initialize(_gamesList, _applicationsList, _booksList);
        }

        private void InitializePrefabsProvider()
        {
            PrefabsProvider.Instance.ItemContainerPrefab = _itemContainerPrefab;
            PrefabsProvider.Instance.ItemShortcutPrefab = _itemShortcutPrefab;
            PrefabsProvider.Instance.ItemPanelPrefab = _itemPanelPrefab;
        }
    }
}