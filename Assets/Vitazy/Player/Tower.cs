using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDamageble
{
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Damage { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        Damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
