using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    const string SPEED = "Speed";
    const string CROUCH = "Crouch";
    const string JUMP = "Jump";

    [SerializeField] private float speed;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Crouch();
        Jump(vertical);
        MoveHorizontal(horizontal);
        HorizontalAnim(horizontal);
    }
    private void HorizontalAnim(float horizontal) {
        animator.SetFloat(SPEED, Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0) {
            scale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = scale;
    }
    private void MoveHorizontal(float horizontal) {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
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
            animator.SetBool(JUMP, true);
        }
        else {
            animator.SetBool(JUMP, false);
        }
    }
}
