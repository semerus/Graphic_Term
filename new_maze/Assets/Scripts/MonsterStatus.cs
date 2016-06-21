using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	BattleManager battle;
	ProgressManager progress;

	private int _health = 100;
	private int _damage = 50;
	// Use this for initialization
	void Start () {
		battle = GameObject.Find("BattleManager").GetComponent<BattleManager>();
		progress = GameObject.Find ("ProgressManager").GetComponent<ProgressManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_health < 1) {
			this.gameObject.SetActive (false);
			if (battle.AddDeadMonster ()) {
				battle.PartReload ();
				progress.instruction.playerStatus = ProgressManager.CHOOSING;
			}
		}
	}

	public void HealthDecrease() {
		_health = _health - _damage;
	}
}
