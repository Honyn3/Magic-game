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

    public GameObject EndBackground;
    public GameObject MantleTop;
    public GameObject BloodParticles;

    public Vector2 ShieldTarget;
    public float DetectRadius;
    public float ColorDecrease;
    public float FallSpeed;

    private SpriteRenderer shieldSprite;
    public bool Survive = false;
    private bool End = false;

    private void Start()
    {
        ShieldTarget = GenerateShieldTarget();
        shieldSprite = shield.GetComponent<SpriteRenderer>();
        shieldSprite.color = Color.white;
    }

    private void ReduceShieldColor()
    {
        if(shieldSprite.color.r > 0)
        shieldSprite.color = new Color(shieldSprite.color.r -ColorDecrease, 255, shieldSprite.color.b -ColorDecrease);

        if (shieldSprite.color.r < 0.2f) Survive = true;
    }

    private void Update()
    {
        if (Vector2.Distance(shield.position, player.position) < DetectRadius && !End) ReduceShieldColor();
    }

    private void FixedUpdate()
    {
        background.transform.Translate(0, FallSpeed * Time.fixedDeltaTime, 0);
        if (background.position.y > 29) Ending();

        if (End) 
        {
            shield.transform.Translate(0, -FallSpeed * Time.fixedDeltaTime, 0);
            player.transform.Translate(0, -FallSpeed * Time.fixedDeltaTime, 0);
            return;
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!End) return;

        if (Survive)
        {
            FallSpeed = -FallSpeed;
        }
        else
                {
            BloodParticles.transform.position = new Vector2(player.position.x, BloodParticles.transform.position.y);
            BloodParticles.SetActive(true);

                }
    }

    private void Ending()
    {
        if (End) return;
        MantleTop.SetActive(false);
        End = true;
        EndBackground.SetActive(true);
        player.velocity = Vector2.zero;
        shield.velocity = Vector2.zero;


        Debug.Log(Survive);
        if (Survive)
        {
            player.transform.Translate(0, 10, 0);
            shield.transform.position = player.transform.position;
        }
        else
        {
            player.transform.Translate(0, 10, 0);
            shield.transform.Translate(0, 10, 0);
        }
    }
}
