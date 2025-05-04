using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

/*
public class MyEvent : Unity.Services.Analytics.Event
{
    public MyEvent() : base("myEvent")
    {
    }

    public string prefab { set { SetParameter("prefab", value); } }
}
*/

class PrefabLoader : MonoBehaviour
{
    public static GameObject currentPrefab;
    public GameObject initPrefab;

    void Start()
    {
        //UnityServices.InitializeAsync();
        //AnalyticsService.Instance.StartDataCollection();

        PrefabLoader.currentPrefab = initPrefab;
        PrefabLoader.currentPrefab = Instantiate(PrefabLoader.currentPrefab);
    }

    public static void LoadPrefab(GameObject prefab)
    {
        /*
        MyEvent myEvent = new MyEvent
        {
            prefab = prefab.name
        };

        AnalyticsService.Instance.RecordEvent(myEvent);
        */
        PrefabLoader.ClearPrefabs();
        PrefabLoader.currentPrefab = prefab;
        PrefabLoader.currentPrefab = Instantiate(PrefabLoader.currentPrefab);
    }


    public static void ClearPrefabs()
    {
        if (PrefabLoader.currentPrefab != null)
        {
            Destroy(PrefabLoader.currentPrefab);
            currentPrefab = null;
        }
    }
}
