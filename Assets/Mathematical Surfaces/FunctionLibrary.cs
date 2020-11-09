using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class FunctionLibrary 
{

    public delegate Vector3 Function(float u, float v, float t);
    public enum FunctionNames { Wave, MultiWave, Logaritmic, Ripple, Sphere };

    static Function[] functions = { Wave, MultiWave, Logaritmic, Ripple, Sphere};
    public static Function GetFunction (FunctionNames name) { return functions[(int)name]; }





    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(Mathf.PI * (u + v + t));
        p.z = v;
        return p;
    } 
    
    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(Mathf.PI * (u + 0.5f * t));
        p.y += 0.5f * Mathf.Sin(2f * Mathf.PI * (v + t)) / 2; 
        p.y += Mathf.Sin(Mathf.PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        
        return p;
    }
    public static Vector3 Logaritmic(float u, float v, float t)
    {
        Vector3 p;
        p.x = Mathf.Log(u + 2);
        p.y = Mathf.Tan(Mathf.PI * (v + t / 2));
        p.z = v;
        return p;
    }
    public static Vector3 Ripple(float u, float v, float t)
    {
        Vector3 p;
        float d = Mathf.Sqrt(u * u + v * v);
        p.x = u;
        p.y = Mathf.Sin(Mathf.PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }
    public static Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(0.5f * Mathf.PI * v);

        p.x = r * Mathf.Sin(Mathf.PI * u);
        p.y = Mathf.Sin(Mathf.PI * 0.5f * v);
        p.z = r * Mathf.Sin(Mathf.PI * u);
        return p;
    }




}
