using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    const string SPEED = "Speed";
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat(SPEED, Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0){
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
