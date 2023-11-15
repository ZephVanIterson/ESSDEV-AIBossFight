using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int jumpPower;
    public float riseDecceleration = 0.5f;
    private float yMovement = 0;
    private int xDirection = 0;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (player.transform.position.x > transform.position.x + 3)
        {
            if (player.transform.position.x > transform.position.x + 2)
            {
                xDirection = 1;
            }
            else
            {
                xDirection = -1;
            }
        }
        else if (player.transform.position.x < transform.position.x - 3)
        {
            if (player.transform.position.x < transform.position.x - 2)
            {
                xDirection = -1;
            }
            else
            {
                xDirection = 1;
            }
        }
        else
        {
            xDirection = 0;
        }


        if (yMovement > 0)
        {
            yMovement -= riseDecceleration;
        }



        if (player.transform.position.y > transform.position.y && rb.IsTouchingLayers(LayerMask.GetMask("Ground")) && !(player.transform.position.x > transform.position.x + 4 || player.transform.position.x < transform.position.x - 4))
        {
            yMovement = jumpPower;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xDirection * speed, yMovement);
    }
}
