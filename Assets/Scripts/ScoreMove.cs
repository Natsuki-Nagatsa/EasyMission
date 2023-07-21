using UnityEngine;

public class ScoreMove : MonoBehaviour
{
    public void AddScore()
    {
        // スコアを10増やす
        UIController.score += 10;

        // 更新されたスコアをPlayerPrefsに保存する
        PlayerPrefs.SetInt("SCORE", UIController.score);
    }
}
