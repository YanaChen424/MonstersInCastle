using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePotion : Potion
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void HpInc(GameObject gameObject)
    {
        gameObject.GetComponent<Enemy>().healthPoint += 20;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanTakePotion(collision.gameObject))
        {
            HpInc(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected override bool CanTakePotion(GameObject gameObject)
    {
        if (gameObject.transform.tag == "Enemy")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
