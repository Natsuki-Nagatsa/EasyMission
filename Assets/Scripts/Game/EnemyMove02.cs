using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EnemyMove02 : MonoBehaviour
{
    //スクリプトに格納するもの
    public static bool isClear = true; //クリアフラグ
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ

    int flg = 0; // パターンBの一時停止フラグ
    private bool isMoving = true; // パターンBの移動フラグ
    private float moveSpeed = -3.0f; // パターンBの移動速度
    private float stopDuration = 5f; // パターンBの一時停止時間
    private float targetY = 3f; // パターンBの停止位置

    private void start()
    {
        isClear = true; //クリアフラグを初期化。trueの状態に設定
    }

    private void Update()
    {
        if (isMoving)
        {
            // 下方向に移動
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            if (transform.position.y <= targetY)
            {
                if (flg == 0)
                {
                    // 一時停止して再開するためのフラグ設定
                    isMoving = false;
                    Invoke("ResumeMovement", stopDuration);
                    flg = 1;
                }
            }
        }
    }

    private void ResumeMovement()
    {
        // 移動再開
        isMoving = true;
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