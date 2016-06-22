using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	BattleManager battle;
	ProgressManager progress;

	private int _health = 100;
	private int _damage = 50;
	private float _nextAttack = 3f;
	private float _attackRate = 3f;
	private bool miss;
	// Use this for initialization
	void Start () {
		battle = GameObject.Find("BattleManager").GetComponent<BattleManager>();
		progress = GameObject.Find ("ProgressManager").GetComponent<ProgressManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (progress.instruction.playerStatus == ProgressManager.BATTLING) {
			
			if (_health < 1) {
				this.gameObject.SetActive (false);
				if (battle.AddDeadMonster ()) {
					battle.ImageForReload ();
					progress.instruction.playerStatus = ProgressManager.CHOOSING;
					miss = false;
				}
			}
			if (Vector3.Distance (this.transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) < 2f) {
				if (Time.time > _nextAttack) {
					if (miss == false) {
						_nextAttack = Time.time + _attackRate;
						miss = true;
					} else {
						_nextAttack = Time.time + _attackRate;
						PlayerAttack ();
						Debug.Log (battle.SeePlayerHp () + "time" + Time.time);
					}
				}
			}
		}
	}

	public void HealthDecrease() {
		_health = _health - _damage;
	}

	public void PlayerAttack() {
		
		battle.PlayerHpDecrease (20);
	}
}
