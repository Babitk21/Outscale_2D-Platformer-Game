using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private const string SPEED = "Speed";
    private const string CROUCH = "Crouch";
    private const string JUMP = "Jump";
    private const string DEAD = "Dead";

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] GameObject restartButton;
    
    Animator animator;
    Rigidbody2D rb;
    bool isGrounded;
    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }
    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Crouch();
        Jump();
        MoveHorizontal(horizontal);
        HorizontalAnim(horizontal);
    }
    public void PickUpKey() {
        scoreController.IncrementScore(10);
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
    private void Jump() {
        if (Input.GetAxisRaw("Jump") > 0 && isGrounded) {
            animator.SetBool(JUMP, true);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else {
            animator.SetBool(JUMP, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Ground")) {
            isGrounded = true;
        }
        else if(collision.transform.CompareTag("Finish")) {
            SceneManager.LoadScene(1);
        }
        else if(collision.transform.CompareTag("FallCollider")) {
            SceneManager.LoadScene(0);
        }
        else if(collision.gameObject.GetComponent<EnemyController>()) {
            HealthManager.instance.health--;
            if(HealthManager.instance.health <= 0) {
                animator.SetTrigger(DEAD);
                restartButton.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    }
}
