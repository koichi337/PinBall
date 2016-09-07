using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

	// このオブジェクトにアタッチしてあるHingeJointコンポーネントを入れる変数
	private HingeJoint myHingeJoynt;

	// 初期の傾き
	private float defaultAngle = 20.0f;
	// 弾いた時の傾き
	private float flickAngle = -20.0f;

	// スマホ用に画面の中心位置を取得
	float sPos = Screen.width / 2;


	void Start () {
		// 変数にこのオブジェクトのHingeJointコンポーネントを格納
		myHingeJoynt = GetComponent<HingeJoint>();

		// フリッパーの傾きを設定するために自作関数を呼び出す
		SetAngle(defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			SetAngle (defaultAngle);
		}

		// スマホ用のマルチタッチ処理-----------------------------------------
		foreach (Touch t in Input.touches) {
			// 画面左をタッチした場合の処理
			if (t.position.x < sPos && tag == "LeftFripperTag") {
				// タッチし続けている間の処理
				if (t.phase == TouchPhase.Stationary) {
					SetAngle (flickAngle);
				}
				// 指を離した時の処理
				if (t.phase == TouchPhase.Ended) {
					SetAngle (defaultAngle);
				}
			}
			// 画面右をタッチした場合の処理
			if (t.position.x > sPos && tag == "RightFripperTag") {
				// タッチし続けている間の処理
				if (t.phase == TouchPhase.Stationary) {
					SetAngle (flickAngle);
				}
				// 指を離した時の処理
				if (t.phase == TouchPhase.Ended) {
					SetAngle (defaultAngle);
				}
			}
		}
		// --------------------------------------------------------------------
	}

	public void SetAngle(float angle){
		// joinSpr変数でHingeJointコンポーネントのspringの値を弄れるようにし
		JointSpring jointSpr = myHingeJoynt.spring;
		// springの中のtargetPosition(バネの角度位置)に受け取った引数を入れ
		jointSpr.targetPosition = angle;
		// その角度を新たな値としてspringに設定しなおす
		myHingeJoynt.spring = jointSpr;
	}
}
