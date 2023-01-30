using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile1Controller : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    private BoxCollider2D projectileBc;
    private Vector2 mousePosition;
    private float initialSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //initial movement
        projectileBc = GetComponent<BoxCollider2D>();
        projectileRb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        projectileRb.AddForce((mousePosition - (Vector2)transform.position).normalized * initialSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hello");
        //colliding with walls
        if (collision.gameObject.CompareTag("Wall")) Destroy(this.gameObject);
    }
}
