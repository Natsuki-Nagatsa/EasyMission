using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EnemyMove03 : MonoBehaviour
{
    //スクリプトに格納するもの
    public static bool isClear = true; //クリアフラグ
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ
    public float moveSpeed = 1.0f; //移動速度
    PointerEventData pointer; //ポインターイベントデータ


    private void start()
    {
        isClear = true; //クリアフラグを初期化。trueの状態に設定
        pointer = new PointerEventData(EventSystem.current); //ポインターイベントデータを初期化
    }

    private void Update()
    {
        transform.Translate(0, 0.05f, 0);

        //左キーかAキーを押してる間、
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            LeftMove(); //左に移動する。
        }

        //右キーかDキーを押してる間、
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RightMove(); //右に移動する。
        }

        //マウスの左クリックを押している間、画面の左側をクリックした場合は左に移動し、右側をクリックすると右に移動する。
        if (Input.GetMouseButton(0))
        {
            //クリックした箇所にポインターを出して、ポインターに触れたオブジェクトをリスト化する
            List<RaycastResult> results = new List<RaycastResult>();
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, results);

            //リスト化されたオブジェクトを、
            foreach (RaycastResult target in results)
            {
                //デバッグログに表示さてた時、
                Debug.Log(target.gameObject.name);
                //LEFTというオブジェクトがあったら、
                if (target.gameObject.name == "Left")
                {
                    LeftMove(); //レフトムーブを実行
                }

                //RIGHTというオブジェクトがあったら、
                if (target.gameObject.name == "Right")
                {
                    RightMove(); //ライトムーブを実行
                }
            }
        }

        if (transform.position.y < -20.0f)
        {
            Destroy(gameObject); //画面外に出たら隕石を破棄。少し下に破棄ラインを指定して挙動を調節してる
        }
    }

    //レフトムーブ。左に移動する処理
    public void LeftMove()
    {
        if (transform.position.x > -2.25f)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // 左に移動する
        }
    }

    //ライトムーブ。右に移動する処理
    public void RightMove()
    {
        if (transform.position.x < 2.25f)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 右に移動する
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
}