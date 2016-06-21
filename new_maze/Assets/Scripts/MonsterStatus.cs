using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	private int _health = 100;
	private int _damage = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_health < 1) {
			this.gameObject.SetActive (false);
		}
	}

	public void HealthDecrease() {
		_health = _health - _damage;
	}
}
