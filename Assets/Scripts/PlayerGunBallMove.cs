﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunBallMove : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2.537f, 0.265f, -6.93f), step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
