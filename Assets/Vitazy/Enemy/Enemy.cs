using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageble
{
    public GameObject player;

    public int HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Damage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public abstract void Takedamage();

}
