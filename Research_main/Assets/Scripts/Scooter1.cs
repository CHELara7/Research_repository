using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Scooter1 : MonoBehaviour
{
    [SerializeField] private CountDown countDown;
    [SerializeField] private GameObject[] cube;
    [SerializeField] private int allTime;        //　スタートからゴールまでの時間

    private int count = 1;              //　カウント
    private float remDistance;          //　残りの2点間の距離
    private Vector3 moveVelocity;		//　現在の移動の速度
    private Vector3[] targetPos;        //　ターゲットの位置ベクトル
    private Vector3[] targetRot;        //　ターゲットの回転ベクトル


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debug : start");
        //　ターゲットの位置ベクトル
        targetPos = new Vector3[cube.Length];
        //　ターゲットの回転ベクトル
        targetRot = new Vector3[cube.Length];
        //　ターゲット情報を格納
        for (int i = 0; i < cube.Length; i++)
        {
            targetPos[i] = cube[i].transform.position;
            targetRot[i] = cube[i].transform.localEulerAngles;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //　始めのスタート
        if (countDown.endCount == true)
        {
            // ストップ
            countDown.endCount = false;
            //　移動
            transform.DOLocalPath(targetPos, allTime, PathType.CatmullRom)
            .SetEase(Ease.Linear)     //なめらかに
            .OnComplete(() =>
            {              //　終了時
                SceneManager.LoadScene("Home");
            });

            //　回転
            transform.DOLocalRotate(targetRot[count], 2f)
            .SetEase(Ease.InOutSine);     //なめらかに
        }

        //　スクーターと目的地cubeの距離
        remDistance = Vector3.Distance(transform.position, cube[count].transform.position);
        //Debug.Log(remDistance);

        //　距離が0.2より小さくなったとき
        if (remDistance < 0.2)  //remDistanceは0にならない
        {
            count++;
            Debug.Log("Debug : count plus, Now is " + count);
            //　回転
            transform.DOLocalRotate(targetRot[count], 3f)
            .SetEase(Ease.InOutSine);        //　なめらかに
        }
    }
}
