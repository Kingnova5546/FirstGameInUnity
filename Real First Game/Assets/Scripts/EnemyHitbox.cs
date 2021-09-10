using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable    
{
    //Damage
    public int damage = 1;
    public float pushForce = 5;
    public Animator animator;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                //create a new damage object, then send it to fighter                
                Damage dmg = new Damage
                {
                    damageAmount = damage,
                    origin = transform.position,
                    pushForce = pushForce
                };                
                coll.SendMessage("RecieveDamage", dmg);
            }
           
        }
    }

}
