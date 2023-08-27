using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoStay : MonoBehaviour
{
    //スクリプトに格納するもの
    float rotSpeed; //隕石の回転速度
    public AudioClip clip; //音声クリップ
    public GameObject explosionPrefab; //爆発エフェクトのプレハブ

    void Start()
    {
        this.rotSpeed = 5f + 15f * Random.value; //回転速度をランダムに設定
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed); //隕石を回転させる
    }
}
