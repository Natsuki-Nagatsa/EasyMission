using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public static int highscore = 0; //グローバルなスコア変数
    GameObject scoreText; //スコアテキストのゲームオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        if (highscore < UIController.score)
        {
            highscore = UIController.score;
        }

        //スコアテキストのゲームオブジェクトを検索して取得する
        scoreText = GameObject.Find("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        //スコアテキストの表示を更新する
        scoreText.GetComponent<Text>().text = "HighScore: " + highscore.ToString("D4");
    }
}
