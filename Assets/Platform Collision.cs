using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformCollision : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private BoxCollider2D platformCollider;

    private BoxCollider2D playerCollider;
    private BoxCollider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        platformCollider = transform.GetComponent<BoxCollider2D>();
        enemyCollider= enemy.transform.GetComponent<BoxCollider2D>();
        playerCollider= player.transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if players bottom is above platforms top then have collision, if not than do not!

        if (playerCollider.size.y + player.transform.position.y <= platformCollider.size.y+ transform.position.y)
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            //print("Ignore 1");
        }
        else
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }

        // Same thing for enemies, nor functional
        // for (int x=0; x< enemy.Length; x++){    
        if (enemyCollider.size.y + enemy.transform.position.y <= platformCollider.size.y + transform.position.y)
        {
            Physics2D.IgnoreCollision(platformCollider, enemyCollider, true);
            //print("Ignore 2"); //running but collision not being ignored?
        }
        else
        {
            Physics2D.IgnoreCollision(platformCollider, enemyCollider, false);
        }

        // }
    }
}
