using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    public Sprite[] clouds;

    public Rigidbody2D Spawner1;
    public Rigidbody2D Spawner2;
    public Rigidbody2D Spawner3;
    public Rigidbody2D Spawner4;

    private Transform[] spawnerPos = new Transform[4];

    public float spawnX;

    private float[] Speed = new float[] {200, 200, 200, 200 };

    void Start()
    {
        spawnX = Spawner1.transform.position.x;
        spawnerPos[0] = Spawner1.transform;
        spawnerPos[1] = Spawner2.transform;
        spawnerPos[2] = Spawner3.transform;
        spawnerPos[3] = Spawner4.transform;
    }

    private void Update()
    {
        Debug.Log("Spawner: "+spawnerPos[0].position);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log("Touch: " + touchPos);
            touchPos.z = 0;

            foreach (Transform pos in spawnerPos)
            {
                //Vector2 p = Camera.main.ScreenToWorldPoint(pos.position);

                if(touchPos.x > pos.position.x - 1 && touchPos.x < pos.position.x + 1 && touchPos.y > pos.position.y - 1 && touchPos.y < pos.position.y + 1)
                {
                    pos.position = touchPos;
                }
            }

        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spawner1.velocity = Vector2.left * Speed[0] * Time.fixedDeltaTime;
        if (Spawner1.transform.position.x < -spawnX)
        {
            Spawner1.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner1.GetComponent<SpriteRenderer>(), Spawner1.transform, 0);
        }

        Spawner2.velocity = Vector2.left * Speed[1] * Time.fixedDeltaTime;
        if (Spawner2.position.x < -spawnX)
        {
            Spawner2.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner2.GetComponent<SpriteRenderer>(), Spawner2.transform,1);
        }

        Spawner3.velocity = Vector2.left * Speed[2] * Time.fixedDeltaTime;
        if (Spawner3.position.x < -spawnX)
        {
            Spawner3.transform.Translate(new Vector2(2 * spawnX, Random.Range(-2.5f, 2.5f)));
            ChangeCLoud(Spawner3.GetComponent<SpriteRenderer>(), Spawner3.transform,2);
        }

        Spawner4.velocity = Vector2.left * Speed[3] * Time.fixedDeltaTime;
        if (Spawner4.position.x < -spawnX)
        {
            Spawner4.transform.Translate(new Vector2(2 * spawnX, Random.Range(-0.5f, 0.5f)));
            ChangeCLoud(Spawner4.GetComponent<SpriteRenderer>(), Spawner4.transform,3);
        }


    }

    private void ChangeCLoud(SpriteRenderer renderer, Transform transform, int SpeedIndex)
    {
        renderer.sprite = clouds[(int)Random.Range(0, clouds.Length)];
        if (transform.position.y > 4.5f) transform.Translate(new Vector2(0, -2.5f));
        if (transform.position.y < 2f)
        {
            transform.Translate(new Vector2(0, 2f));
            
        }
        //Debug.Log(transform.position.y);
        Speed[SpeedIndex] = Random.Range(100, 300);
    }


}
