using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void Level1() {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(1);
    }
    public void Level2() {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(2);
    }
    public void Level3() {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(3);
    }
    public void Level4() {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(4);
    }
}
