using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector2 playerDirection;
    private Rigidbody2D enemyRb;
    private SlimeEyeController eye;
    private Animator enemyAnim;
    private int enemyHp;
    private int state;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        eye = transform.GetChild(0).GetComponent<SlimeEyeController>();
    }

    // Update is called once per frame
    void Update()
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision with player projectile
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            enemyRb.velocity = collision.gameObject.GetComponent<PlayerProjectile1Controller>().getDirection();
            Destroy(collision.gameObject);
            enemyAnim.SetInteger("state", 1);
            state = 1;
            //return to chase state after a certain time
            StartCoroutine(HurtTimer(1f));
        }
    }

    public IEnumerator HurtTimer(float t)
    {
        yield return new WaitForSeconds(t);
        state = 0;
        enemyAnim.SetInteger("state", 0);
    }
}
