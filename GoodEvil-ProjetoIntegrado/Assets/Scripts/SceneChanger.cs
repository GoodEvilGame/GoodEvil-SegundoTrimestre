using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float timer = 5;

    void Update()
    {
        if(timer >= -1){ 
            timer -= Time.deltaTime;
             //Limita o contador até -1 para não sobrecarregar o sistema e desconta 1 por segundo na variável do contador
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Up")) 
        //Compara se o player colidiu com um objeto com tag "up"
        {
            if(timer <= 0){ 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
                //Se o tempo de espera do timer já acabou, carrega a próxima cena
            }
        }
        if(other.CompareTag("Back")) 
        //Compara se o player colidiu com um objeto com tag "back"
        {
            if(timer <= 0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + - 1);
                 //Se o tempo de espera do timer já acabou, carrega a cena anterior
            }
        }
    }
}