using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : Enemy
{
    public GameObject bulletEnemy;
    [SerializeField] private float safeDistance;
    public BulletEnemyPool bulletEnemyPool;

    void Reset()
    {
        shootDelay = 1f;
        shootTimer = 0f;
        safeDistance = 20f;
        speed = 7f;
        damage = 1f;
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        bulletEnemy = GameObject.Find("BulletEnemyPool");
        bulletEnemyPool = bulletEnemy.GetComponent<BulletEnemyPool>();
    }
    void Start()
    {
        HP = 10f;
        enemyDamage = 1f;
    }
    void FixedUpdate()
    {
        if(HP <= 0)
        {
            HP = 0;
            die();
        }
        followTarget();
    }
    public override void Attack()
    {
        Transform bullet = bulletEnemyPool.getObject();
        bullet.position = transform.position;
        bullet.rotation = transform.rotation;
        base.Attack();

    }
    public void die()
    {

        Destroy(gameObject);
    }

    public override void followTarget()
    {
        base.followTarget();
        shootTimer += Time.fixedDeltaTime;
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer > safeDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        if (shootTimer < shootDelay) return;
        if(distanceToPlayer < safeDistance) Attack();
        shootTimer = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "BulletPlayerPrefab(Clone)")
        {
            HP -= enemyDamage;
        }
    }
}
