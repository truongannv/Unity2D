using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    public Player player;
    public ShipAttack shipAttack;
    public GameObject explosion;
    void Awake()
    {
        moveSpeed = 7f;
        direction = new Vector3(0,2,0);
    }
    void Reset()
    {
        explosion = GameObject.Find("Explosion");
        GameObject playerObj = GameObject.Find("Player");
        player =  playerObj.GetComponent<Player>();
        GameObject shipObj = GameObject.Find("ShipAttack");
        shipAttack = shipObj.GetComponent<ShipAttack>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerObj = GameObject.Find("Player");
        player =  playerObj.GetComponent<Player>();
        player.enemyDamage = shipAttack.damage;
        if(other.gameObject.name == "Player")
        {
            Destroy();
            player.getDamage();
            GameObject newExplo = Instantiate(explosion,transform.position,Quaternion.identity);
            GameObject obj = GameObject.Find("Effect");
            newExplo.transform.parent = obj.transform;
            newExplo.SetActive(true);
            Destroy(newExplo,0.4f);
        }
    }
}
