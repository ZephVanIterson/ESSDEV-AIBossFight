using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5;
    public int jumpPower = 1;
    public float riseDecceleration = 0.5f;
    public float minDistance = 1;
    public float attackRange = 2; //Greater than min_distance
    public GameObject player;
    public Transform target;
    public Transform attackTransform;
    public LayerMask attackableLayer;
    public float timeBetweenAttacks = 1;

    public float attackDamage = 10;
    private float attackTimeCounter = 0;
    private float yMovement = 0;
    private int xDirection = 0;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private RaycastHit2D[] hits;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        //rotate to look at the player (left or right)
        //Vector2 targetPosition = new Vector3(target.position.x, transform.position.y);
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.LookAt(targetPosition);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //movement

        //If enemy is outside of attack range
        if (Vector3.Distance(transform.position, target.position) > attackRange)
        {
            //Move towards player
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        //If enemy is in attack range, but outside of the minimum distance
        else if (Vector3.Distance(transform.position, target.position) > minDistance)
        {
            ////Try to attack
            if (Time.time - attackTimeCounter >= timeBetweenAttacks) 
            {
               Debug.Log("Attack");
               attack();
            }

        }
        //If enemy is too close (inside minimum distance)
        else
        {
            //move away
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
        }

        if (yMovement > 0)
        {
            yMovement -= riseDecceleration;
        }

        if (player.transform.position.y > transform.position.y && rb.IsTouchingLayers(LayerMask.GetMask("Ground")) && !(player.transform.position.x > transform.position.x + 4 || player.transform.position.x < transform.position.x - 4))
        {
            yMovement = jumpPower;
        }

        //attackTimeCounter += Time.deltaTime;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xDirection * speed, yMovement);
    }

    private void attack() 
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange + 50, transform.right, 0f, attackableLayer);

        Debug.Log(hits.Length);
        for (int i = 0; i < hits.Length; i++) 
        {
            hits[i].collider.gameObject.GetComponent<EntityHealth>().Damage(attackDamage);
        }

        attackTimeCounter = Time.time;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
