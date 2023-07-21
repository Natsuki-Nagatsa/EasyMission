using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    //スクリプトに格納するもの
    public static bool isClear = true; //クリアフラグ
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ

    public enum MovementPattern
    {
        PatternA,
        PatternB,
        PatternC
    }

    public MovementPattern movementPattern; // 敵の移動パターン

    float x = -0.01f; // パターンAの横方向の移動速度

    private void start()
    {
        isClear = true; //クリアフラグを初期化。trueの状態に設定
    }

    private void Update()
    {
        switch (movementPattern)
        {
            case MovementPattern.PatternA:
                MovePatternA();
                break;

            case MovementPattern.PatternB:
                MovePatternB();
                break;

            case MovementPattern.PatternC:
                MovePatternC();
                break;
                
        }

        if (transform.position.y < -15.0f)
        {
            // 画面外に出たら敵を破棄
            Destroy(gameObject);
        }
    }

    private void MovePatternA()
    {
        if (transform.position.y > 3)
        {
            // 上方向に移動
            transform.Translate(0, 0.05f, 0);
        }

        else if (transform.position.x > 2.75)
        {
            // 右方向に移動
            x = 0.01f;
        }

        else if (transform.position.x < -2.75)
        {
            // 左方向に移動
            x = -0.01f;
        }
        
        // 横方向に移動
        transform.Translate(x, 0, 0);
    }

    int flg = 0; // パターンBの一時停止フラグ
    private bool isMoving = true; // パターンBの移動フラグ
    private float moveSpeed = -3.0f; // パターンBの移動速度
    private float stopDuration = 5f; // パターンBの一時停止時間
    private float targetY = 3f; // パターンBの停止位置

    private void MovePatternB()
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

    private void MovePatternC()
    {
        // パターンCは未実装
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