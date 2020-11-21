using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void secretLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
