using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : AbstractBehavior
{

    private int _currentItem = 0;
    private Animator anim;

    public int currentItem {
        get { return _currentItem; }
        set {
            _currentItem = value;
            anim.SetInteger("EquippedItem", _currentItem);
        }
    }

    protected override void Awake() {
        base.Awake();
        anim = GetComponent<Animator>();
    }
}