using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] public float distance;
    [SerializeField] private float shotSpeed;

    [SerializeField] private float maxLife = 2.0f;
    private float lifeBtwTimer;
    public GameObject destoryEffect;


    private Transform targetPos;
    public GameObject[] Mobs;
    void Start()
    {
         Mobs=GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Mobs.Length; i++)
        {
            if (Mobs[i] != null)
            {
                if (Vector2.Distance(transform.position, Mobs[i].transform.position) < distance)
                {
                    targetPos = Mobs[i].transform;
                }
            }
        } 
     }


    // Update is called once per frame
    void Update()
    {

        if (targetPos != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.transform.position, shotSpeed * Time.deltaTime);
        }
        lifeBtwTimer += Time.deltaTime;
        if (lifeBtwTimer >= maxLife)
        {
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            print(other.gameObject.name);
            other.gameObject.GetComponent<Enemy>().healthPoint -= 10;
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
