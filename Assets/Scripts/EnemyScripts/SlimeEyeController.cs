using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEyeController : MonoBehaviour
{
    private Vector2 playerDirection;
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
        transform.localPosition = new Vector2(playerDirection.x * 0.25f, playerDirection.y * 0.1f - 0.225f);

    }
}
