using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy, IDamageble
{
    [SerializeField] public GameObject player;
    private float speed = 5.0f;
    NavMeshAgent m_navMeshAgent;

    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Damage { get; set; }

    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        Damage = 50;
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            m_navMeshAgent.SetDestination(player.transform.position);
            if (HP == 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if(player == null)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TowerControl tw = collision.collider.GetComponent<TowerControl>();
        if(tw != null)
        {
            tw.Takedamage();
            Destroy(this.gameObject);
        }
    }

    public override void Takedamage()
    {
        HP -= Damage;
        if(HP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
