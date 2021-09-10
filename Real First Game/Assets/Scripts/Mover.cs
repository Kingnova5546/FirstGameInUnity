using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = .45f;
    protected float xSpeed = .70f;
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();              
    }
   
    protected virtual void UpdateMotor(Vector3 input)
    {
        //Reset moveDelta
        moveDelta = input;
        

        //Swap sprite direction if he is going right or left

        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        //Add push vector if any
        moveDelta += pushDirection;

        //reduce push force every frame
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
        
        // Make sure we can move in this direction, by casting a box there first, if the box returns null we are free to move (Y axis)
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
        if (hit.collider == null)
        {
            //Make him move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            animator.SetTrigger("Move");
        }
        // X-Axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
        if (hit.collider == null)
        {
            //Make him move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            animator.SetTrigger("Move");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
