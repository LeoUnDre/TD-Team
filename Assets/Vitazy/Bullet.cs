using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnemy = false;
    public int damage = 0;
    private void OnTriggerEnter(Collider other)
    {

        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && !isEnemy)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.GetComponent<TowerControl>() && isEnemy)
        {
            Destroy(other.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<TowerControl>() != null && isEnemy)
        {
            int damage = GetComponent<MeleeEnemy>().Damage;
            collision.collider.gameObject.GetComponent<TowerControl>().Takedamage(damage);
            Destroy(this.gameObject);
        }
        else if ((collision.collider.gameObject.GetComponent<RangeEnemy>() != null
            || collision.collider.gameObject.GetComponent<MeleeEnemy>() != null)
            && !isEnemy)
        {
            collision.collider.gameObject.GetComponent<MeleeEnemy>().Takedamage(damage);
            Destroy(this.gameObject);
        }
    }
}