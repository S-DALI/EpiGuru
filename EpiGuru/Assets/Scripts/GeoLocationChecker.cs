using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GeoLocationChecker : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetGeoLocation());
    }

    IEnumerator GetGeoLocation()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://ipinfo.io/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Помилка отримання геопозиції: " + www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            string locationData  = JsonUtility.FromJson<LocationData>(jsonResult)?.country;

            if (locationData != null && locationData != null)
            {
                if (locationData.ToLower() != "ua")
                {
                    Application.OpenURL("https://uk.wikipedia.org/");
                }
            }
        }
    }

    [System.Serializable]
    public class LocationData
    {
        public string country;
    }
}