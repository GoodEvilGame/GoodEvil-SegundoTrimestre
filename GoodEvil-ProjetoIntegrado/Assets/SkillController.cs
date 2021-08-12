using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public string facing;

    public int curSkillInvokes = 0;
    public int maxSkillInvokes = 1;
    public Vector2 skillDirection;
    public GameObject skillPrefab;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Get the abstract direction from Player movement scrpit
            facing = gameObject.GetComponent<PlayerMovement>().facing;

            //Get the vector3 position ajustment of this direction
            pos = CreateSkillPosition();

            // Instantiate at player position + ajust and direction by rotating the object.
            GameObject skill = Instantiate(skillPrefab, pos, Quaternion.identity);
            skill.GetComponent<FireBall001>().Init(skillDirection);
        }   
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
