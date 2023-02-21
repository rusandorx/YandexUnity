using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private IMover _mover;
    private float _time;

    private void LateUpdate()
    {
        _time += Time.deltaTime;
        transform.position = _mover.Evaluate(_time);
    }
}