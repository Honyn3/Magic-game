using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    //DODELAT, SPATNE SE HYBOU MRAKY

    public Sprite[] clouds;

    public Rigidbody2D Spawner1;
    public Rigidbody2D Spawner2;
    public Rigidbody2D Spawner3;
    public Rigidbody2D Spawner4;

    public float spawnX;

    float Speed = 200;

    void Start()
    {
        spawnX = Spawner1.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spawner1.velocity = Vector2.left * Speed * Time.fixedDeltaTime;
        if (Spawner1.transform.position.x < -spawnX)
        {
            Spawner1.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner1.GetComponent<SpriteRenderer>(), Spawner1.transform);
        }

        Spawner2.velocity = Vector2.left * Speed * Time.fixedDeltaTime;
        if (Spawner2.position.x < -spawnX)
        {
            Spawner2.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner2.GetComponent<SpriteRenderer>(), Spawner2.transform);
        }

        Spawner3.velocity = Vector2.left * Speed * Time.fixedDeltaTime;
        if (Spawner3.position.x < -spawnX)
        {
            Spawner3.transform.Translate(new Vector2(2 * spawnX, Random.Range(-2.5f, 2.5f)));
            ChangeCLoud(Spawner3.GetComponent<SpriteRenderer>(), Spawner3.transform);
        }

        Spawner4.velocity = Vector2.left * Speed * Time.fixedDeltaTime;
        if (Spawner4.position.x < -spawnX)
        {
            Spawner4.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner4.GetComponent<SpriteRenderer>(), Spawner4.transform);
        }

    }

    private void ChangeCLoud(SpriteRenderer renderer, Transform transform)
    {
        renderer.sprite = clouds[(int)Random.Range(0, clouds.Length)];
        if (transform.position.y > 1) transform.Translate(new Vector2(0, -0.5f));
        if (transform.position.y < 0.2f)
        {
            transform.Translate(new Vector2(0, 0.5f));
            //Debug.Log(transform.position.y);
        }
        
    }


}
