using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EnemyScript : MonoBehaviour
{
    
    private float _startTime;
    private bool _mouseClicked, _previousMouseClicked;

    private Text _hpText;
    private Text _timeText;
    private BoxCollider2D _collider;
    
    private Animator _animator;
    private MainCharScript _mainCharScript;
    private ScoreScript _scoreScript;
    private EnemySpawnScript2 _spawnScript;

    
    public int hp;
    public int hitDamage;
    public int lifeTime = 10, remainingLifeTime = 10;
    public Transform hpDropTransform;

    void Awake()
    {
        _startTime = Time.time;
    }

    // Use this for initialization
    void Start()
    {
        _collider = GetComponentInChildren<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        _hpText = GetComponentsInChildren<Text>()
            .Single(t => t.name == "HPText");

        _timeText = GetComponentsInChildren<Text>()
            .Single(t => t.name == "TimeText");
        

        _scoreScript = GameObject.Find("ScoreText")
            .GetComponent<Text>()
            .GetComponent<ScoreScript>();

        _mainCharScript = GameObject.Find("Max")
            .GetComponent<MainCharScript>();

        _spawnScript = GameObject.Find("EnemySpawner2")
            .GetComponent<EnemySpawnScript2>();

        _hpText.text = hp.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero);
            _mouseClicked = hit.collider == _collider;

            if (hp > 0 && !_previousMouseClicked && _mouseClicked)
            {
                _mainCharScript.DoAttack();
                Instantiate(hpDropTransform, hit.point, Quaternion.identity);

                if (hp - hitDamage >= 0)
                {
                    hp -= hitDamage;
                }

                _animator.SetInteger("hp", hp);
                _animator.SetBool("damage", true);
            }
        }
        else
        {
            _mouseClicked = false;
        }

        _previousMouseClicked = _mouseClicked;

        remainingLifeTime = lifeTime - (int)(Time.time - _startTime);
        _hpText.text = hp.ToString();
        _timeText.text = remainingLifeTime.ToString();

        if (remainingLifeTime <= 0)
        {
            _animator.SetBool("attack", true);
            _mainCharScript.GetHit();
            RemoveFromScene();
        }
    }

    private void Die()
    {
        _scoreScript.score += 1000;
        RemoveFromScene();
    }

    private void RemoveFromScene()
    {
        Destroy(this.gameObject);
        _spawnScript.NotifyEnemyRemoved();
    }

    private void OnMouseDown()
    {
        _mouseClicked = true;
    }

    private void OnMouseUp()
    {
        _mouseClicked = false;
    }




}
