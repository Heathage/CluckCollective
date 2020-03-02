using UnityEngine.UI;
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
    [SerializeField]
    private Image image;

    private void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckHealth();
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
    private void CheckHealth()
    {
        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
        else if(currentHealth >= 0 & currentHealth <= 25)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, .7f);
        }
        else if (currentHealth > 25 & currentHealth <= 50)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, .5f);
        }
        else if (currentHealth > 50 & currentHealth <= 75)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, .2f);
        }
        else if (currentHealth > 75 & currentHealth <= 100)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }

    }
}
