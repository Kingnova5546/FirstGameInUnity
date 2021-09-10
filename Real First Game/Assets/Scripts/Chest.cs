using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int goldAmount = 5;
    public Animator animator;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            animator.SetTrigger("ChestCollect");
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText($"+ {goldAmount} Gold", 25, Color.yellow, transform.position, Vector3.up * 10, 1.5f);

        }

    }
}
