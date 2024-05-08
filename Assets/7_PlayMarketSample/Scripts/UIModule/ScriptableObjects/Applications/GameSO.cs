using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications
{
    [CreateAssetMenu(fileName = "GameSO", menuName = "App/GameSO")]
    public class GameSO : AppSO
    {
        public GameCategory GameCategory;
    }
}