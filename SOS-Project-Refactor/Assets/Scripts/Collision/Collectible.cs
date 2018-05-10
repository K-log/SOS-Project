using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public string targetTag = "Player";

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == targetTag) {
            OnCollect(target.gameObject);
            OnDestroy();
        }
    }

    protected virtual void OnCollect(GameObject target) {

    }

    protected virtual void OnDestroy() {
        Destroy(gameObject);
    }
}
