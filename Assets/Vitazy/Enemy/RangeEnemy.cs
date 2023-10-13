using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour, IDamageble
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Gun gun;
    [SerializeField] public GameObject player;

    public int HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Damage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Exp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


    public void SetExp()
    {
        throw new System.NotImplementedException();
    }

    public void Takedamage()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        gun.Shoot(this.gameObject, bulletSpawn);
    }
}