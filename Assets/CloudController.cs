using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	// 最小サイズ
	private float minimum = 1.0f;
	// 拡大スピード
	private float magSpeed = 10.0f;
	// 拡大率
	private float magnification = 0.07f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 雲を拡大縮小
		transform.localScale =  new Vector3(minimum + Mathf.Sin(Time.time * magSpeed) * magnification, transform.localScale.y, minimum + Mathf.Sin(Time.time * magSpeed) * magnification);
	}
}
