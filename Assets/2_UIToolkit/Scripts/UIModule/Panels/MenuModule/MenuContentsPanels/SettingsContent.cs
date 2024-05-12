using System;
using _2_UIToolkit.Scripts.UIModule.Panels.MenuModule.MenuContentsPanels.SettingsContents;
using UnityEngine;
using UnityEngine.UIElements;

namespace _2_UIToolkit.Scripts.UIModule.Panels.MenuModule.MenuContentsPanels
{
    [Serializable]
    public class SettingsContent
    {
        public VisualTreeAsset SettingsContentAsset;
        
        [SerializeField] private GeneralSettingsContent _generalSettingsContent;
        [SerializeField] private VideoSettingsContent _videoSettingsContent;
        [SerializeField] private AudioSettingsContent _audioSettingsContent;
        [SerializeField] private CreditsSettingsContent _creditsSettingsContent;
    }
}