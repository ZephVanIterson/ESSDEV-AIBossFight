using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{    
    public float health;
    private float initialHealth;
    public KeyCode damageKey;
    private float length; //Intial length of the health bar
    private RectTransform size; //Used to access dimensions and positioning information
    public GameObject damageTaken; //Holds prefab for damage bars when health is lost

    private Queue<GameObject> damage;
    private float damageTime; //Keeps record of when damage occured

    // Start is called before the first frame update
    void Start()
    {
        //Set initial health before damage occurs
        initialHealth = health;

        size = this.GetComponent<RectTransform>();
        length = size.sizeDelta.x;
        damage = new Queue<GameObject>();

        //No damage has occured, so ensure damageTime is always greater than Time.time until damage takes place
        damageTime = float.PositiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {
        //Test damage
        if(Input.GetKeyUp(damageKey)) {
            health -= Random.Range(1, 20);
            health = health < 0 ? 0 : health;
            updateHealth();
        }
        //After an amount of time remove recent damage taken
        if(damage.Count != 0 && Time.time - damageTime > 1) {
            while(damage.Count != 0) {
                Destroy(damage.Dequeue());
            }
        }

    }

    private void updateHealth() {
        float percentage = health/initialHealth;

        //Change in the size of the bar (used for length of damage bar)
        float healthChange = size.sizeDelta.x - (length * percentage);

        //Change length of the health bar to however much health is left
        size.sizeDelta = new Vector2(length * percentage , size.sizeDelta.y);

        //Keep health bar left justified
        size.localPosition = new Vector3(((length * percentage) - length) / 2, 0, 0);

        //Position of the damage bar (red bar)
        float x = size.localPosition.x + (size.sizeDelta.x / 2) + (healthChange / 2);

        //Create a damage bar
        GameObject currentDamage = Instantiate(damageTaken, transform.parent);

        //Position and 
        currentDamage.GetComponent<RectTransform>().localPosition = new Vector3(x, size.localPosition.y, 0);
        currentDamage.GetComponent<RectTransform>().sizeDelta = new Vector2(healthChange, size.sizeDelta.y);
        damage.Enqueue(currentDamage);

        damageTime = Time.time; //record time damage occured
    }
}
