using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitConfirmScript : MonoBehaviour {
    private float _startTime, _time;

	// Use this for initialization
	void Start () {

        _startTime = Time.time;
        _time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        _time = Time.time;
        if (_time - _startTime >= 0.1)
        {
            Destroy(gameObject);
        }
    }
}
