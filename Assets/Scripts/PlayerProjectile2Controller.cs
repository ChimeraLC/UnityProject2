using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile2Controller : PlayerProjectileInterface
{
    // Start is called before the first frame update
    void Start()
    {
        base.initialize();
    }




    // Update is called once per frame
    void Update()
    {

    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //on collision with a wall, reverse the corresponding velocity direction
        if (collision.gameObject.CompareTag("VWall")) {
            projectileRb.velocity = new Vector2(-direction.x, direction.y) * initialSpeed;
        }
        if (collision.gameObject.CompareTag("HWall"))
        {
            projectileRb.velocity = new Vector2(direction.x, -direction.y) * initialSpeed; ;
        }
    }

}
