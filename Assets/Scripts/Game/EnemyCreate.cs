using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreate : MonoBehaviour
{
	//スクリプトに格納するもの
    public GameObject enemy01; //生成する敵のプレハブ
    public GameObject enemy02; //生成する敵のプレハブ
    public GameObject enemy03; //生成する敵のプレハブ
    public GameObject enemy04; //生成する敵のプレハブ

    void Start()
    {
        //5秒後から、5秒ごとにgenENEMYメソッドを繰り返し実行する
        InvokeRepeating("genENEMY", 5, 5);
    }

    void genENEMY()
    {
        // 1から4までのランダムな整数を生成します。
        int randomNumber = Random.Range(1, 5);
        
        if(randomNumber == 1)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(enemy01, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.Euler(0f, 0f, 180f));
        }

        if(randomNumber == 2)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(enemy02, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.Euler(0f, 0f, 180f));
        }
        
        if(randomNumber == 3)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(enemy03, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.Euler(0f, 0f, 180f));
        }

        if(randomNumber == 4)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(enemy04, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.Euler(0f, 0f, 180f));
        }
    }
}
