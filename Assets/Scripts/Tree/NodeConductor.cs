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
        for (int i = 0; i < m_branches.Length; i++)
        {
            m_branches[i].PopulateNodes(m_charManager.m_classData.GetBranchAtIndex(i), m_charManager.m_characterList[0]);
        }
    }
}