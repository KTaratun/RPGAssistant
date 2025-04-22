using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class GoogleSheetCSVDownloader
{
    internal static IEnumerator DownloadData(string _googleSheetID, System.Action<string> onCompleted)
    {
        string url = "https://docs.google.com/spreadsheets/d/" + _googleSheetID + "/export?format=csv";

        yield return new WaitForEndOfFrame();

        string downloadData = null;
        string lastDownloadedDataString = "LastSheetDataDownloaded";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Download Error: " + webRequest.error);

                downloadData = PlayerPrefs.GetString(lastDownloadedDataString, null);
                Debug.Log("Using old data: " + downloadData);
            }
            else
            {
                Debug.Log("Download success");
                Debug.Log("Data: " + webRequest.downloadHandler.text);

                downloadData = webRequest.downloadHandler.text;

                PlayerPrefs.SetString(lastDownloadedDataString, downloadData);
            }
        }

        onCompleted(downloadData);
    }
}
