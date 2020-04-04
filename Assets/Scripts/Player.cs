using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    public GameObject gun;
    public GameObject gunBall;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("TurnAndShoot");
            StartCoroutine(Wait());
            Instantiate(gunBall, new Vector3(-3.34f, 0.35f, -6.44f), Quaternion.identity);
        }
    }

    IEnumerator Wait()
    {
        var Seconds = 30;
        Debug.Log("Waiting", gameObject);
        Debug.Log("ACTUALLY WAITING", gameObject);
        yield return new WaitForSeconds(Seconds);
        Debug.Log("Done Waiting", gameObject);
        Debug.Log("ACTUALLY WAITING DONE", gameObject);
        Debug.Log("Done wit stuff", gameObject);
    }
}
