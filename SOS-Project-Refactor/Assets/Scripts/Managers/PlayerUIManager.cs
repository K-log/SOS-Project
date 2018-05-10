using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : PlayerManager {
    
    public float maxMana = 100f;
    public static float currMana = 100f;
    public float maxHealth = 100f;
    public static float currHealth = 100f;
    public Vector3 originPos;

    void Start () {
    }
	
	void Update () {
        if (currHealth < 0) {
            Debug.Log("DEAD");
        }
	}

    public static void ManaUpdate(float m) {
        currMana += m;
        return;
    }

    public static void HealthUpdate(float h) {
        currHealth += h;
        return;
    }
}
