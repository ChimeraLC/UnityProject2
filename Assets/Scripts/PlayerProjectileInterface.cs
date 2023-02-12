using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerProjectileInterface : MonoBehaviour
{
    protected Rigidbody2D projectileRb;
    protected BoxCollider2D projectileBc;
    protected Vector2 mousePosition;
    protected float initialSpeed = 7.5f;
    protected Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
    }
    //runs start method for heirarchy
    protected void initialize()
    {
        //initial movement
        projectileBc = GetComponent<BoxCollider2D>();
        projectileRb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        projectileRb.AddForce(direction * initialSpeed, ForceMode2D.Impulse);

    }

    //return the direction the projectile is going
    public Vector2 getDirection()
    {
        return direction;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //colliding with walls
        if (collision.gameObject.CompareTag("VWall") || collision.gameObject.CompareTag("HWall")
            || collision.gameObject.CompareTag("EnemyShield")) Destroy(this.gameObject);


    }

    private void FixedUpdate()
    {
        direction = projectileRb.velocity.normalized;
    }
}
