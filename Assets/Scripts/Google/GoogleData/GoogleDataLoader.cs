using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoogleDataLoader<T> : MonoBehaviour
{
    [SerializeField] protected string m_googleID;
    [SerializeField] protected T m_data;

    protected int progress = 0;

    private void Start()
    {
        Load();
    }

    public abstract void Load();

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

    protected virtual IEnumerator ProcessData(string _data, System.Action<string> onCompleted)
    {
        yield return null;
        yield return null;
        yield return null;
    }

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