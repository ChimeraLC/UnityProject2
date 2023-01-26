using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerSpriteController playerSprite;
    private Rigidbody2D playerRb;
    private float speed = 5f;
    public Sprite[] animSprites;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = transform.GetChild(0).GetComponent<PlayerSpriteController>();
    }

    // Update is called once per frame
    void Update()
    {   
        /*
         * inputs
         */

        //keyboard
        int leftKey = Input.GetKey(KeyCode.A) ? 1 : 0;
        int rightKey = Input.GetKey(KeyCode.D) ? 1 : 0;
        int upKey = Input.GetKey(KeyCode.W) ? 1 : 0;
        int downKey = Input.GetKey(KeyCode.S) ? 1 : 0;

        //mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseAngle = Mathf.Atan2(mousePosition.x-transform.position.x, mousePosition.y-transform.position.y) * Mathf.Rad2Deg;

        /*
         * movement control
         */
        Vector2 moveDir = Vector2.zero;
        moveDir.x = rightKey - leftKey;
        moveDir.y = upKey - downKey;
        //normalize and move
        moveDir.Normalize();
        playerRb.velocity = speed * moveDir;

        /*
         * animation control
         */

        //calling sprite child
        playerSprite.UpdateAnimation(mouseAngle, moveDir.magnitude>0);
    }
}
