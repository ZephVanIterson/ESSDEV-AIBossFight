using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int jumpPower;

    public float riseDecceleration= 0.5f;
    private float yMovement=0; 
    private Rigidbody2D rb; 
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(yMovement>0){
            yMovement-=riseDecceleration;
        }

        if(movementDirection.x != 0) {
            if(transform.rotation.y == 0 && movementDirection.x > 0){
                transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (transform.rotation.y == -1 && movementDirection.x < 0) {
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
        
        
    }

    void FixedUpdate(){
        rb.velocity=new Vector2((movementDirection*speed).x,yMovement);
    
    }

    public void MoveLeft(){
    movementDirection= new Vector2 (-1,0);
    }

    public void MoveRight(){
    movementDirection= new Vector2 (1,0);
    }

    public void Jump(){
        if(rb.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            yMovement=jumpPower;
        }
    }
}
