using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : EnemyParent
{
    // Start is called before the first frame update
    protected GameObject player;
    protected Vector2 playerDirection;
    protected Rigidbody2D enemyRb;
    protected SlimeEyeController eye;
    protected Animator enemyAnim;
    protected int enemyHp;
    protected int state;
    protected virtual void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        eye = transform.GetChild(0).GetComponent<SlimeEyeController>();
        enemyDamage = 2;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //find player location
        playerDirection = (player.transform.position - transform.position).normalized;

        /* States:
         * 0 - chase
         * 1 - hurt
         */
        if (state == 0)
        {
            //move towards player
            enemyRb.velocity = playerDirection;

            //update eye position
            eye.Look(playerDirection);
        }
    }
    //collision detection
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //collision with player projectile
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            enemyRb.velocity = collision.gameObject.GetComponent<PlayerProjectileInterface>().getDirection();
            Destroy(collision.gameObject);
            enemyAnim.SetInteger("state", 1);
            state = 1;
            //return to chase state after a certain time
            StartCoroutine(HurtTimer(0.75f));
        }
    }

    protected IEnumerator HurtTimer(float t)
    {
        yield return new WaitForSeconds(t);
        state = 0;
        enemyAnim.SetInteger("state", 0);
    }
}
