using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float hp;
    public float damage = 1f;
    public float enemyDamage;
    public float maxHP = 10f;
    public HP hP;

    void Start()
    {
        hp = maxHP;
        hP.updateHP(hp,maxHP);
    }

    void FixedUpdate()
    {
        if(hp<=0)
        {
            hp = 0;
            Die();
        }
    }
    public void Die()
    {
        transform.gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }

    public void getDamage()
    {
        hp -= enemyDamage;
        hP.updateHP(hp,maxHP);
    }
}
