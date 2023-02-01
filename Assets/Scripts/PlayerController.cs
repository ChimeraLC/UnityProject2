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
    public GameObject projectile;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = transform.GetChild(0).GetComponent<PlayerSpriteController>();
        playerWeapon = transform.GetChild(0).transform.Find("PlayerWeaponController").GetComponent<PlayerWeaponController>();
    }

    // Update is called once per frame
    void Update()
    {   
        /*
         * inputs
         */

        //keyboard

        //mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseAngle = Mathf.Atan2(mousePosition.x-transform.position.x, mousePosition.y-transform.position.y) * Mathf.Rad2Deg;

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
        playerSprite.UpdateAnimation(mouseAngle, moveDir.magnitude>0);
        //calling weapon child
        playerWeapon.UpdateAnimation(mouseAngle);

        /*
         * attack control
         */
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            //update position of weapon
            playerWeapon.flipAngle();
        }
    }
}
