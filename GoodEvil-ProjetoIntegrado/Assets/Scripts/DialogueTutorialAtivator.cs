using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTutorialAtivator : MonoBehaviour
{
    public GameObject DialogueAtivator1;
    public GameObject DialogueAtivator2;
    public int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire"))
        {
            if (contador == 0)
            {
                DialogueAtivator1.SetActive(true);
                contador++;
            }
        }
        else if (other.CompareTag("BigFire"))
        {
            if (contador == 1)
            {
                DialogueAtivator2.SetActive(true);
            }
        }
    }
}
