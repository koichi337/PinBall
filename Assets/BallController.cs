using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// 得点用のUIテキストを格納する変数
	public GameObject scoreObj;

	// 得点を加算する変数(大きい星、小さい星、雲)
	private int scoreLs;
	private int scoreSs;
	private int scoreC;
	// 得点の合計を入れる変数
	private int scoreSum;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}

		// 得点の合計を計算して表示
		scoreSum = scoreLs + scoreSs + scoreC;
		scoreObj.GetComponent<Text> ().text = "Score: " + scoreSum;
	}

	void OnCollisionEnter(Collision col){
		// ボールが衝突したオブジェクトに応じて点数を加算
		if (col.gameObject.tag == "LargeStarTag") {
			// 大きい星は20点
			this.scoreLs += 20;
		} else if (col.gameObject.tag == "SmallStarTag") {
			// 小さい星は10点
			this.scoreSs += 10;
		} else if (col.gameObject.tag == "SmallCloudTag" || col.gameObject.tag == "LargeCloudTag") {
			// 雲は15点
			this.scoreC += 15;
		}
	}
}
