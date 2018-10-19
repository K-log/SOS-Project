using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {

        PlayerUIManager.HealthUpdate(-5f);
    }
}
