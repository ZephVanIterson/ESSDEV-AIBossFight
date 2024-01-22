using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public Transform attackTransform;
    public LayerMask attackableLayer;

    public float attackDamage = 10;
    public float attackRange = 1; //Greater than min_distance

    public KeyCode attackKey;
    private float attackTimeCounter = 0;
    public float timeBetweenAttacks = 1;

    private RaycastHit2D[] hits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackKey)) {
            if(Time.time - attackTimeCounter >= timeBetweenAttacks) {
                attack();
            }
        }
    }

    private void attack() 
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

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
