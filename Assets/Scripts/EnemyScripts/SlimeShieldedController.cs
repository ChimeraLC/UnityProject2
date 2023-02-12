using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShieldedController : SlimeController
{
    protected SlimeShieldController shield;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        shield = transform.GetChild(1).GetComponent<SlimeShieldController>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //update shield direction
        if (state == 0)
        {
            shield.Look(playerDirection);
        }
    }
}
