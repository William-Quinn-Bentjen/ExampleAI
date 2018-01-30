using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] += vertices[i] * Random.Range(.1f,1f) * Time.deltaTime;
            i++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
