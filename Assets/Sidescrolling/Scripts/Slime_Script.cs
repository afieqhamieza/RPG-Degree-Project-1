using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Script : MonoBehaviour
{
     public int maxHealth = 100;
     int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
          currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void TakeDamage(int damage) {
          currentHealth -= damage;

          //play hurt animation

          if(currentHealth <= 0) {
               Die();
          }
     }

     void Die() {
          Debug.Log("Enemy died!");
          //Die animation

          //disable the enemy
     }
}