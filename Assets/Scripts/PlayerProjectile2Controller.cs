using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile2Controller : PlayerProjectileInterface
{
    //number of bounces
    private int lifetime
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 2;
        base.initialize();
    }




    // Update is called once per frame
    void Update()
    {

    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //on collision with a wall, reverse the corresponding velocity direction
        if (collision.gameObject.CompareTag("VWall"))
        {
            if (lifetime-- <= 0) Destroy(this.gameObject);
            else projectileRb.velocity = new Vector2(-direction.x, direction.y) * initialSpeed;
        }
        if (collision.gameObject.CompareTag("HWall"))
        {
            if (lifetime-- <= 0) Destroy(this.gameObject);
            else projectileRb.velocity = new Vector2(direction.x, -direction.y) * initialSpeed;
        }

        //on collision with a enemy shield calculating bounce
        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            if (lifetime-- <= 0) Destroy(this.gameObject);
            else
            {
                float newAngle = 2 * angleGen(collision.gameObject.transform.up) - angleGen(-direction);
                projectileRb.velocity = new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle)) * initialSpeed;
            }
        }
    }
    //provides the angle corresponding to a direction
    private float angleGen(Vector2 direction) { 
        float angle = Mathf.Atan(direction.y / direction.x);
        if (direction.x < 0) angle+= Mathf.PI;
        return angle;
    }

}
