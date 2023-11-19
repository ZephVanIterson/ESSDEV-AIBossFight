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
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        platformCollider = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if players bottom is above platforms top then have collision, if not than do not!

        if (player.transform.GetComponent<BoxCollider2D>().size.y / 2 + player.transform.position.y <= platformCollider.size.y / 2 + transform.position.y)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), player.transform.GetComponent<BoxCollider2D>(), true);
        }
        else
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), player.transform.GetComponent<BoxCollider2D>(), false);
        }

        // Same thing for enemies
        // for (int x=0; x< enemy.Length; x++){    
        if (enemy.transform.GetComponent<BoxCollider2D>().size.y / 2 + enemy.transform.position.y <= platformCollider.size.y / 2 + transform.position.y)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), enemy.transform.GetComponent<BoxCollider2D>(), true);
        }
        else
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), enemy.transform.GetComponent<BoxCollider2D>(), false);
        }

        // }
    }
}
