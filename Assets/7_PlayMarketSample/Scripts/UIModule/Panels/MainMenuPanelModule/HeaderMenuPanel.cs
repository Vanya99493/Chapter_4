using System;
using UnityEngine;
using UnityEngine.UI;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.MainMenuPanelModule
{
    public class HeaderMenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _mainPageButton;
        [SerializeField] private Button _topChartsButton;

        public void SubscribeOnButtonsClick(Action OnMainPageButtonClick, Action OnTopChartsButtonClick)
        {
            _mainPageButton.onClick.AddListener(() => OnMainPageButtonClick?.Invoke());
            _topChartsButton.onClick.AddListener(() => OnTopChartsButtonClick?.Invoke());
        }

        public void UnsubscribeButtonsListeners()
        {
            _mainPageButton.onClick.RemoveAllListeners();
            _topChartsButton.onClick.RemoveAllListeners();
        }
    }
}