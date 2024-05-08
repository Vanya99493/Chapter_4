using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.SortedConfigs
{
    [CreateAssetMenu(fileName = "GameSortedConfigSO", menuName = "SortedConfigs/GameSortedConfigSO")]
    public class GameSortedConfigSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Description;
        public bool IsRandom;
        public GameCategory GameCategory;
        public bool ByRateDecreasing;
        public int AppsNumber;
        
        public void OnBeforeSerialize(){}

        public void OnAfterDeserialize()
        {
            if (IsRandom)
            {
                ByRateDecreasing = false;
                GameCategory = GameCategory.All;
            }
        }

        public List<AppSO> GetSortedGamesList(ApplicationListSO applicationListSO)
        {
            List<GameSO> sortedList = SortByCategory(applicationListSO);

            if (ByRateDecreasing)
            {
                sortedList = GetPopularApps(sortedList);
            }
            else if (IsRandom)
            {
                sortedList = GetRandomApps(sortedList);
            }

            List<AppSO> boxedList = new List<AppSO>();
            foreach (var gameSO in sortedList)
            {
                boxedList.Add(gameSO);
            }

            return boxedList;
        }

        private List<GameSO> SortByCategory(ApplicationListSO applicationListSO)
        {
            List<GameSO> sortedList = new List<GameSO>();
            foreach (var app in applicationListSO.Applications)
            {
                GameSO applicationSO = app as GameSO;

                if (IsRandom || GameCategory == GameCategory.All || applicationSO.GameCategory == GameCategory)
                {
                    sortedList.Add(applicationSO);
                }
            }

            return sortedList;
        }

        private List<GameSO> GetPopularApps(List<GameSO> list)
        {
            List<GameSO> newList = new List<GameSO>();
            list.Sort();
            foreach (var gameSO in list)
            {
                if (newList.Count >= AppsNumber)
                {
                    break;
                }

                newList.Add(gameSO);
            }

            return newList;
        }

        private List<GameSO> GetRandomApps(List<GameSO> list)
        {
            List<GameSO> newList = new List<GameSO>();
            int counter = 0;
            foreach (var gameSO in list)
            {
                if (Random.Range(0, list.Count - counter) < AppsNumber - newList.Count)
                {
                    newList.Add(gameSO);
                }
                counter++;
            }

            return newList;
        }
    }
}