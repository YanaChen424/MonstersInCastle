using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] private string potionName;

    protected virtual bool CanTakePotion(GameObject gameObject)
    {
        return false;
    }
    protected virtual void HpInc(GameObject gameObject)
    {

    }
}
