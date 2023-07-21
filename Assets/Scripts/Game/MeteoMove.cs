using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MeteoMove : MonoBehaviour
{
    //スクリプトに格納するもの
    float fallSpeed; //隕石の落下速度
    float rotSpeed; //隕石の回転速度
    public static bool isClear = true; //クリアフラグ
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ

    void Start()
    {
        this.fallSpeed = 0.025f + 0.05f * Random.value; //落下速度をランダムに設定
        this.rotSpeed = 10f + 20f * Random.value; //回転速度をランダムに設定
        isClear = true; //クリアフラグを初期化。trueの状態に設定
        Invoke("HardMethod", 20.0f); //2秒後にディレイメソッドを実行
    }

    void Update()
    {
        transform.Translate(0, -fallSpeed, 0, Space.World); //隕石を下方向に移動
        transform.Rotate(0, 0, rotSpeed); //隕石を回転させる

        if (transform.position.y < -30.0f)
        {
            Destroy(gameObject); //画面外に出たら隕石を破棄。少し下に破棄ラインを指定して挙動を調節してる
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            isClear = false; //クリアフラグをfalseの状態にしておく
            Debug.Log("ゲームオーバー");//ログに"ゲームオーバー"と表示させる
            Invoke("DelayMethod", 2.0f); //2秒後にディレイメソッドを実行
            Destroy(coll.gameObject); //プレイヤーを破棄

            //音声再生
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));

            //爆発エフェクトを生成
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }

    //ディレイメソッド。クリアでできなかった信号をだして、制限時間ギリギリに当たった場合でもクリア判定にならないようにしている
    void DelayMethod()
    {
        isClear = false; //クリアフラグをfalseの状態に設定

        //リザルトシーン単体を読み込む
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }

    void HardMethod()
    {
        this.fallSpeed = 0.025f + 0.1f * Random.value; //落下速度をランダムに設定
    }
}
