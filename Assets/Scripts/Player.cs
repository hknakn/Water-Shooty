using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    public GameObject gun;
    public GameObject gunBall;
    public GameObject enemy;
    public int waitSecs = 0;
    private bool animated;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.Play("TurnAndShoot");
            animated = true;
        }


        if (animated)
        {
            waitSecs++;

            if (waitSecs == 20)
            {
                waitSecs = 0;
                anim.speed = 0;
                Instantiate(gunBall, new Vector3(-3.34f, 0.35f, -6.44f), Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.speed = 2;
            animated = false;
        }
    }
}
