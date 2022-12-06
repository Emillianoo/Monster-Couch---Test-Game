using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private GameObject player;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyRunAway = transform.position - player.transform.position;
 
        transform.Translate(enemyRunAway.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            speed = 0;
            GetComponent<SpriteRenderer>().material.color = Color.gray;
        }
    }
}
