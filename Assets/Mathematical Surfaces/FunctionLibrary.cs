using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class FunctionLibrary 
{
    public static float Wave(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    } 
    
    public static float MultiWave(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y+= Mathf.Sin(2f * Mathf.PI * (x+t))/2;
        return y/1.5f; 
    } 
    public static float MultiWave2(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + t)) * (1f / 2f);
		return y * (2f / 3f);
    }




}
