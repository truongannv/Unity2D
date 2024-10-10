using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPlayer : Bullet
{
    public Player player;
    public ShipAttack shipAttack;
    public GameObject explosion;
    void Awake()
    {
        moveSpeed = 10f;
        direction = new Vector3(0,7,0);
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
        if(other.gameObject.name == "ShipAttack(Clone)")
        {
            Destroy();
            GameObject newExplo = Instantiate(explosion,transform.position,Quaternion.identity);
            GameObject obj = GameObject.Find("Effect");
            newExplo.transform.parent = obj.transform;
            newExplo.SetActive(true);
            Destroy(newExplo,0.4f);
        }
    }
}
