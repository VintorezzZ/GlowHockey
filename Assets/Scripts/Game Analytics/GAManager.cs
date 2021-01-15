using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class GAManager : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();
    }

    public static void OnLevelComplete(int level)
    {
        GameAnalytics.NewDesignEvent ("Level Complete", level);
        //print(level);

    }
}
