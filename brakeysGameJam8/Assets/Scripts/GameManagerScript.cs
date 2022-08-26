using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public IEnumerator RestartScene()
    {
            yield return new WaitForSeconds(2f); // Set this time until the death animation is over
            SceneManager.LoadScene("GameScene");     
    }
}
