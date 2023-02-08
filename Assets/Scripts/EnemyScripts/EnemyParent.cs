using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    protected int enemyDamage = 0;
    protected int knockSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //getting damage dealt
    public int getDamage() {
        return enemyDamage;
    }

    //getting knockback
    public int getKnock()
    {
        return knockSpeed;
    }
}
