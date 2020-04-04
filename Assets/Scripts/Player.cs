using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    public GameObject gun;
    public GameObject gunBall;

    public int waitSecs = 0;
    public static bool canDie = false;
    public float walkSpeed = 0.4f;
    private bool rotatedForWalk = false;

    // Cool Down
    public float FireRate = 0.4f;
    private float NextFire;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enemy.isDead)
        {
            if (Input.GetMouseButton(0))
            {
                anim.Play("TurnAndShoot");

                waitSecs++;

                if (waitSecs > 20 && Time.time > NextFire)
                {
                    NextFire = Time.time + FireRate;
                    anim.speed = 0;
                    Instantiate(gunBall, new Vector3(-3.34f, 0.35f, -6.44f), Quaternion.identity);
                }
                canDie = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.speed = 2;
                waitSecs = 0;
                canDie = false;
            }
        }
        else if (Enemy.isDead)
        {
            anim.Play("Walking");
            float step = walkSpeed * Time.deltaTime;

            // We need to rotate one time. Check for that
            if (!rotatedForWalk)
            {
                rotatedForWalk = true;
                transform.Rotate(0, -180, 0);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2.533f, 0.184f, -6.931f), step);
        }
    }
}