using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GoogleSheetLoader : MonoBehaviour
{
    [SerializeField] private string m_googleSheetID;
    [SerializeField] private GoogleSheetData m_data;

    private int progress = 0;
    private bool firstLine = true;
    private List<string> columns;

    private void Awake()
    {
        m_data.m_entryData.Clear();
        columns = new List<string>();
    }

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        StartCoroutine(CSVDownloader.DownloadData(m_googleSheetID, AfterDownload));
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

    private IEnumerator ProcessData(string _data, System.Action<string> onCompleted)
    {
        yield return null;
        yield return null;
        yield return null;

        // Line level
        bool inQuote = false;
        int linesSinceUpdate = 0;
        int kLinesBetweenUpdate = 15;

        // Entry Level
        string currEntry = "";
        int currCharIndex = 0;
        bool currEntryContainedQuote = false;
        List<string> currLineEntries = new List<string>();

        char lineEnding = IsAndroid() ? '\r' : '\n';
        int lineEndingLength = IsAndroid() ? 2 : 1;

        while (currCharIndex < _data.Length)
        {
            if (!inQuote && (_data[currCharIndex] == lineEnding))
            {
                // Skip the line ending
                currCharIndex += lineEndingLength;

                // Wrap up the last entry
                // If we were in a quote, trim bordering quotation marks
                if (currEntryContainedQuote)
                {
                    currEntry = currEntry.Substring(1, currEntry.Length - 2);
                }

                currLineEntries.Add(currEntry);
                currEntry = "";
                currEntryContainedQuote = false;

                // Line ended
                ProcessLineFromCSV(currLineEntries);
                currLineEntries = new List<string>();

                linesSinceUpdate++;
                if (linesSinceUpdate > kLinesBetweenUpdate)
                {
                    linesSinceUpdate = 0;
                    yield return null;
                }
            }
            else
            {
                if (_data[currCharIndex] == '"')
                {
                    inQuote = !inQuote;

                    currEntryContainedQuote = true;
                }

                // Entry level stuff
                {
                    if (_data[currCharIndex] == ',')
                    {
                        if (inQuote)
                        {
                            currEntry += _data[currCharIndex];
                        }
                        else
                        { 
                            if (currEntryContainedQuote)
                            {
                                currEntry = currEntry.Substring(1, currEntry.Length - 2);
                            }

                            currLineEntries.Add(currEntry);
                            currEntry = "";
                            currEntryContainedQuote = false;
                        }
                    }
                    else
                    {
                        currEntry += _data[currCharIndex];
                    }
                }

                currCharIndex++;
            }

            progress = (int)((float)currCharIndex / _data.Length * 100.0f);
        }


        // TODO: SHOULDN'T HAVE TO REPEAT THIS!
        if (currEntryContainedQuote)
        {
            currEntry = currEntry.Substring(1, currEntry.Length - 2);
        }

        currLineEntries.Add(currEntry);
        ProcessLineFromCSV(currLineEntries);

        onCompleted(null);
    }

    private void ProcessLineFromCSV(List<string> _currLineElements)
    {
        if (firstLine)
        {
            for (int i = 0; i < _currLineElements.Count; i++)
            {
                columns.Add(_currLineElements[i]);
            }

            firstLine = false;
        }
        else
        {
            GoogleSheetEntry newEntry = new GoogleSheetEntry(_currLineElements[0]);

            for (int i = 1; i < _currLineElements.Count; i++)
            {
                GoogleSheetColumn newColumn = new GoogleSheetColumn(columns[i], _currLineElements[i]);
                newEntry._column.Add(newColumn);
            }

            m_data.m_entryData.Add(newEntry);
        }
    }

    private void AfterProcessData(string _errorMessage)
    {

    }    

    private bool IsAndroid()
    {
#if UNITY_IOS
        return false;
#endif
        return true;
    }
}
