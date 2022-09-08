using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min_jump : MonoBehaviour
{
    public Transform background;
    public Rigidbody2D player;

    private void FixedUpdate()
    {
        background.transform.Translate(0, 10f * Time.fixedDeltaTime, 0);
    }
}
