using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //スクリプトに格納するもの、変数
    public static int score = 0; //グローバルなスコア変数
    int a = 0; //スコア初期化フラグ
    GameObject scoreText; //スコアテキストのゲームオブジェクト

    //scoreを加算するスクリプト。初回読み込み時にscoreを0にして、必ずscoreが0の状態で始まるように。
    public void AddScore()
    {
        //aが0の時に実行して最後にaを1にすることで、一度だけ読み込ませるようにした
        if (a == 0)
        {
            score = 0; //初回のスコア追加時にスコアをリセット
            a = 1; //初回フラグを設定
        }

        //二回目以降はこちらが実行される
        else
        {
            //スコアを10加算する
            score += 10;
        }
    }

    void Start()
    {
        a = 0; //初回フラグをリセット。これのおかげで何度も遊べる

        //スコアテキストのゲームオブジェクトを検索して取得する
        scoreText = GameObject.Find("Score");
    }

    void Update()
    {
        //スコアテキストの表示を更新する
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString("D4");
    }
}
