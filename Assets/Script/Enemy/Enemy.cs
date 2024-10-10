using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float HP;
    public float damage;
    public float speed;
    public float shootDelay;
    public float shootTimer;
    public Vector3 direction;
    public float enemyDamage = 1f;

    public virtual void takeDamage()
    {
        
    }

    public virtual void followTarget()
    {
        direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public virtual void Attack()
    {

    }
    public virtual void GetDamage()
    {
        HP -= enemyDamage;
    }
}
