﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
    public int maxShots = 10;
    private int leftShots;
    LineRenderer lineRender;
    // Start is called before the first frame update
    void Start(){
        leftShots = maxShots;
        lineRender = gameObject.GetComponentInParent<GunHolder>().linerenderer;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && leftShots > 0) {
            Shoot();
            leftShots--;
        }
        if ((leftShots == 0 && Input.GetButton("Fire1")) || Input.GetButtonDown("Fire3")){
            StartCoroutine( reload());
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
            lineRender.SetPosition(0, firePoint.localPosition);
            lineRender.SetPosition(1, hitInfo.transform.localPosition);
        }
        else{
            lineRender.SetPosition(0, firePoint.localPosition);
            lineRender.SetPosition(1, firePoint.position + firePoint.right * 1000);
            lineRender.SetPosition(0, firePoint.position);
            lineRender.SetPosition(1, firePoint.position + firePoint.right * 1000000);
        }
        
    }
    void Die(){
        Destroy(gameObject);
    }
    IEnumerator reload(){
        yield return new WaitForSeconds(3);
        leftShots = maxShots;
    }
}
