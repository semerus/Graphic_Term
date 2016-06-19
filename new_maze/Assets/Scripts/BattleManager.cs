using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	GameObject crossarrow;
	public float speed;
	Vector2 up = new Vector2(0f, 1f);
	Vector2 down = new Vector2(0f, -1f);
	Vector2 right = new Vector2(1f, 0f);
	Vector2 left = new Vector2(-1f, 0f);
	// Use this for initialization
	void Start () {
		crossarrow = GameObject.FindWithTag ("CrossArrow");
		crossarrow.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up"))
			crossarrow.GetComponent<RectTransform> ().anchoredPosition += up * speed;
		if (Input.GetKey ("down"))
			crossarrow.GetComponent<RectTransform> ().anchoredPosition += down * speed;
		if (Input.GetKey ("right"))
			crossarrow.GetComponent<RectTransform> ().anchoredPosition += right * speed;
		if (Input.GetKey ("left"))
			crossarrow.GetComponent<RectTransform> ().anchoredPosition += left * speed;
		if (Input.GetKey ("c")) {
			Debug.Log ("hit!");
			//Vector3 aim = Vector2 (crossarrow.GetComponent<RectTransform> ().anchoredPosition);
			//Vector2 aim = Camera.current.WorldToScreenPoint(crossarrow.GetComponent<RectTransform> ().anchoredPosition);
			//Ray ray = Camera.main.ScreenPointToRay (crossarrow.);
			//Ray ray = crossarrow.GetComponent<RectTransform> ().anchoredPosition;
			Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
			//Ray ray = Camera.current.ScreenPointToRay(crossarrow.GetComponent<RectTransform> ().anchoredPosition);
			RaycastHit hitInfo;
			if(Physics.Raycast (ray, out hitInfo, 10f)) {
				Debug.DrawRay (ray.origin, ray.direction * 10, Color.green);
				Debug.Log ("info" + hitInfo.collider.name);
				if (hitInfo.collider.tag == "Monster") {
					GameObject target = GameObject.Find (hitInfo.collider.name);
					target.gameObject.SetActive (false);
				}
			}
		}
	}
}
