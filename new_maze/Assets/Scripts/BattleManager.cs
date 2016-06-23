using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	GameObject crossarrow;
	ProgressManager progress;

	public float speed;
	private bool fireReady = true;
	private int bullet = 5;
	private int deadMonster = 0;
	private int playerHP = 100;

	GameObject bulletImg1; 
	GameObject bulletImg2; 
	GameObject bulletImg3; 
	GameObject bulletImg4; 
	GameObject bulletImg5; 

	Vector2 up = new Vector2(0f, 1f);
	Vector2 down = new Vector2(0f, -1f);
	Vector2 right = new Vector2(1f, 0f);
	Vector2 left = new Vector2(-1f, 0f);

	// Use this for initialization
	void Start () {
		crossarrow = GameObject.FindWithTag ("CrossArrow");
		crossarrow.gameObject.SetActive (false); //scrap plan
		progress = GameObject.Find ("ProgressManager").GetComponent<ProgressManager>();

		bulletImg1 = GameObject.Find ("Bullet1"); 
		bulletImg2 = GameObject.Find ("Bullet2");
		bulletImg3 = GameObject.Find ("Bullet3");
		bulletImg4 = GameObject.Find ("Bullet4");
		bulletImg5 = GameObject.Find ("Bullet5"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (progress.instruction.playerStatus == ProgressManager.BATTLING) {
			if (Input.touchCount > 0 && fireReady == true) { //mobile
				Debug.Log ("hit!");
				Vector2 pos = Input.GetTouch (0).position;
				Vector3 pos3 = new Vector3 (pos.x, pos.y, 0.0f);
				Ray ray = Camera.current.ScreenPointToRay (pos3);
				StartCoroutine (ShootByTouch (ray));
			}
			if (Input.GetKey ("c") && fireReady == true) { //computer for testing shoot with c
				Vector3 mousePos = Input.mousePosition;
				Ray ray2 = Camera.main.ScreenPointToRay (mousePos);
				StartCoroutine (ShootByMouse(ray2));
			}
			if (bullet < 1) {
				StartCoroutine (Reload ());
			}
		}
	}

	public IEnumerator ShootByTouch (Ray ray) {
		if (bullet > 0) {
			fireReady = false;
			GameObject bulletImg = GameObject.Find ("Bullet" + bullet);
			bulletImg.SetActive (false);
			bullet--;
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, 10f)) {
				Debug.Log ("info" + hitInfo.collider.name);
				if (hitInfo.collider.tag == "Monster") {
					GameObject target = GameObject.Find (hitInfo.collider.name);
					target.GetComponent<MonsterStatus> ().HealthDecrease ();
				}
			}
		}
		yield return new WaitForSeconds (1);
		this.fireReady = true;
	}

	public IEnumerator ShootByMouse (Ray ray2) {
		if (bullet > 0) {
			fireReady = false;
			GameObject bulletImg = GameObject.Find ("Bullet" + bullet);
			bulletImg.SetActive (false);
			bullet--;
			RaycastHit hitInfo2;
			if (Physics.Raycast (ray2, out hitInfo2, 10f)) {
				Debug.Log ("info" + hitInfo2.collider.name+"bullet"+this.bullet);
				if (hitInfo2.collider.tag == "Monster") {
					GameObject target = GameObject.Find (hitInfo2.collider.name);
					target.GetComponent<MonsterStatus> ().HealthDecrease ();				
				}
			}
		}
		yield return new WaitForSeconds (1);
		this.fireReady = true;
	}

	public IEnumerator Reload () { //timer for reload
		//Debug.Log ("Reloading");
		yield return new WaitForSeconds (2);
		ImageForReload ();
	}

	public void ImageForReload() { //load bullet images after reload
		bulletImg1.SetActive (true);
		bulletImg2.SetActive (true);
		bulletImg3.SetActive (true);
		bulletImg4.SetActive (true);
		bulletImg5.SetActive (true);
		bullet = 5;
	}

	public bool AddDeadMonster () { // 3 and up leads to true(passed stage)
		deadMonster += 1;
		if (deadMonster > 2) {
			deadMonster = 0;
			return true;
		}
		return false;
	}

	public void PlayerHpDecrease(int i) {
		playerHP += -i;
		if (playerHP < 1) {
			progress.SetState (14);
		}
	}

	public int SeePlayerHp() {
		return playerHP;
	}

	public void SetPlayerHp() {
		playerHP = 100;
	}
}
