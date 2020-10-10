using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    GameObject border;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.FindGameObjectWithTag("death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == border) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
