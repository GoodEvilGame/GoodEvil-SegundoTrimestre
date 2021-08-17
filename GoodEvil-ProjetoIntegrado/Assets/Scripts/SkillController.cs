using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public string facing;

    public HealthManager healthManager;
    public GameObject fireBallSmall;
    public GameObject fireBallBig;
    public Vector2 skillDirection;
    private Vector3 pos;
    public List<string> listAllies = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        listAllies.Add(gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        //Escuta as teclas vinculada a cada skill
        if (Input.GetKeyDown(KeyCode.Mouse0)) InstanciateSkill(fireBallSmall);
        if (Input.GetKeyDown(KeyCode.Mouse1)) InstanciateSkill(fireBallBig);
        if (Input.GetKeyDown(KeyCode.Alpha1)) healthManager.Heal(20);
    }

    void InstanciateSkill(GameObject skillPrefab)
    {
        //Pega a mana da skill
        int manaCost = skillPrefab.GetComponent<skill>().manaCost;

        //Tenta reduzir a mana, se o valor do custo de mana da skill for maior que a mana atual do jogador a sill nao sera instanciada
        try{
            healthManager.ReduceMana(manaCost);
        }
        catch(System.ArgumentException e)
        {
            Debug.Log(e.Message);
            return;
        }

        facing = gameObject.GetComponent<PlayerMovement>().facing;

        //Instancia com uma posição ajustada
        pos = CreateSkillPosition();
        GameObject skill = Instantiate(skillPrefab, pos, Quaternion.identity);

        //Move a skill com a direção que o player esta olhando
        skill.GetComponent<skill>().Init(skillDirection, listAllies);
    }

    Vector3 CreateSkillPosition()
    {
        Vector3 curPosition = transform.position;

        switch (facing)
        {
            case "up":
                skillDirection = new Vector2(0, 1);
                return curPosition + new Vector3(0,0.9f);

            case "down":
                skillDirection = new Vector2(0, -1);
                return curPosition + new Vector3(0,-1.2f);

            case "right":
                skillDirection = new Vector2(1, 0);
                return curPosition + new Vector3(1.1f,0);

            case "left":
                skillDirection = new Vector2(-1, 0);
                return curPosition + new Vector3(-1.05f,0);

            default:
                skillDirection = new Vector2(0, 1);
                return curPosition + new Vector3(1, 0);
        }
    }

}
