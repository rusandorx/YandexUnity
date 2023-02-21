using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour, IMover
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _angle;
    [SerializeField] private AnimationCurve _dynamic;
    [SerializeField] private float _initialDistance;
    [SerializeField] private Transform _center;

    private float _time;

    public void Attach(Transform center, float distance)
    {
        _center = center;
        _initialDistance = distance;
    }

    public Vector3 Evaluate(float time)
    {
        float currentSpeed = _speed * _dynamic.Evaluate(_angle / -180);
        _time *= currentSpeed;
        _angle = Mathf.PingPong(_time, 180) * -1 * Mathf.Deg2Rad;

        Vector3 center = new Vector3(_center.position.x, _center.position.y, 0);
        Vector3 offset = new Vector3(Mathf.Cos(_angle), Mathf.Sin(_angle), 0) * _initialDistance;
        Vector3 target = center + offset;

        return target;
    }
}