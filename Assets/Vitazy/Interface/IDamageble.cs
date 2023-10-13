using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IDamageble
{
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Damage { get; set; }

    public int Exp { get; set; }


    public void Takedamage()
    {
        HP -= Damage;
    }

    public void SetEXp()
    {
    }
}