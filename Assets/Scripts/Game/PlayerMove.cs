using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //スクリプトに格納するもの
    public AudioClip clip; //効果音クリップ
    public GameObject bulletPrefab; //弾のプレハブ
    public GameObject MeteoPrefab; //隕石のプレハブ
    public float moveSpeed = 1.0f; //移動速度

    PointerEventData pointer; //ポインターイベントデータ

    void Start()
    {
        StartCoroutine(ShootBullet()); //弾生成に関するコルーチン、ショットバレットを実行
        pointer = new PointerEventData(EventSystem.current); //ポインターイベントデータを初期化
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore(); //スコアを追加するためのUIコントローラーを取得し、スコアを加算する
    }

    void Update()
    {
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
                //デバッグログに表示させた時、
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
    }

    //レフトムーブ。左に移動する処理
    public void LeftMove()
    {
        if (transform.position.x > -2.25f)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 左に移動する
        }
    }

    //ライトムーブ。右に移動する処理
    public void RightMove()
    {
        if (transform.position.x < 2.25f)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // 右に移動する
        }
    }

    //ショットバレット。弾生成に関する処理
    IEnumerator ShootBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f); //0.25秒のディレイ。次の弾が生成されるまでの間隔をコントロールしてる
            Vector3 newPosition = transform.position; //自機の座標を読み取って、
            newPosition.y += 0.5f; //自機の少し前に生成位置を調節して、
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -12)); //効果音再生しつつ
            GameObject bullet = Instantiate(bulletPrefab, newPosition, Quaternion.identity); //弾を生成する
        }
    }
}
