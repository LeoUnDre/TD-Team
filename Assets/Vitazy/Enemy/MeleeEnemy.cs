using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy, IDamageble
{
    NavMeshAgent m_navMeshAgent;

    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Damage { get; set; }

    public int Exp { get; set; }

    void Start()
    {
        Exp = 5;
        MaxHP = 60;
        HP = MaxHP;
        Damage = 5;
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            m_navMeshAgent.SetDestination(player.transform.position);
            if (HP <= 0)
            {
                SetExp();
                Destroy(this.gameObject);
            }
            if (player.GetComponent<ExManager>().isNewLevel)
            {
                MaxHP += 10;
                Damage += 5;
            }
            if (player.GetComponent<ExManager>().isNewLevel)
            {
                MaxHP += 10;
                Damage += 5;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TowerControl tw = collision.collider.GetComponent<TowerControl>();
        if (tw != null)
        {
            tw.Takedamage(Damage);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Autoturell>() != null)
        {
            other.GetComponent<Autoturell>().target = this.gameObject;
            Debug.Log("XYI");
        }
    }


    public override void Takedamage(int damage)
    {
        HP -= damage;
        Debug.Log(HP);
        Debug.Log(damage);
    }

    public void SetExp()
    {
        player.GetComponent<ExManager>().SetXp(xp: Exp);
    }
}