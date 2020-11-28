using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            Shoot();
        }   
    }

    void Shoot() {
        RaycastHit2D hitInfo =  Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo) {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (enemy.health <= 0) {
                    enemy.die();
                }
            }
        }
    }
}
