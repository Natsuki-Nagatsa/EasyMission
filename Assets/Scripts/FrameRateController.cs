using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    // 目標のフレームレート
    public int targetFrameRate = 60;

    private void Awake()
    {
        // フレームレートを設定
        Application.targetFrameRate = targetFrameRate;
    }

    private void Update()
    {
        // 現在のフレームレートを取得してコンソールに表示
        float currentFrameRate = 1.0f / Time.deltaTime;
        Debug.Log("Current Frame Rate: " + currentFrameRate.ToString("F2"));
    }
}
