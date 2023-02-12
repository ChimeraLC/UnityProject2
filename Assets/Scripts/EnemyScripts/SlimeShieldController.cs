using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlimeShieldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Look(Vector2 playerDirection)
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition,
        new Vector2(playerDirection.x * 0.25f, playerDirection.y * 0.1f - 0.225f), 0.05f);
        transform.up = Vector3.Lerp(transform.up, playerDirection, 0.05f);
    }
}
