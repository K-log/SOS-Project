using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    protected Camera _camera;
    protected GameObject bounds;
    public GameObject target;

	void Start () {
        _camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        _camera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
	}
}
