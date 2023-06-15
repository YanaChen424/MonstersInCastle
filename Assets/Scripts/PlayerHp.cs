using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float healthPoint;
    [SerializeField] private float maxHealthPoint;

    public Image hpImage;
    public Image hpEffectImage;
    private void Start()
    {
        healthPoint = maxHealthPoint;
    }
    protected void DisplayHpBar()
    {
        hpImage.fillAmount = healthPoint / maxHealthPoint;

        if (hpEffectImage.fillAmount > hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= 0.005f;
        }
        else
        {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="FireBall")
        {
            healthPoint -= 10;
        }
    }
    private void Update()
    {
        if(healthPoint < 0)
        {
            Destroy(gameObject);
        }
        DisplayHpBar();
    }

}
