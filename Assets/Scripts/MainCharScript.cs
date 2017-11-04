using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharScript : MonoBehaviour {
    private int _hp = 1000;
    private Animator _animator;
    private Text _hpText;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _hpText = GetComponentInChildren<Text>();

        _animator.SetInteger("hp", _hp);
        _hpText.text = _hp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoAttack()
    {
        _animator.SetBool("attack", true);
    }

    public void GetHit()
    {
        if (_hp - 100 >= 0)
        {
            _hp -= 100;
        }
        _animator.SetInteger("hp", _hp);
        _animator.SetBool("damage", true);
        _hpText.text = _hp.ToString();
    }

    private void Die()
    {
        Debug.Log("E morreu.");
    }
}
