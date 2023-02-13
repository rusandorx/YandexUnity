using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HingeJoint2D _joint;
    private DistanceJoint2D _distance;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _distance =  GameObject.Find("Rope").GetComponent<DistanceJoint2D>();
        _joint = GameObject.Find("5").GetComponent<HingeJoint2D>();
    }

    void Attach()
    {
        _joint.connectedBody = _rigidbody;
        _distance.connectedBody = _rigidbody;
    }

    void Detach()
    {
        _joint.connectedBody = null;
        _distance.connectedBody = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Detach();
        }
    }
}