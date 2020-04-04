using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunBallMove : MonoBehaviour
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3.713f, 0.2835f, -6.20f), step);

        // Check if prefab is out of the camera and destroy the gameObject
        if (transform.position == new Vector3(-3.713f, 0.2835f, -6.20f))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.canDie && other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}