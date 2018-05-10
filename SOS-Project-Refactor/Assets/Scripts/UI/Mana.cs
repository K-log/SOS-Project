using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : PlayerUIManager {

    Image manabar;

    void Start() {
        manabar = GetComponent<Image>();
    }

    void Update() {
        manabar.fillAmount = currMana / maxMana;
    }
}
