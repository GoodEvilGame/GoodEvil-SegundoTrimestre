using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public float regenHealth = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        InvokeRepeating("Regenerate", 0.0f, 1/regenHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Regenerate()
    {
        if(curHealth < maxHealth )
        {
            curHealth++;
        }
    }

    public void Damage(int damage)
    {
        curHealth -= damage;

        if (Alive())
        {
            return;
        }

        NormalizeHealth();
    }

    public void Heal(int heal)
    {
        curHealth = maxHealth;

        NormalizeHealth();
    }

    public bool Alive()
    {
        if (curHealth > 0)
        {
            return true;
        }
        Dead();
        return false;
    }

    //Verify irregularities on curHealth;
    private void NormalizeHealth()
    {
        if(curHealth < 0)
        {
            curHealth = 0;
        }
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }

}
