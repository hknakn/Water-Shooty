using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public Text score;
    public Image panel;
    public GameObject enemyGunBall;

    public static bool isDead = false;

    // Cool Down
    public float FireRate = 0.4f;
    private float NextFire;
    private int waitSecs;

    // Starts is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        waitSecs++;

        if (Time.time > NextFire && waitSecs > 150 && isDead == false)
        {
            if (waitSecs < 200)
            {
                anim.Play("EnemyShoot");
                NextFire = Time.time + FireRate;
                Instantiate(enemyGunBall, new Vector3(-2.6009f, 0.2835f, -6.866f), Quaternion.identity);
            }
            else
            {
                waitSecs = 0;
            }
        }

        // Check score and play dead animation
        if (score.text == "0")
        {
            isDead = true;
            anim.Play("Dead");
            panel.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GunBall")
        {
            score.text = (int.Parse(score.text) - 1).ToString();
        }
    }
}
