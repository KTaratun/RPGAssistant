using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Character;


public class GoogleDocLoader : GoogleDataLoader<GoogleDocData>
{
    private void Awake()
    {
        m_data.m_entryData.Clear();
    }

    public override void Load()
    {
        StartCoroutine(GoogleDocTXTDownloader.DownloadData(m_googleID, AfterDownload));
    }

    protected override IEnumerator ProcessData(string _data, System.Action<string> onCompleted)
    {
        base.ProcessData(_data, onCompleted);

        yield return null;

        // Parse symbols
        char tabSymbol = '⇪';
        char classSymbol = '⇡';
        char abilitySymbol = '➠';

        char lineEnding = IsAndroid() ? '\r' : '\n';

        string[] tabs = _data.Split(tabSymbol);

        for (int i = 1; i < tabs.Length; i++)
        {
            string[] classData = tabs[i].Split(classSymbol);
            GoogleDocEntry newEntry = new GoogleDocEntry(tabs[i].Split(' ')[0]);

            for (int j = 1; j < classData.Length; j++)
            {
                // Get name
                string className = classData[j].Split(':')[1];
                className = className.Split(lineEnding)[0];

                // Get Primary Stats
                string[] primaryStats = classData[j].Split(':')[0].Split('/');
                List<STATS> stats = new List<STATS>();
                for (int k = 0; k < primaryStats.Length; k++)
                {
                    stats.Add((STATS)Enum.Parse(typeof(STATS), primaryStats[k]));

                }

                // Get Abilities
                List<string> abilities = classData[j].Split(abilitySymbol).ToList();
                abilities.Remove(abilities[0]);

                for (int k = 0; k < abilities.Count; k++)
                {
                    abilities[k] = abilities[k].Split(lineEnding)[0];
                }

                Class newClass = new Class(className, stats.ToArray(), abilities);


                newEntry.m_classes.Add(newClass);
            }

            m_data.m_entryData.Add(newEntry);
        }

        onCompleted(null);
    }

    protected override void ProcessLine(List<string> _abilities)
    {

    }
}
