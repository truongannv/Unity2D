using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 1f;
    [SerializeField] public float StopDistance = 3f;

    void Update()
    {
        Move();
        LookAtMouse();
    }

    public void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        float distance = Vector3.Distance(transform.parent.position, mousePosition);

        if (distance > StopDistance)
        {
            transform.parent.position = Vector3.Lerp(transform.parent.position, mousePosition, MoveSpeed * Time.deltaTime);
        }
    }
    public void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
    }
}
