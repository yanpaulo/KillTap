using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawnScript2 : MonoBehaviour
{
    private int _enemyLifeTime = 10;
    private bool _enemyDead = true;
    private GameObject[] _enemies;

    // Use this for initialization
    void Start()
    {
        _enemies = Resources.LoadAll("")
            .Select(r => r as GameObject)
            .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyDead)
        {
            int n = Random.Range(0, _enemies.Length);
            var e = _enemies[n];
            e.GetComponent<EnemyScript>()
                .lifeTime = _enemyLifeTime;
            Instantiate(e, gameObject.transform.position, Quaternion.identity);
            _enemyDead = false;

            if (_enemyLifeTime >= 2)
            {
                _enemyLifeTime--;
            }
        }

        if (GameObject.Find("Max") == null)
        {
            enabled = false;
        }
        
    }

    public void NotifyEnemyRemoved()
    {
        _enemyDead = true;
    }
}
