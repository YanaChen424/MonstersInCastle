using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] public float moveSpeed;
    public float healthPoint;
    [SerializeField] private float maxHealthPoint;

    public Transform target;
    [SerializeField] public float distance;
    private SpriteRenderer sp;

    public Image hpImage;
    public Image hpEffectImage;

    private void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        sp=GetComponent<SpriteRenderer>();
        Introuducting();
    }
    private void Update()
    {
        Move();
        TurnDirection();
        if(healthPoint<=0)
        {
            Death();
        }
        Attack();
        DisplayHpBar();
    }
    protected virtual void Introuducting()
    {
        Debug.Log("My Name is"+enemyName+",HP:"+healthPoint+",moveSpeed:"+moveSpeed);
    }
    protected virtual void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < distance)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            }
        }
        
    }
    private void TurnDirection()
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                sp.flipX = true;
            }
            else
            {
                sp.flipX = false;
            }
        }
    }
    protected virtual void Attack()
    {
        Debug.Log(enemyName + "is Attacking");
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    protected virtual void DisplayHpBar()
    {
        hpImage.fillAmount=healthPoint/maxHealthPoint;

        if(hpEffectImage.fillAmount>hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= 0.005f;
        }else
        {
            hpEffectImage.fillAmount= hpImage.fillAmount;
        }
    }
}
