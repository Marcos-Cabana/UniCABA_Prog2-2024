using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
   PlayerAttack playerAttack;

   private void Start() 
   {
        playerAttack = GetComponentInParent<PlayerAttack>();
   }
   
   private void OnTriggerEnter(Collider other) 
   {
        if(other.transform.tag == "Enemy")
        {
            IDamagable damagable = other.transform.GetComponent<IDamagable>();
            if(damagable != null)
            {
                int damageAmount = playerAttack.DamageAmount;
                damagable.Damage(damageAmount);
            }
        } 
   }
}
