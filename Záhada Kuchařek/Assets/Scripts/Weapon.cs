using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    
    private void Update()
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
            }

            if(timeBtwShots <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
}
