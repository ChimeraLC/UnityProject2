using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerSpriteController playerSprite;
    private PlayerWeaponController playerWeapon;
    private Rigidbody2D playerRb;
    private float speed = 5f;
    public GameObject[] projectiles;
    private float projectileIndex = 0f;
    private int state = 0;
    private bool canFire = true;
    private float weaponCooldown = 1f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = transform.GetChild(0).GetComponent<PlayerSpriteController>();
        playerWeapon = transform.GetChild(0).transform.Find("PlayerWeaponController").GetComponent<PlayerWeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*state control:
         * 0 - free
         * 1 - hurt
         * 
         */


        if (state == 0)
        {
            /*
             * inputs
             */

            //keyboard

            //mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseAngle = Mathf.Atan2(mousePosition.x - transform.position.x, 
                mousePosition.y - transform.position.y) * Mathf.Rad2Deg;
            
            /*
             * movement control
             */
            Vector2 moveDir = Vector2.zero;
            if (Input.GetKey(KeyCode.A)) moveDir.x -= 1;
            if (Input.GetKey(KeyCode.D)) moveDir.x += 1;
            if (Input.GetKey(KeyCode.W)) moveDir.y += 1;
            if (Input.GetKey(KeyCode.S)) moveDir.y -= 1;

            //normalize and move
            moveDir.Normalize();
            playerRb.velocity = speed * moveDir;

            /*
             * animation control
             */

            //calling sprite child
            playerSprite.UpdateAnimation(mouseAngle, moveDir.magnitude > 0);
            //calling weapon child
            playerWeapon.UpdateAnimation(mouseAngle);

            /*
             * attack control
             */
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                Instantiate(GetProjectile(), transform.position, GetProjectile().transform.rotation);
                //update position of weapon
                playerWeapon.flipAngle();
                StartCoroutine(ProjectileTimer(weaponCooldown));
            }
        }

        //swapping chosen projectile
        //TODO: clean this up
        projectileIndex += Input.mouseScrollDelta.y;
        if (projectileIndex >= projectiles.Length) projectileIndex -= projectiles.Length;
        if (projectileIndex < 0) projectileIndex += projectiles.Length;
        Debug.Log(projectileIndex);
    }
    //Getting currently selected projectile
    private GameObject GetProjectile() {
        return projectiles[(int)projectileIndex];
    }


    //timer for hurt state
    public IEnumerator HurtTimer(float t)
    {
        yield return new WaitForSeconds(t);
        state = 0;
    }

    //timer for projectile fire
    public IEnumerator ProjectileTimer(float t)
    {
        yield return new WaitForSeconds(t);
        canFire = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision with enemy
        if (collision.gameObject.CompareTag("Enemy")) {
            //grabbing stats of enemy
            EnemyParent enemyStats = collision.gameObject.GetComponent<EnemyParent>();
            Debug.Log(enemyStats.getDamage());
            state = 1;
            //knockback
            playerRb.velocity = (transform.position - collision.gameObject.transform.position)
                .normalized * enemyStats.getKnock();
            //hurtstate (TODO: implement different timers)
            StartCoroutine(HurtTimer(0.25f));
        }
    }
}
