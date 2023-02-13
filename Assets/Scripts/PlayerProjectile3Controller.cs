using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile3Controller : PlayerProjectileInterface
{
    //vector corresponding to direct circular travel
    Vector2 potentialDirection;
    //values used to calculate products
    Vector2 positionDiff;
    void Start()
    {
        //start off slower
        initialSpeed = 4f;
        base.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //circle around mouse on right click
        if (Input.GetMouseButton(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //finding perpendicular velocity
            //TODO: CASE WHERE MOUSE DOENS"T MOVE
            positionDiff = new Vector2(transform.position.x - mousePosition.x,
                transform.position.y - mousePosition.y).normalized;
            potentialDirection = direction
                - Vector2.Dot(positionDiff, direction) *positionDiff;

            //speeding up
            initialSpeed = Mathf.Min(initialSpeed + 8f*Time.deltaTime, 20f);

            //change direction
            projectileRb.velocity = potentialDirection * initialSpeed;
            
        }
    }
}
