using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeGraph : MonoBehaviour
{
    [SerializeField]    GameObject prefab;
    [Range(10,100)]public int resolution = 10;
    Transform[] points;
    float step, time;
    Vector3 position;
    void Awake()
    {
        position = Vector3.zero;
        CreateGraph();
    }

    void DrawGraph()
    {
           for(int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                Vector3 position = point.localPosition;
            position.y = FunctionLibrary.Wave(position.x,time);
                point.localPosition = position;
            }
        
    } 
    void CreateGraph()
    {

        step = 2f/resolution;
        var position = Vector3.zero;
        
        points = new Transform[resolution];

        for(int i = 0; i < points.Length; i++)
        {
            Transform p = Instantiate(prefab).transform;
            p.SetParent(transform,false);
            position.x = (i + 0.5f) * step - 1f;
            position.y = FunctionLibrary.MultiWave(position.x,time);
            p.localPosition = position;
            points[i] = p;
            p.localScale = Vector3.one * step;

        }
    }

    void Update()
    {
        time = Time.time;
        DrawGraph();
    }

}
