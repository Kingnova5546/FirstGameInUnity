using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        //teleport player
        {
            GameManager.instance.SaveState();
            string screneNames = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(screneNames);
        }
        
    }

}
