using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    //Logic
    public float triggerLenghth = 1.0f;
    public float chaseLength = 5;

    private bool chase;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        //GameManager.instance.player.transform also kinda works
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();

    }
    private void FixedUpdate()
    {
        //is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenghth)
                chase = true;
            if (chase)
            {
                animator.SetBool("SlimeMove", true);
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
                
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chase = false;
            animator.SetBool("SlimeMove", false);
        }
        //check for overlaps    
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;          

            if (hits[i].tag == "Fighter" && hits[i].name != "Enemy")
            {
                collidingWithPlayer = true;
            }

            //the array is not cleaned up so we will do it ourselves
            hits[i] = null;
        }

    }
    protected override void Death()     
    {
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText($"+ {xpValue} xp", 30, Color.magenta, transform.position, Vector3.up * 30, 1.5f);
    }

}
