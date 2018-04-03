using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWand : Collectible {

    public int itemID = 1;

    protected override void OnCollect(GameObject target) {
        Equip equipBehavior = target.GetComponent<Equip>();
        if (equipBehavior != null) {
            equipBehavior.currentItem = itemID;
        }
    }
}
