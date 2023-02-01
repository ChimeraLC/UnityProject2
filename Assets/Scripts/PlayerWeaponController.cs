using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private float extraAngle = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAnimation(float mouseAngle) {

        transform.rotation = Quaternion.Euler(Vector3.forward * (-mouseAngle + 45 + extraAngle));
    }

    public void flipAngle() {
        extraAngle *= -1;
    }
}
