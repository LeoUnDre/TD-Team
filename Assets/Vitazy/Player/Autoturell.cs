using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoturell : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] public GameObject owner;
    [SerializeField] public GameObject ownerSpawn;
    [SerializeField] private int level = 1;
    [SerializeField] public GameObject[] LevelPrefab;
    [SerializeField] public int numTurrel;
    public GameObject target = null;
    public int damage;

    [SerializeField] public GameObject[] LevelPrefabs;


    public int Level
    {
        get { return level; }
    }


    private void Start()
    {
        damage = 25;
        bulletSpawn.transform.rotation = this.transform.rotation;
        transform.position = ownerSpawn.transform.position;
        transform.rotation = ownerSpawn.transform.rotation;
    }





    private void Update()
    {
        transform.position = ownerSpawn.transform.position;
        transform.rotation = ownerSpawn.transform.rotation;
        if (target != null)
        {
            if (target.GetComponent<MeleeEnemy>() != null)
            {
                Vector3 lookDir = target.GetComponent<Transform>().position;

                gun.GetComponent<Gun>().Shoot(this.gameObject, bulletSpawn);

                Debug.Log(lookDir);
            }
            else if (target.GetComponent<RangeEnemy>() != null)
            {

            }
        }
    }

    public void LevelUp()
    {
        if (level < LevelPrefabs.Length)
        {
            GameObject newTurret = Instantiate(LevelPrefabs[level + 1], transform.position, transform.rotation);
            Autoturell newTurretComponent = newTurret.GetComponent<Autoturell>();
            newTurretComponent.owner = owner;
            newTurretComponent.ownerSpawn = ownerSpawn;
            newTurretComponent.level += 1;
            newTurretComponent.LevelPrefabs = LevelPrefabs;
            SetSelectedTurret(newTurretComponent);
            this.gameObject.SetActive(false);

        }
    }

    public void SetSelectedTurret(Autoturell turret)
    {
        owner.GetComponent<ExManager>().selectedTurret = turret;
        Debug.Log(turret);
    }
}