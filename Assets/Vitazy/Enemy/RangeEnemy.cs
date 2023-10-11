using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy, IDamageble
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Gun gun;

    public override void Takedamage()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        gun.Shoot(this.gameObject, bulletSpawn);
    }
}
