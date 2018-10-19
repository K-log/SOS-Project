using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall {

    public float slideVelocity = -3f;
    public float slideMultiplier = -3f;

    public GameObject dustPrefab;
    public float dustSpawnDelay = 0.5f;

    //private float timeElapsed = 0f;

	// Update is called once per frame
	override protected void Update () {
        base.Update();

        if (onWallDetected && !collisionState.standing) {
            float velY = slideVelocity;

            if (inputState.GetButtonValue(inputButtons[0])) {
                velY += slideMultiplier;
            }

            rb2d.velocity = new Vector2(rb2d.velocity.x, velY);

            /* Not used yet because of no dust prefab
            if (timeElapsed > dustSpawnDelay) {
                GameObject dust = Instantiate(dustPrefab);
                Vector2 pos = transform.position;
                pos.y += 2;
                dust.transform.position = pos;
                dust.transform.localScale = transform.localScale;
                timeElapsed = 0;

            }

            timeElapsed += Time.deltaTime;
            */
        }		
	}


    // Prevent the code from the base class from being run by overriding it.
    protected override void OnStick() {
        rb2d.velocity = Vector2.zero;
    }

    protected override void OffWall() {
        //timeElapsed = 0;
    }
}
