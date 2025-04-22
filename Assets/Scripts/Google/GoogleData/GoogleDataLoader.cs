using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoogleDataLoader : MonoBehaviour
{
    [SerializeField] protected string m_googleID;
    [SerializeField] protected GoogleData m_data;

    protected virtual void Awake()
    {
        m_data.m_entryData.Clear();
    }

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        StartCoroutine(GoogleSheetCSVDownloader.DownloadData(m_googleID, AfterDownload));
    }

    public void AfterDownload(string _data)
    {
        if (_data == null)
        {
            Debug.LogError("Was not able to download data or retrieve old data");
        }
        else
        {
            StartCoroutine(ProcessData(_data, AfterProcessData));
        }
    }

    protected abstract IEnumerator ProcessData(string _data, System.Action<string> onCompleted);

    protected abstract void ProcessLine(List<string> _currLineElements);

    protected abstract void AfterProcessData(string _errorMessage);

    protected bool IsAndroid()
    {
#if UNITY_IOS
        return false;
#endif
        return true;
    }
}