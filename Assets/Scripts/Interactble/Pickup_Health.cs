using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : Interactable
{
    public int healthAmount = 400;

    public override void Interaction()
    {
        GameManager.instance.player.health.IncreaseHealth(healthAmount);

        ObjectPool.instance.ReturnObject(gameObject);
    }
}
