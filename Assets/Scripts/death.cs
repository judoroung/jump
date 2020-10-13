using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    GameObject border;
    public AudioClip deathSound;
    public AudioSource source;
    public player script;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.FindGameObjectWithTag("death");
        script = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == border) {
            StartCoroutine(deathSoundCou());
            
        }
    }
    IEnumerator deathSoundCou() {
        source.clip = deathSound;
        source.Play();
        script.enabled = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
