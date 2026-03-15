using System.Collections.Generic;
using UnityEngine;

public class NodeBranch : MonoBehaviour
{
    [SerializeField] Node[] m_nodesInStatOrder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void PopulateNodes(List<ClassCard> classes)
    {
        for (int i = 0; i < m_nodesInStatOrder.Length; i++)
        {
            m_nodesInStatOrder[i].PopulateClassData(classes[i]);
        }
    }
}
