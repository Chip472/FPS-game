using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int firstHealth = 100;
    public int currentHealth;
    ParticleSystem shootEffect;

    void Start()
    {
        currentHealth = firstHealth;
        shootEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void TakeDamage(int health, Vector3 point)
    {
        currentHealth -= health;
        shootEffect.transform.position = point;
        shootEffect.Play();

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
