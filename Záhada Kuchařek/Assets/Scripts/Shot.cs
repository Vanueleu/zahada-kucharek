using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}