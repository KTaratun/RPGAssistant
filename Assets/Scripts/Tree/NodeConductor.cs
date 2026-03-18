using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NodeConductor : MonoBehaviour
{
    [SerializeField] protected CharacterManager m_charManager;

    protected NodeBranch[] m_branches;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_branches = GetComponentsInChildren<NodeBranch>();

        PopulateBranches();
    }

    protected void PopulateBranches()
    {
        Character firstCharacter = m_charManager.m_characterList[0];

        for (int i = 0; i < m_branches.Length; i++)
        {
            ClassCard baseClass = m_charManager.m_classData.GetBranchAtIndex(0)[i];
            List<ClassCard> crossClasses = m_charManager.m_classData.GetBranchAtIndex(i + 1);

            m_branches[i].PopulateNodes(baseClass, crossClasses, firstCharacter);
        }
    }
}