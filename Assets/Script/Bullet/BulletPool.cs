using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Transform prefab;
    public int poolSize = 10;
    [SerializeField] private List<Transform> pool;
    protected string prefabName;

    void Awake()
    {
        CreatePool();
    }
    public virtual void CreatePool()
    {
        pool = new List<Transform>();   
        for(int i=0;i<=poolSize;i++)
        {
            Transform obj = Instantiate(prefab);
            obj.parent = transform;
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    public virtual Transform getObject()
    {
        foreach (Transform obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);  
                return obj;
            }
        }
        Transform newObj = Instantiate(prefab);
        newObj.parent = transform;
        newObj.gameObject.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
}
