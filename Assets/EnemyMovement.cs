using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int jumpPower;
    public float riseDecceleration= 0.5f;
    private float yMovement=0; 
    private int xDirection=0; 
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
        
        if(player.transform.position.x-4>transform.position.x){
            xDirection=1;
        }
        else if(player.transform.position.x+4>transform.position.x){
            xDirection=-1;
        }
        else{
            xDirection=0;
        }
        
        if(yMovement>0){
            yMovement-=riseDecceleration;
        }


        movementDirection= new Vector2 (xDirection,0);
        if(player.transform.position.y>transform.position.y&&rb.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            yMovement=jumpPower;
        }
    }

    void FixedUpdate(){
        rb.velocity=new Vector2((movementDirection*speed).x,yMovement);
    }
}
