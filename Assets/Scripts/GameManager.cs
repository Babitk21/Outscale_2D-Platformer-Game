using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayButtonPressed() {
        SceneManager.LoadScene(1);
    }
    public void QuitButtonPressed() {
        SceneManager.LoadScene(0);
    }
        
}
