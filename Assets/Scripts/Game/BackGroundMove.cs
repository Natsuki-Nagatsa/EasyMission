using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    void Update()
    {
        //バックグラウンドの画像を毎フレーム、y方向に-0.005ずつ移動させる
        transform.Translate(0, -0.005f, 0);

        //バックグラウンドの画像の位置が-10.0よりも下に移動した場合、
        if (transform.position.y < -10.0f)
        {
            //y座標の10.0に移動させる
            transform.position = new Vector3(0, 10.0f, 0);
        }
    }
}
