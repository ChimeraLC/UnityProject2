using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    private SpriteRenderer playerSR;
    public Sprite[] animSprites;
    private int animationTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateAnimation(float mouseAngle, bool moving) {
        //direction looking
        playerSR.sprite = animSprites[(int)Math.Floor((mouseAngle + 202.5) / 45)];
        //movement animation
        if (moving)
        {
            animationTimer++;
            if (animationTimer >= 360) animationTimer -= 360;
        }
        else {
            animationTimer = Math.Max(0, animationTimer - 1);
            if (animationTimer == 180) animationTimer = 0;
        }
        transform.rotation = Quaternion.AngleAxis(10 * (float)Math.Sin(animationTimer * Math.PI / 180), Vector3.forward);
    }
}
