using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    const string SPEED = "Speed";
    const string CROUCH = "Crouch";
    const string JUMP = "Jump";
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat(SPEED, Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0){
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
        Crouch();
        Jump(vertical);
    }
    private void Crouch() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            animator.SetBool(CROUCH, true);
        }
        else {
            animator.SetBool(CROUCH, false);
        }
    }
    private void Jump(float vertical) {
        if (vertical > 0) {
            Debug.Log("Here");
            animator.SetBool(JUMP, true);
        }
        else {
            animator.SetBool(JUMP, false);
        }
    }
}
