using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private Vector3 direction;
    public float lifetime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerHealthController.Instance != null)
        {

            direction = PlayerHealthController.Instance.transform.position - transform.position;
        }

        rb.velocity = new Vector2 (direction.x, direction.y).normalized  * force ;
        Destroy(gameObject, lifetime);

    }

    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerHealthController.Instance.DamagePlayer();
            Destroy(gameObject);


        }

    }

}
