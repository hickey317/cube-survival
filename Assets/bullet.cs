using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 20.0f;  //×Óµ¯ËÙ¶È

    private float destoryTime = 2.0f;


    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

        velocity = transform.forward * speed;

        Destroy(gameObject, destoryTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.GetComponent<EnemyController>().reduceHP();
            Destroy(gameObject);
    //        other.GetComponent<EnemyOp>().Reduce(20);
            // Instantiate(fragment, other.transform.position, other.transform.rotation);
        }

    }
}
