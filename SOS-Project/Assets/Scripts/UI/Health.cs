using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : PlayerUIManager {
    Image healthbar;

    void Start() {
        healthbar = GetComponent<Image>();
    }

    void Update() {
        healthbar.fillAmount = currHealth / maxHealth;
    }
}
