using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Resources
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = .2f;

    //play animation
    public Animator animator;

    //Immunity
    protected float immuneTime = 1f;
    protected float lasImmune;

    //Push
    protected Vector3 pushDirection;

    //All fighters RecieveDamage / Die
    public virtual void RecieveDamage(Damage dmg)
    {
        if (Time.time - lasImmune > immuneTime)
        {
            lasImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            animator.SetTrigger("Hit");
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 30, .5f); 

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }
    protected virtual void Death()
    {

    }
}
