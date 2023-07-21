using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	//スクリプトに格納するもの
    public AudioClip clip;  //再生するオーディオクリップ
    public GameObject explosionPrefab;  //爆発エフェクトのプレハブ

    void Update()
    {
        //Bulletを毎フレーム、y方向に0.05のずつ移動させる
        transform.Translate(0, 0.25f, 0);

        //弾の位置が5よりも上に移動していた場合、
        if (transform.position.y > 5)
        {
            //弾を破棄する
            Destroy(gameObject);
        }
    }

    //弾が他のオブジェクトに触れたときの処理
    void OnTriggerEnter2D(Collider2D coll)
    {
        //CanvasオブジェクトのUIControllerコンポーネントを取得し、スコアを加算する
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

        //指定した位置でオーディオクリップを再生する。z座標の変更でボリュームを調節
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));

        //爆発エフェクトのプレハブを指定位置に生成する
        GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;

        //1秒後に爆発エフェクトを破棄する
        Destroy(effect, 1.0f);

        //衝突した相手のゲームオブジェクトを破棄する
        Destroy(coll.gameObject);

        // 弾自体も破棄する
        Destroy(gameObject);
    }
}
