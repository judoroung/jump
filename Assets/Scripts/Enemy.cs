using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public int health = 1000;
    public GameObject player;
    public float speed = 10.0f;
    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    public void TakeDamage(int damage) {
        health -= damage;

    }
    public void die() {
        if (isBoss) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Destroy(gameObject);
    }
}
