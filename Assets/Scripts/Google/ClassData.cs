using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Character;

[CreateAssetMenu(fileName = "ClassData", menuName = "Scriptable Objects/ClassData")]
public class ClassData : GoogleDocData
{
    public enum CLASS_PARAMETER { BASE, STR, DEX, CON, INT, WIS, CHA }

    #region Get Class

    public ClassCard GetClass(int major, int minor)
    {
        return m_entryData[major].m_classes[minor];
    }

    public ClassCard GetClass(CLASS_PARAMETER major, int minor)
    {
        return m_entryData[(int)major].m_classes[minor];
    }

    public ClassCard GetClass(STATS major, STATS minor)
    {
        return m_entryData[(int)major].m_classes[(int)minor];
    }

    public ClassCard GetClass(CLASS_PARAMETER major, STATS minor)
    {
        return m_entryData[(int)major].m_classes[(int)minor];
    }

    #endregion

    public int GetNumberOfBranches()
    {
        return m_entryData.Count;
    }

    #region Get Branch

    public List<ClassCard> GetBranchAtIndex(CLASS_PARAMETER branch)
    {
        return m_entryData[(int)branch].m_classes;
    }

    public List<ClassCard> GetBranchAtIndex(int branch)
    {
        return m_entryData[branch].m_classes;
    }

    #endregion
}
