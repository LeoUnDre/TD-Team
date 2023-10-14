using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossEnemy : MonoBehaviour, IDamageble
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject gun;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject target;


    private bool isAttackPoint;


    NavMeshAgent m_navMeshAgent;

    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Damage { get; set; }
    public int Exp { get; set; }


    void Start()
    {
        MaxHP = 300;
        HP = MaxHP;

        Damage = 12;

        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void SetExp()
    {
        throw new System.NotImplementedException();
    }


    void Update()
    {

        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        if (player != null)
        {
            m_navMeshAgent.SetDestination(player.transform.position);
            transform.LookAt(player.transform.position);

            if (Vector3.Distance(transform.position, player.transform.position) < 20f)
            {
                m_navMeshAgent.Stop();
                isAttackPoint = true;
            }
        }
        else if (player == null)
        {
            Destroy(gameObject);
        }



        if (isAttackPoint && player != null)
        {
            transform.LookAt(player.transform.position);
            gun.GetComponent<Gun>().Shoot(this.gameObject, bulletSpawn);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void Takedamage(int damage)
    {
        HP -= damage;
        Debug.Log("Есть попадание");
    }
}