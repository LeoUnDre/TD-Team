using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnemy = false;
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
        if(collision.collider.gameObject.GetComponent<TowerControl>() != null && isEnemy)
        {
            collision.collider.gameObject.GetComponent<TowerControl>().Takedamage();
            Destroy(this.gameObject);
            Debug.Log("Gyra");
        }
        else if(collision.collider.gameObject.GetComponent<Enemy>() != null && !isEnemy)
        {
            Debug.Log("Nya");
            collision.collider.gameObject.GetComponent<Enemy>().Takedamage();
            Destroy(this.gameObject);
        }
    }
}
