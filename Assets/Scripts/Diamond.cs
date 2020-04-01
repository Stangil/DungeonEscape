﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    //ontriggerenter to collect
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.diamonds += gems;
                Destroy(this.gameObject);
            }
        }
    }
    // check for player
    //add the value to the player
}
