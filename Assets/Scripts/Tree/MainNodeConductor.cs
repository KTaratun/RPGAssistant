using UnityEngine;

public class NodeConductor : MonoBehaviour
{
    [SerializeField] protected ClassData m_classData;

    protected NodeBranch[] m_branches;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_branches = GetComponentsInChildren<NodeBranch>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_classData.GetNumberOfBranches(); i++)
        {
            m_branches[i].PopulateNodes(m_classData.GetBranchAtIndex(i));
        }
    }
}