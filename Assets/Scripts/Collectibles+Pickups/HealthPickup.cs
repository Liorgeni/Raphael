using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToAdd;

    public GameObject pickupEffect;

    public bool giveFullHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(PlayerHealthController.Instance.currentHealth != PlayerHealthController.Instance.maxHealth)
            {
                if (giveFullHealth)
                {
                    PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxHealth);

                }else
                {

                PlayerHealthController.Instance.AddHealth(healthToAdd);
                }


                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                AudioManager.instance.PlaySFX(10);

            }

        }
    }
}
