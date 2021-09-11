using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));

        if ((x + y) == 0)
            animator.SetBool("SpeedB", true);
        else
            animator.SetBool("SpeedB", false);
    }
       
}

