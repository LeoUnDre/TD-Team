using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]public GameObject objbullet;

    public GameObject objclone;
    public int power = 1000;

    private float shootCooldow;
    private float bossCooldown;
    private float enemyCooldown;
    private float startShootCooldown = 2f;

    public void Shoot(GameObject types, Transform bulletSpawner)
    {
        if (types.GetComponent<TowerControl>() != null)
        {
            objbullet.GetComponent<Bullet>().damage = types.GetComponent<TowerControl>().damage;
            objbullet.GetComponent<Bullet>().isEnemy = false;
            Ray ray = new Ray(bulletSpawner.position, bulletSpawner.forward);
            RaycastHit hit;
            float shootdistance = 100f;
            if (Physics.Raycast(ray, out hit, shootdistance))
                shootdistance = hit.distance;

            objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
            objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
            Destroy(objclone, 10);

            Debug.DrawRay(ray.origin, ray.direction * shootdistance, Color.blue, 1);
        }
        else if(types.GetComponent<Autoturell>() != null)
        {
            if (shootCooldow <= 0)
            {
                objbullet.GetComponent<Bullet>().damage = types.GetComponent<Autoturell>().damage;
                objbullet.GetComponent<Bullet>().isEnemy = false;
                objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
                objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
                Destroy(objclone, 10);
                shootCooldow = startShootCooldown;
            }
            shootCooldow -= Time.deltaTime;
        }

        else if (types.GetComponent<BossEnemy>()) 
        {
            if (bossCooldown <= 0)
            {
                objbullet.GetComponent<Bullet>().damage = types.GetComponent<BossEnemy>().Damage;
                objbullet.GetComponent<Bullet>().isEnemy = true;
                objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
                objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
                Destroy(objclone, 10);
                bossCooldown = startShootCooldown;
            }
        }
        else if (types.GetComponent<RangeEnemy>() != null)
        {
            if (shootCooldow <= 0)
            {
                objbullet.GetComponent<Bullet>().damage = types.GetComponent<RangeEnemy>().Damage;
                objbullet.GetComponent<Bullet>().isEnemy = true;
                objclone = Instantiate(objbullet, bulletSpawner.position, Quaternion.identity);
                objclone.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * power);
                Destroy(objclone, 10);
                enemyCooldown = startShootCooldown;
            }

            enemyCooldown -= Time.deltaTime;
        }


    }
}
