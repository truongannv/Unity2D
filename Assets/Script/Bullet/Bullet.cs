using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
      [SerializeField] protected float moveSpeed;
      [SerializeField] protected Vector3 direction;

      void FixedUpdate()
      {
            Despawn();
            Move();
      }

      public void Despawn()
      {
            if(Mathf.Abs(transform.position.y) >= 100f || Mathf.Abs(transform.position.x) >= 100f)
            {
                  transform.gameObject.SetActive(false);
            }
      }

      public void Move()
      {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
      }

      public void Destroy()
      {
            transform.gameObject.SetActive(false);
      }
}
