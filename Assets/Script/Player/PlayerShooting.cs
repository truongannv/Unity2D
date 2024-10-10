using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    public BulletPlayerPool bulletPlayerPool;
    public GameObject bulletPlayer;

    void Reset()
    {
        bulletPlayer = GameObject.Find("BulletPlayerPool");
        bulletPlayerPool = bulletPlayer.GetComponent<BulletPlayerPool>();
    }
    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;
        if(!Input.GetMouseButton(0)) return;
        if (shootTimer < shootDelay) return;
        Shooting();
        shootTimer = 0;
    }

    public void Shooting()
    {
        Transform bullet = bulletPlayerPool.getObject();
        bullet.position = transform.position;
        bullet.rotation = transform.rotation;
    }
}
