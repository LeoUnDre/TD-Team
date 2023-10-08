using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Gun gun;

    private void Update()
    {
        gun.Shoot(this.gameObject, bulletSpawn);
    }
}
