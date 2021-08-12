using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall001 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform trans;
    public Animator anim;
    public Vector2 direction;

    public int speed = 5;
    public int damage = 10;

    private bool _ready = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_ready) return;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); 
    }


    public void Init(Vector2 dir)
    {
        direction = dir;
        _ready = true;
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthManager otherHealth = other.gameObject.GetComponent<HealthManager>();

        if (!otherHealth) return;
        otherHealth.Damage(damage);

        Destroy(gameObject);
    }
}
