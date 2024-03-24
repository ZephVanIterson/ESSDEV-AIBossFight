using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class AttackUI : MonoBehaviour
{
    public Image image;
    public KeyCode attackKey;
    public float cooldownTime;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float timeBetweenAttacks = Time.time - lastAttackTime;
        if(Input.GetKeyDown(attackKey) && timeBetweenAttacks >= cooldownTime ) {
                image.fillAmount = 1;
                
                lastAttackTime = Time.time;
            }
            else if (timeBetweenAttacks <= cooldownTime ) {
                image.fillAmount = timeBetweenAttacks / cooldownTime;
            }
    }
}
