using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	GameObject slash; // monster attack effect
	BattleManager battle;
	public Image imgHp;
	private int initHp;
	private int hp;
	// Use this for initialization
	void Start () {
		slash = GameObject.Find ("Slash");
		battle = GameObject.Find ("BattleManager").GetComponent<BattleManager> ();

		initHp = 100;
		slash.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		hp = battle.SeePlayerHp();
		imgHp.fillAmount = (float)hp / (float)initHp;
	}

	public void SetSlash () { // create monster attack effect
		slash.SetActive (true);
		StartCoroutine (WaitSecDisappear());
	}

	IEnumerator WaitSecDisappear() { // erase monster attack effect
		yield return new WaitForSeconds (0.7f);
		slash.SetActive (false);
	}
}
