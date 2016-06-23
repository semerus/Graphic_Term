using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	BattleManager battle;
	ProgressManager progress;
	UImanager ui;
	GameObject ouch;

	private int _health = 100;
	private int _damage = 35;
	private float _nextAttack = 3f;
	private float _attackRate = 3f;
	private bool miss; //for later monster attack, misses first attack
	// Use this for initialization
	void Start () {
		battle = GameObject.Find("BattleManager").GetComponent<BattleManager>();
		progress = GameObject.Find ("ProgressManager").GetComponent<ProgressManager> ();
		ui = GameObject.Find ("UIManager").GetComponent<UImanager> ();
		ouch = this.transform.Find ("ouch").gameObject;

		ouch.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (progress.instruction.playerStatus == ProgressManager.BATTLING) {
			
			if (_health < 1) { // deactivate monster after death
				this.ouch.SetActive (false);
				this.gameObject.SetActive (false);
				if (battle.AddDeadMonster ()) {
					battle.ImageForReload ();
					progress.instruction.playerStatus = ProgressManager.CHOOSING;
					miss = false;
				}
			}
			if (Vector3.Distance (this.transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) < 2f) { //attack format of monster
				if (Time.time > _nextAttack) {
					if (miss == false) {
						_nextAttack = Time.time + _attackRate;
						miss = true;
					} else {
						_nextAttack = Time.time + _attackRate;
						PlayerAttack ();
					}
				}
			}
		}
	}

	public void HealthDecrease() {
		_health = _health - _damage;
		ouch.SetActive (true);
		StartCoroutine(WaitSecOuch());
	}

	IEnumerator WaitSecOuch () { //effect when player hits the monster
		yield return new WaitForSeconds (0.2f);
		ouch.SetActive (false);
	}

	public void PlayerAttack() { //attack player, effect, damage control
		ui.SetSlash ();
		battle.PlayerHpDecrease (5);
	}

	public void HealthFull () { //used when restarting the game
		_health = 100;
	}
}
