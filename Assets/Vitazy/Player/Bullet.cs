using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public ParticleSystem hitParticle;
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
            collision.collider.gameObject.GetComponent<TowerControl>().Takedamage(damage);
            Instantiate(hitParticle, collision.contacts[0].point, Quaternion.identity);
            hitParticle.Play();
            Destroy(this.gameObject);


        }
        else if (!isEnemy)
        {
            if (collision.collider.gameObject.TryGetComponent<RangeEnemy>(out RangeEnemy enemy))
            {
                enemy.Takedamage(damage);
                Instantiate(hitParticle, collision.contacts[0].point, Quaternion.identity);
                hitParticle.Play();
                Destroy(this.gameObject);
            }
            else if (collision.collider.TryGetComponent<MeleeEnemy>(out MeleeEnemy meleeEnemy))
            {
                meleeEnemy.Takedamage(damage);
                Instantiate(hitParticle, collision.contacts[0].point, Quaternion.identity);
                hitParticle.Play();
                Destroy(this.gameObject);

            }
        }
    }
}