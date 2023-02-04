using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector2 playerDirection;
    private Rigidbody2D enemyRb;
    private SlimeEyeController eye;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        eye = transform.GetChild(0).GetComponent<SlimeEyeController>();
    }

    // Update is called once per frame
    void Update()
    {
        //find player location
        playerDirection = (player.transform.position - transform.position).normalized;

        //move towards player

        enemyRb.velocity = playerDirection;

        //update eye position
        eye.Look(playerDirection);

    }
}
