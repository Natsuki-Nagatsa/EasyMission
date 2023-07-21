using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Result : MonoBehaviour
{

    public AudioClip over;
    public AudioClip clear;

    [SerializeField]
	private Text _textResult;

    void Start () {
        //ゲームクリアとゲームオーバーが共存するバグの対処のため、15~19の処理を追加
        //カウントダウンスクリプトのクリア変数がtrueのとき、
        if(Countdown.isClear == true){
            //カウントダウンスクリプトのオーバー変数がtrueだったら、
            if(Countdown.isOver == true){
                //"ゲームオーバー"と表示する
                _textResult.text = "GameOver";
                //音再生
                AudioSource.PlayClipAtPoint(over, new Vector3(0, 0, -10));
            }

            //メテオムーブスクリプトのクリア変数がfalse以外だったら、
            else{
                //"ゲームクリア"と表示する
                _textResult.text = "GameClear";
                AudioSource.PlayClipAtPoint(clear, new Vector3(0, 0, -10));
            }
        }

        //メテオムーブスクリプトのクリア変数がfalseのとき、
        if(Countdown.isClear == false){
            //"ゲームオーバー"と表示する
            _textResult.text = "GameOver";
            AudioSource.PlayClipAtPoint(over, new Vector3(0, 0, -10));
        }
    }
}
