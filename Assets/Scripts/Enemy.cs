using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public Text score;

    // Starts is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("EnemyShoot");
        }

        if (score.text == "5")
        {
            anim.Play("Dead");
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
