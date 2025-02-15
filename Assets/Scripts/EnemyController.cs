using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject pointA, pointB;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }
    private void Update() {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform) {
            rb.velocity = new Vector2(speed, 0);
        }
        else {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint ==  pointB.transform) {
            Flip();
            currentPoint = pointA.transform;    
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void Flip() {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
