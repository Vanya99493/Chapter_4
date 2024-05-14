using System;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _7_PlayMarketSample.Scripts.UIModule.Panels.AppPagePanelModule
{
    public class AppPagePanel : MonoBehaviour
    {
        [SerializeField] private Button _returnButton;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _rate;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Transform _screenshotsParentTransform;

        [Header("Screenshot prefab")] 
        [SerializeField] private Image _screenshotPrefab; 

        private void Start()
        {
            _returnButton.onClick.AddListener(() => gameObject.SetActive(false));
            gameObject.SetActive(false);
        }

        public void Activate(AppSO appSO)
        {
            _icon.sprite = appSO.AppInfo.Icon;
            _name.text = appSO.AppInfo.Name;
            _rate.text = $"Rate: {appSO.Rate}/10";
            _description.text = appSO.AppInfo.Description;
            
            SetScreenshots(appSO);
            
            gameObject.SetActive(true);
        }

        private void SetScreenshots(AppSO appSO)
        {
            for (int i = 0; i < _screenshotsParentTransform.transform.childCount; i++)
            {
                Destroy(_screenshotsParentTransform.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < appSO.AppInfo.Screenshots.Length; i++)
            {
                Image screenshot = Instantiate(_screenshotPrefab, _screenshotsParentTransform);
                screenshot.sprite = appSO.AppInfo.Screenshots[i];
            }
        }
    }
}