using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {
    private float _time0, _time1;

    public GameObject enemy;
    public float spanInterval = 0.5f;
	// Use this for initialization
	void Start () {
        _time0 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        _time1 = Time.time;
        
        if (_time1 - _time0 >= spanInterval)
        {
            var cam = Camera.main;
            var hHeight = cam.orthographicSize;
            var hWidth = hHeight * cam.aspect;

            var vector2 = new Vector2(Random.Range(-hWidth/2, hWidth), Random.Range(-hHeight, hHeight));

            Instantiate(enemy, vector2, Quaternion.identity);

            _time0 = _time1;
        }
	}
}
