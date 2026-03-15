using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    protected LineRenderer m_lineRenderer;

    [SerializeField] protected List<Node> m_connectedNodes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();


        //InitAdjacentNodes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void InitAdjacentNodes()
    {
        int numberOfCombinations = 6;
        float distance = 1;

        float spacing = 360 / numberOfCombinations;

        List<Vector3> nodePositions = new List<Vector3>();

        m_connectedNodes = new List<Node>();
        //for (int i = 0; i < numberOfCombinations; ++i)
        //{
        //    m_connectedNodes.Add(newNode);
        //
        //    newNode.transform.position += new Vector3(0, distance, 0);
        //
        //    transform.Rotate(new Vector3(0, 0, spacing));
        //}

        for (int i = 0; i < numberOfCombinations; i++)
        {
            nodePositions.Add(transform.position);
            nodePositions.Add(m_connectedNodes[i].transform.position);
        }

        m_lineRenderer.positionCount = nodePositions.Count;
        m_lineRenderer.SetPositions(nodePositions.ToArray());
    }
}
