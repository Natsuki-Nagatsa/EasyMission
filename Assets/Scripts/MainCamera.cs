using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    private float idleTime = 0f;  // アイドル時間のカウント
    private float idleThreshold = 15f;  // アイドルとみなす閾値（秒）
    private bool isTimerRunning = true;  // タイマーが動作中かどうか

    void Start()
    {
        Time.timeScale = 1;//読み込みの時間が正常値に戻り
    }
    // Update is called once per frame
    void Update()
    {
        //左CTRLキーが押されている時、
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Rキーも押された場合、
            if (Input.GetKeyDown(KeyCode.R))
            {
                //現在読み込まれているシーンを再度読み込む
                switch (SceneManager.GetActiveScene().name)
                {
                    case "TitleScene":
                        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
                        break;
                    case "GameScene":
                        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
                        break;
                    case "ResultScene":
                        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
                        break;
                    default:
                        break;
                }
            }
        }

        //左CTRLを押しているとき、
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Tキーも押すと、
            if (Input.GetKeyDown(KeyCode.T))
            {
                Time.timeScale = 1;//読み込みの時間が正常値に戻り
                SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);//タイトルシーン単体を読み込む
            }
        }

        //入力があった場合はタイマーをリセット
        if (Input.anyKey)
        {
            idleTime = 0f;
        }

        //タイマーが動作中であればアイドル時間をカウント
        if (isTimerRunning)
        {
            idleTime += Time.deltaTime;

            //アイドル時間が閾値を超えた場合、TitleSceneに戻る
            if (idleTime >= idleThreshold)
            {
                if(SceneManager.GetActiveScene().name != "TitleScene"){
                    SceneManager.LoadScene("TitleScene");
                }
            }
        }

        //ESCキーでゲームを終わる
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
