using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public GameObject placa;
    public GameObject DialogueBox;
    public bool trigger;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trigger == true)
        {
            if (placa.activeInHierarchy)
            {
                placa.SetActive(false);
            }
            else
            {
                placa.SetActive(true);
            }
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                DialogueBox.SetActive(true);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = false;
            placa.SetActive(false);
            DialogueBox.SetActive(false);
        }
    }
}
