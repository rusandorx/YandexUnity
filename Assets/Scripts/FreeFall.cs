using System;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour, IMover
{
    private List<Vector3> _points;
    private int _pointsPerUnit;

    public void Throw(Vector3 target)
    {
        foreach (var point in CalculateCurve(target, target + Vector3.right * 10))
        {
            
        }
    }

    private IEnumerable<Vector3> CalculateCurve(Vector3 from, Vector3 to)
    {
        if (from == to)
            throw new InvalidOperationException("Points must not be equal");

        int pointsCount = Mathf.FloorToInt(Vector3.Distance(from, to)) / _pointsPerUnit;
        for (int i = 0; i < pointsCount; i++)
        {
            yield return Vector3.Lerp(from, to, (float) i / pointsCount);
        }
    }

    public Vector3 Evaluate(float time)
    {
        
    }
}