using UnityEditor;
using UnityEngine;
using static UnityEditor.FilePathAttribute;


public class PlayerAttack : MonoBehaviour
{
    public Transform attackTransform;
    public LayerMask attackableLayer;
    public LayerMask enemyLayer;

    public float attackDamage = 10;
    //public float attackRange = 1; //Greater than min_distance

    public KeyCode attackKey;
    private float attackTimeCounter = 0;
    public float timeBetweenAttacks = 1;
    public float attackArea=0;

    private float mapHeight = 0;
    private float mapWidth = 0;

    private Vector2 locationVector;
    private Vector2 sizeVector;

    private RaycastHit2D[] hits;
    // Start is called before the first frame update
    void Start()
    {

        Camera cam = Camera.main;
        mapHeight = 2f * cam.orthographicSize;
        mapWidth = mapHeight * cam.aspect;

        Debug.Log(mapHeight);
        Debug.Log(mapWidth);    

        sizeVector = new Vector2(mapWidth / 3, mapHeight);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Time.time - attackTimeCounter >= timeBetweenAttacks)
            {
                attackArea=1;
                //print(attackArea);
                attack(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.time - attackTimeCounter >= timeBetweenAttacks)
            {
                attackArea=2;
                //print(attackArea);
                attack(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Time.time - attackTimeCounter >= timeBetweenAttacks)
            {
                attackArea=3;
                //print(attackArea);
                attack(3);
            }
        }
        else{
             if (Time.time - attackTimeCounter >= 3*timeBetweenAttacks){
                attackArea=0;
             }
        }

    }

    private void attack(int location)
    {

        locationVector = new Vector2((mapWidth / 4)*location, 0);

        Debug.Log(locationVector);
        Debug.Log(sizeVector);


        //Get a rectangle cast
        hits = Physics2D.BoxCastAll(locationVector, sizeVector, 0f, Vector2.down, 25f, enemyLayer);

        


        Debug.Log(hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject);
            hits[i].collider.gameObject.GetComponent<EntityHealth>().Damage(attackDamage);
        }

        attackTimeCounter = Time.time;

    }

    /*    private void attack() 
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

            Debug.Log(hits.Length);
            for (int i = 0; i < hits.Length; i++) 
            {
                hits[i].collider.gameObject.GetComponent<EntityHealth>().Damage(attackDamage);
            }

            attackTimeCounter = Time.time;
        }*/

    /*    private void OnDrawGizmosSelected() {
            //Gizmos.draww
        }*/
}
