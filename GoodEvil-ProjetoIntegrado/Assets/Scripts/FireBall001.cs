using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall001 : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    public int speed = 5;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction.x = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        Debug.Log(otherTag);
        switch (otherTag)
        {
            case "Enemy":
                Debug.Log("Applying damge to Enemy");
                //other.gameObject.GetComponent<HealthManager>().ApplyDamage(damage);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
