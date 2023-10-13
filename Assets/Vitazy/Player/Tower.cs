using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public float attackRadius;

    public virtual void Shoot()
    {
        // Реализация стрельбы общая для всех турелей
    }
}

