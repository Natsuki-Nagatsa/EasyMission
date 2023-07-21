using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
	//スクリプトに格納するもの
    public GameObject enemyPrefab; //生成する敵のプレハブ

    void Start()
    {
        //5秒後から、5秒ごとにgenENEMYメソッドを繰り返し実行する
        InvokeRepeating("genENEMY", 5, 5);
    }

    void genENEMY()
    {
        //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
        Instantiate(enemyPrefab, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.Euler(0f, 0f, 180f));
    }
}
