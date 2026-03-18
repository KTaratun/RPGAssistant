using System.Collections.Generic;
using UnityEngine;

public class NodeBranch : MonoBehaviour
{
    [SerializeField] Node[] m_nodesInStatOrder;

    public void PopulateNodes(ClassCard _baseClass, List<ClassCard> _classes, Character _character)
    {
        m_nodesInStatOrder[0].PopulateClassData(_baseClass, _character, true);

        for (int i = 1; i < m_nodesInStatOrder.Length; i++)
        {
            m_nodesInStatOrder[i].PopulateClassData(_classes[i - 1], _character, false);
        }
    }
}
