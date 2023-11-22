using AppsFlyerSDK;
using UnityEngine;


public class AppsflyerIntegration : MonoBehaviour
{
    [SerializeField] private string appsFlyerDevKey = "ytPuQc6oHMvGHLh83FVpdd";
    [SerializeField] private string appID = "appID";
    void Start()
    {  
        AppsFlyer.initSDK(appsFlyerDevKey, appID);
        AppsFlyer.startSDK();

        DontDestroyOnLoad(gameObject);
    }
}
