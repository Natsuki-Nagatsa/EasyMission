using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Text _textCountdown; // カウントダウンを表示するテキスト

    //変数の管理
    int a = 0; //周回調整フラグ
    int b = 0; //カウントダウンの残り秒数
    int c = 0; //初回更新フラグ

    PointerEventData pointer; // ポインターデータ
    public static bool isClear = false; // クリアフラグ
    public static bool isOver = false; // オーバーフラグ

    void Start()
    {
        pointer = new PointerEventData(EventSystem.current);
        
        _textCountdown.text = ""; //カウントダウンテキストに何も書かれていない状態にする
        isClear = false; //クリアフラグをfalseの状態にしておく
        isOver = false; //オーバーフラグをfalseの状態にしておく
    }


    void Update()
    {
        //１度だけ実行されるようにするため、cが0の時に実行して、cの値を変えている
        if (c == 0)
        {
            StartCoroutine(CountdownCoroutine()); //カウントダウンコルーチンの開始
            Invoke("DelayMethod", 30.0f); //30秒後にDelayMethodを呼び出す
            c = 1;
        }

        //メテオムーブスクリプトのクリア変数がfalseだった時、
        if(MeteoMove.isClear == false){
            //エネミームーブスクリプトのクリア変数がfalseだったら、
            if(EnemyMove01.isClear == false){
                isOver = true;//オーバーフラグをtrueにして, 
                Invoke("LoadSceneMethod", 2.0f); //2秒後にDelayMethodを呼び出す
            }

            if(EnemyMove02.isClear == false){
                isOver = true;//オーバーフラグをtrueにして,
                Invoke("LoadSceneMethod", 2.0f); //2秒後にDelayMethodを呼び出す
            }

            if(EnemyMove03.isClear == false){
                isOver = true;//オーバーフラグをtrueにして,
                Invoke("LoadSceneMethod", 2.0f); //2秒後にDelayMethodを呼び出す
            }

            if(EnemyMove04.isClear == false){
                isOver = true;//オーバーフラグをtrueにして,
                Invoke("LoadSceneMethod", 2.0f); //2秒後にDelayMethodを呼び出す
            }
        }
    
        if(MeteoMove.isClear == true){
            isOver = false;//オーバーフラグをfalseにする
        }

        if(EnemyMove01.isClear == true){
            isOver = false;//オーバーフラグをfalseにする
        }

        if(EnemyMove02.isClear == true){
            isOver = false;//オーバーフラグをfalseにする
        }

        if(EnemyMove03.isClear == true){
            isOver = false;//オーバーフラグをfalseにする
        }

        if(EnemyMove04.isClear == true){
            isOver = false;//オーバーフラグをfalseにする
        }

    }

    //カウントダウンコルーチン。毎秒30からカウントダウンしていく
    IEnumerator CountdownCoroutine()
    {
        _textCountdown.gameObject.SetActive(true); //カウントダウンテキストをアクティブにする

        //残り時間bを毎秒１ずつ引きながらテキストを更新
        for (b = 30; b > 0; b--)
        {
            _textCountdown.text = "Time:" + b; //カウントダウンテキストを更新
            yield return new WaitForSeconds(1.0f); //1秒待機
        } 
    }

    void DelayMethod()
    {
        //30秒経った際にメテオムーブスクリプト内のクリアフラグがtrueだった(playerが逃げ切れた)場合、
        if (MeteoMove.isClear == true)
        {
            //クリアフラグをtrueにして、
            isClear = true;
            Debug.Log("ゲームクリア");//ログに"ゲームクリア"と表示させて、
            SceneManager.LoadScene("ResultScene", LoadSceneMode.Single); //ResultSceneをロードする。
        }
    }

    void LoadSceneMethod()
    {
        if (a == 0){
            a = 1;
        }

        if (a == 1){ 
            SceneManager.LoadScene("ResultScene", LoadSceneMode.Single); //ResultSceneをロードする
        }
    }
}
