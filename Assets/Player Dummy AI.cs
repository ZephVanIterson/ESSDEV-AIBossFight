using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyAI : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public int Smartness = 0;
    bool randomMovement = false;
    //Will be used to determine length of an action in s 
    float decisionTime;
    int rnd;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement=transform.GetComponent<PlayerMovement>();
        //PickAction();
        switch (Smartness)
        {
            case 0:
                randomMovement = true;
                decisionTime =2;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time>=decisionTime)
        {
            rnd = Random.Range(0, 100);
            time=0;
        }
        if (randomMovement)
        {
            PickAction();
        }
    }

    private void PickAction(){
        if(rnd<=40){
            playerMovement.MoveLeft();
        }
        else if(rnd<=80){
            playerMovement.MoveRight();
        }
        else if(rnd>80){
            playerMovement.Jump();
        }
    }
}
