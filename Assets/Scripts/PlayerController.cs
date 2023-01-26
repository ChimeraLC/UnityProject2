using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSR;
    public Sprite[] animSprites;
    void Start()
    {
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseAngle = Mathf.Atan2(mousePosition.x-transform.position.x, mousePosition.y-transform.position.y) * Mathf.Rad2Deg;

        /*
         * animation control
         */

        //direction looking
        playerSR.sprite = animSprites[(int)Math.Floor((mouseAngle + 202.5) / 45)];
    }
}
