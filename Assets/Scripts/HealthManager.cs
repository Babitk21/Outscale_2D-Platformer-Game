using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance {get; private set;}
    [SerializeField] public int health = 3;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    private void Awake() {
        if(instance == null) {instance = this; }
        else { Destroy(instance); }
    }
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0;i < health;i++) {
            hearts[i].sprite = fullHeart;
        }
    }
}
