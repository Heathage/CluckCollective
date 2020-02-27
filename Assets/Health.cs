using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float healthRegen;
    [SerializeField]
    private float regenTime;
    private float timeTillNextHeal;
    public float currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }

        if( timeTillNextHeal >= regenTime)
        {
            if(currentHealth < 100)
            {
                currentHealth += healthRegen;
            }
            else if(currentHealth >= health)
            {
                currentHealth = health;
            }
            timeTillNextHeal = 0f;
        }
        else
        {
            timeTillNextHeal += Time.deltaTime;
        }

    }
}
