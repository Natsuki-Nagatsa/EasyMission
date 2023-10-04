using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EnemyMove04 : MonoBehaviour
{
    //スクリプトに格納するもの
    public static bool isClear = true; //クリアフラグ
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ

    private void start()
    {
        isClear = true; //クリアフラグを初期化。trueの状態に設定
    }

    private void Update()
    {

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
}