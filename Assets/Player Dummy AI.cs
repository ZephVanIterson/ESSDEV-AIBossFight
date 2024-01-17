using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyAI : MonoBehaviour
{
    private GameObject[] enemies;
    private PlayerMovement playerMovement;
    public int Smartness = 0;
    bool randomMovement = false;
    bool attack = false;
    bool smartAttack = false;
    //Will be used to determine length of an action in s 
    float decisionTime;
    int rnd;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        enemies=GameObject.FindGameObjectsWithTag("Enemy");
        playerMovement = transform.GetComponent<PlayerMovement>();
        rnd = Random.Range(0, 100);
        switch (Smartness)
        {
            case 0:
                randomMovement = true;
                decisionTime = 2;
                break;
            case 1:
                randomMovement = true;
                attack = true;
                decisionTime = 2;
                break;
            case 2:
                randomMovement = true;
                smartAttack = true;
                decisionTime = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= decisionTime)
        {
            rnd = Random.Range(0, 100);
            if (attack)
            {
                AttackChoice();
            }

            time = 0;
        }

        if (smartAttack)
        {
            SmartAttack();
        }

        if (randomMovement)
        {
            PickAction();
        }

    }

    private void PickAction()
    {
        if (rnd <= 40)
        {
            playerMovement.MoveLeft();
        }
        else if (rnd <= 80)
        {
            playerMovement.MoveRight();
        }
        else if (rnd > 80)
        {
            playerMovement.Jump();
        }
    }
    private void AttackChoice()
    {
        int attackRan = Random.Range(0, 100);
        if (attackRan <= 50)
        {
            //insert player attack method
            print("I attacked!");
        }
    }

    private void SmartAttack()
    {
        GameObject closestEnemy =enemies[0];
        float closestInX=10000000; 
        for(int i=0; i<enemies.Length; i++){
            if (enemies[i].transform.position.x-transform.position.x<closestInX){
                closestEnemy=enemies[i];
                closestInX=transform.position.x-enemies[i].transform.position.x;
            }
        }
        // print(enemies[0]);
        // print(enemies[1]);


        if(closestEnemy.transform.position.x>transform.position.x && closestEnemy.transform.position.x-transform.position.x<1){
            //attack right
            //print("Attack right");
        }
        else if(closestEnemy.transform.position.x<transform.position.x && closestEnemy.transform.position.x-transform.position.x<1){
            //attack right
            //print("Attack left");
        }
    }
}
