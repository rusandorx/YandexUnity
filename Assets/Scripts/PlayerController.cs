using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _lastRopeSegment;
    [SerializeField] private DistanceJoint2D _rope;
    private Rigidbody2D _rigidbody;

    void Detach()
    {
        _lastRopeSegment.connectedBody = null;
        _rope.connectedBody = null;
        _lastRopeSegment.enabled = false;
        _rope.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Detach();
        }
    }
}