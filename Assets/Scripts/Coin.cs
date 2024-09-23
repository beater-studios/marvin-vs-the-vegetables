using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private GameController gc;

    void Start() {
        gc = FindObjectOfType<GameController>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gc.addCoins(1);
            Destroy(gameObject);
        }
    }

}
