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
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.speed = 2;
            waitSecs = 0;
            //animated = false;
        }
    }
}
