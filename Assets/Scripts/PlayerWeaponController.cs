using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAnimation(float mouseAngle) {

        transform.rotation = Quaternion.Euler(Vector3.forward * -mouseAngle);
    }
}