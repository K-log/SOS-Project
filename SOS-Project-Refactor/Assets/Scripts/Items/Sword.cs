using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Collectible {

    public int itemID = 1;

    override protected void OnCollect(GameObject target) {

        var equipBehavior = target.GetComponent<Equip>();
        if (equipBehavior != null) {
            equipBehavior.currentItem = itemID;
        }

    }
}
