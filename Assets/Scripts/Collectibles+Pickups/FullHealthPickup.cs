using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthPickup : MonoBehaviour
{
    public int fullHealthToAdd;

    public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.Instance.currentHealth != PlayerHealthController.Instance.maxHealth)
            {


                PlayerHealthController.Instance.AddHealth(fullHealthToAdd);
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

        }
    }
}
