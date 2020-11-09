using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeGraph : MonoBehaviour
{
    [SerializeField]    GameObject prefab;
    [Range(10,100)]public int resolution = 10;
    [SerializeField] FunctionLibrary.FunctionNames function = default;
    Transform[] points;
    float step, time;
    FunctionLibrary.Function f;
    Vector3 position;
    void Awake()
    {
        position = Vector3.zero;
        f = FunctionLibrary.GetFunction(function);

        step = 2f / resolution;
        points = new Transform[resolution * resolution];
        CreateGraph();
    }

    void DrawGraph()
    {
            for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
            {
                if (x == resolution) { x = 0; z += 1; }
                float u = (x + 0.5f) * step - 1f;
                float v = (z + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, time);
            }
        
    } 
    void CreateGraph()
    {


        for(int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution) { x = 0; z += 1; }
            Transform p = Instantiate(prefab).transform;
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            p.localPosition = position;
            p.SetParent(transform, false);
            points[i] = p;
            p.localScale = Vector3.one * step;

        }
    }

    

    void Update()
    {

        f = FunctionLibrary.GetFunction(function);
        time = Time.time;
        DrawGraph();
    }

}
