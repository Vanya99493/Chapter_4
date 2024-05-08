using System.Collections.Generic;
using _7_PlayMarketSample.Scripts.UIModule.Enums;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.ApplicationLists;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications;
using _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.Applications.Base;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.ScriptableObjects.SortedConfigs
{
    [CreateAssetMenu(fileName = "ApplicationSortedConfigSO", menuName = "SortedConfigs/ApplicationSortedConfigSO")]
    public class ApplicationSortedConfigSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Description;
        public bool IsRandom;
        public ApplicationCategory ApplicationCategory;
        public bool ByRateDecreasing;
        public int AppsNumber;
        
        public void OnBeforeSerialize(){}

        public void OnAfterDeserialize()
        {
            if (IsRandom)
            {
                ByRateDecreasing = false;
                ApplicationCategory = ApplicationCategory.All;
            }
        }

        public List<AppSO> GetSortedApplicationsList(ApplicationListSO applicationListSO)
        {
            List<ApplicationSO> sortedList = SortByCategory(applicationListSO);

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

        private List<ApplicationSO> SortByCategory(ApplicationListSO applicationListSO)
        {
            List<ApplicationSO> sortedList = new List<ApplicationSO>();
            foreach (var app in applicationListSO.Applications)
            {
                ApplicationSO applicationSO = app as ApplicationSO;

                if (IsRandom || ApplicationCategory == ApplicationCategory.All || applicationSO.ApplicationCategory == ApplicationCategory)
                {
                    sortedList.Add(applicationSO);
                }
            }

            return sortedList;
        }

        private List<ApplicationSO> GetPopularApps(List<ApplicationSO> list)
        {
            List<ApplicationSO> newList = new List<ApplicationSO>();
            list.Sort();
            foreach (var applicationSO in list)
            {
                if (newList.Count >= AppsNumber)
                {
                    break;
                }

                newList.Add(applicationSO);
            }

            return newList;
        }

        private List<ApplicationSO> GetRandomApps(List<ApplicationSO> list)
        {
            List<ApplicationSO> newList = new List<ApplicationSO>();
            int counter = 0;
            foreach (var applicationSO in list)
            {
                if (Random.Range(0, list.Count - counter) < AppsNumber - newList.Count)
                {
                    newList.Add(applicationSO);
                }
                counter++;
            }

            return newList;
        }
    }
}