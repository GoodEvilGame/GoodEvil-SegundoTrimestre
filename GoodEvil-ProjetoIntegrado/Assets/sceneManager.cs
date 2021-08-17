using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{

    public SkillController damakosSkillController;
    // Start is called before the first frame update
    void Start()
    {
           damakosSkillController.enabled = true;
           Debug.Log("Ligou script");
           gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
