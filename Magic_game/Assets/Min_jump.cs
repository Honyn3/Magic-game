using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min_jump : MonoBehaviour
{
    public Transform background;
    public Rigidbody2D shield;
    public Rigidbody2D player;
    public float Speed;
    public float ShieldMoveSpeed;

    public Vector2 ShieldTarget;

    private void Start()
    {
        ShieldTarget = GenerateShieldTarget();
    }

    private void FixedUpdate()
    {
        background.transform.Translate(0, 10f * Time.fixedDeltaTime, 0);
        player.AddForce(new Vector2(10 * Input.acceleration.x - player.velocity.x, 10 *Input.acceleration.y - player.velocity.y) * Time.fixedDeltaTime * Speed);
        shield.velocity = ((ShieldTarget - shield.position).normalized * ShieldMoveSpeed * Time.fixedDeltaTime);
        if (Vector2.Distance(shield.position, ShieldTarget) < 2f) ShieldTarget = GenerateShieldTarget();
    }

    private Vector2 GenerateShieldTarget()
    {
        int x = Random.Range(-10, 10);
        int y = Random.Range(-4,4);
        Vector2 target = new Vector2(x, y);
        return target;
    }
}
