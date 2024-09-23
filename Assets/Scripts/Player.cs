using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Components")]
    public Rigidbody2D rigidBody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private GameController gc;

    [Header("Stats")]
    public float speedWalk;    
    public float speedJump;
    public float health;
    
    bool isJumping;
    public bool isVulnerable;
    float direction;

    void Start() {
    }

    void Update() {
        gc = FindObjectOfType<GameController>();
        direction = Input.GetAxis("Horizontal");
        
        if (direction != 0) {
            this.transform.eulerAngles = new Vector2(0, direction > 0 ? 0 : 180);
            this.ChangeAnimation(1);
        } else {
            this.ChangeAnimation(0);
        }

        this.Jump();
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && this.isJumping == false) {
            this.rigidBody2D.AddForce(Vector2.up * this.speedJump, ForceMode2D.Impulse);
            this.ChangeAnimation(2);
            this.isJumping = true;
        }
    }

    private void FixedUpdate() {
        this.rigidBody2D.velocity = new Vector2(direction * this.speedWalk, this.rigidBody2D.velocity.y);
    }

    void ChangeAnimation(int state) {
        if (this.isJumping == false) {
            this.animator.SetInteger("transition", state);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            this.isJumping = false;
        }
    }

    public void HitPlayer(int hit) {
        if (isVulnerable == true) {
            this.health -= hit;
            gc.LossHealth(health);
            this.isVulnerable = false;
            StartCoroutine(this.Respawn());
        }
    }

    public float timeRespawn;
    IEnumerator Respawn() {
        for (float i = 0f; i < timeRespawn; i += 0.25f) {
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
            yield return new WaitForSeconds(0.25f);
        }
        this.spriteRenderer.enabled = true;
        this.isVulnerable = true;
    }

}
