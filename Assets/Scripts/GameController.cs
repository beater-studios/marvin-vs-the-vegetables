using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int totalCoins;
    public Text coinText;

    public Image healthBar;

    void Start() {
        
    }

    void Update() {
        
    }

    public void addCoins(int coins) {
        this.totalCoins += coins;
        this.coinText.text = this.totalCoins.ToString();
    }

    public void LossHealth(float health) {
        this.healthBar.fillAmount = health / 10;
    }

}
