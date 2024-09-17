using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lobbyObject;
    public void PlayButtonPressed() {
        lobbyObject.SetActive(true);
        AudioManager.instance.Play("StartClick");
    }
    public void QuitButtonPressed() {
        SceneManager.LoadScene(0);
    }
    public void RestartButtonPressed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
}
