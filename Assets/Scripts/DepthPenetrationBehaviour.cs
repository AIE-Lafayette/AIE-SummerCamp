using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthPenetrationBehaviour : MonoBehaviour
{
    public float pentrationPercent;
    public int numVertex;
    public int vertsInside;
    public int VertexPercentageCheck;

    private void OnTriggerStay(Collider other)
    {
        var meshRef = other.GetComponent<MeshFilter>().mesh;
        numVertex = meshRef.vertexCount / VertexPercentageCheck;
        vertsInside = 0;
        for (int i = 0; i < numVertex * VertexPercentageCheck; i += VertexPercentageCheck)
        {
            if (this.GetComponent<Collider>().bounds.Contains(meshRef.vertices[i] + other.transform.position))
            {
                vertsInside++;
            }
        }
        pentrationPercent = ((float)vertsInside / (float)numVertex) * 100;
        if (pentrationPercent > 99)
            Debug.Log("GOAL");
    }
}
