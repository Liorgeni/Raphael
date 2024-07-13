using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    [HideInInspector]
    public bool isDeafeated;

    private Animator anim;

    private float timer;

    public float waitToDestroy;

    bool isFacingRight = false;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            anim.SetBool("isAttacking", true);

        }


        if (isDeafeated)
        {
            waitToDestroy -= Time.deltaTime;
            if (waitToDestroy <= 0)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(5);
            }
        }

        if (PlayerHealthController.Instance != null) 
        {
            bool shouldFaceRight = transform.position.x <= PlayerHealthController.Instance.transform.position.x;


            if (shouldFaceRight && !isFacingRight)
            {
                Flip();
                isFacingRight = true;
            }
            else if (!shouldFaceRight && isFacingRight)
            {
                Flip();
                isFacingRight = false;
            }


        }



    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1; // Invert the x scale to flip
        transform.localScale = currentScale;
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isDeafeated)
            {
                PlayerHealthController.Instance.DamagePlayer();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            FindFirstObjectByType<PlayerController>().Jump();
            anim.SetTrigger("defeated");
            isDeafeated = true;
            AudioManager.instance.PlaySFX(6);

        }
    }
     void ResetAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyController : MonoBehaviour
//{

//    private Animator anim;

//    [HideInInspector]
//    public bool isDeafeated;

//    public float waitToDestroy;

//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (isDeafeated)
//        {
//            waitToDestroy -= Time.deltaTime;
//            if (waitToDestroy <= 0)
//            {
//                Destroy(gameObject);

//                AudioManager.instance.PlaySFX(5);
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            if (!isDeafeated)
//            {

//                PlayerHealthController.Instance.DamagePlayer();
//            }

//        }
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {

//            //  Destroy(gameObject);
//            FindFirstObjectByType<PlayerController>().Jump();

//            anim.SetTrigger("defeated");
//            isDeafeated = true;
//            AudioManager.instance.PlaySFX(6);

//        }
//    }

//}