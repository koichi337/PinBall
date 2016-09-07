using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	private float rotSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		// 回転を開始する角度を設定
		transform.Rotate(0, Random.Range(0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotSpeed, 0);
	}
}
