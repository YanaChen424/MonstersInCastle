using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Witch : Enemy
{
    private float moveRate = 2.0f;
    private float moveTimer;

    private float shotRate = 2.1f;
    private float shotTimer;

    public GameObject fireBall;

    [SerializeField]private float minX, minY, maxX, maxY;
    protected override void Move()
    {
        //base.Move();
        RandomMove();

    }

    private void RandomMove()
    {
        moveTimer+=Time.deltaTime;

        if(moveTimer>moveRate)
        {
            transform.position=new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY),0);
            moveTimer = 0;
        }
    }

    protected override void Attack()
    {
        shotTimer+=Time.deltaTime;
        if(shotTimer>shotRate)
        {
            Instantiate(fireBall, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }
}
