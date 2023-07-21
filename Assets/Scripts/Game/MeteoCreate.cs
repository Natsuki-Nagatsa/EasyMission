using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoCreate : MonoBehaviour
{
	//スクリプトに格納するもの
    public GameObject rockPrefab; //生成する隕石のプレハブ
    
    void Start()
    {
        //1秒後から、1秒ごとにGenRockメソッドを繰り返し実行する
        InvokeRepeating("GenRock", 2, 2);
        Invoke("DelayMethod", 9f); //10秒後にDelayMethodを呼び出す
    }

    void GenRock()
    {
        //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に隕石を生成する
        Instantiate(rockPrefab, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.identity);
    }

    void DelayMethod()
    {
        //1秒後から、1秒ごとにGenRockメソッドを繰り返し実行する
            InvokeRepeating("GenRock", 2, 2);
    }
}
