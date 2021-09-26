using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageMove : MonoBehaviour {
	int[] posX = new int[] { 0, -18, -36, };
	int idx = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if (idx < posX.Length - 1) {
				idx++;
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if (idx > 0) {
				idx--;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX[idx], transform.position.y), 50 * Time.deltaTime);
		if (Input.GetKeyUp (KeyCode.Return)) {
			if (idx == 0) {
				SceneManager.LoadScene ("Level1");
			}
			if (idx == 1) {
				SceneManager.LoadScene ("Level2");
			}
			if (idx == 2) {
				SceneManager.LoadScene ("Level3");
			}
			}
	}
}
