using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexBreathe : MonoBehaviour {
    public float MaxInhale = 1;
    public float MinExhale = 1;
    public float MaxLerpTime = 1;
    public float MinLerpTime = 1;
    public bool Breathing = true;
    Mesh mesh;
    Vector3[] vertices;
    List<float> BreathValue = new List<float>();
    List<float> BreathTimeValue = new List<float>();
    Vector3[] OriginalVertices;
    float previousBreathValue = 1;

    // Use this for initialization
    void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        OriginalVertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            BreathValue.Add(Random.Range(MinExhale, MaxInhale));
            BreathTimeValue.Add(Random.Range(MinLerpTime, MaxLerpTime));
        }
    }
    // Update is called once per frame
    void Update () {
        int index = 0;
        foreach (float time in BreathTimeValue)
        {
            BreathTimeValue[index] -= Time.deltaTime;
            if (BreathTimeValue[index] <= 0)
            {
                //new breath start
                vertices[index] = Vector3.Lerp(OriginalVertices[index] * BreathValue[index], OriginalVertices[index], 0);
                BreathValue[index] = Random.Range(MinExhale, MaxInhale);
                BreathTimeValue[index] = Random.Range(MinLerpTime, MaxLerpTime);
            }
            else
            {
                //continue breathing
                vertices[index] = Vector3.Lerp(OriginalVertices[index] * BreathValue[index], OriginalVertices[index], BreathTimeValue[index]);
            }
        }
    }
}
