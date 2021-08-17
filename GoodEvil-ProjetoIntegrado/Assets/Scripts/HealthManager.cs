using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public float regenHealth = 0.5f;

    public int curMana;
    public int maxMana = 10;
    public float regenMana = 0.5f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        curMana = maxMana;
        InvokeRepeating("Regenerate", 0.0f, 1/regenHealth);
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
    }

    private void Regenerate()
    {
        if (curHealth < maxHealth) curHealth++;
        if (curMana < maxMana) curMana++;
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

    public void Heal(int value)
    {
        curHealth += value;
        anim.SetTrigger("heal");
        NormalizeHealth();
    }

    public void ReduceMana(int value)
    {
        if(curMana < value)
        {
            throw new System.ArgumentException("Mana value too high");
        }

        curMana -= value;
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
