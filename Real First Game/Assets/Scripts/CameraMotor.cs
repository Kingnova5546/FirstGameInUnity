using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltax = lookAt.position.x - transform.position.x;
        if (deltax > boundX || deltax < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltax - boundX;
            }
            else
            {
                delta.x = deltax + boundX;
            }
        }
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        
        transform.position += new Vector3(delta.x, delta.y, 0);


    }

}
