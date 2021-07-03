using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAttraction : MonoBehaviour
{
    [SerializeField] public GameObject[] cube;
    [SerializeField] private float maxSpeed;	 //　最高速度
    [SerializeField] private float rotateSpeed;  //　回転速度
    [SerializeField] private float duration;	 //　カメラの移動間隔
    [SerializeField] private float moveSpeed;	 //　カメラの移動間隔
    [SerializeField] private int allTime;        //　スタートからゴールまでの時間

    private int count = 0;       //カウント
    private float speed = 1.0f;  //スピード
    private float distance;     //2点間の距離
    private float remDistance;  //残りの2点間の距離
    private float present;      //現在の位置
    private Transform targetCube;  // 目的Cubeの位置
    private float startTime;    //スタート時間
    private Vector3 moveVelocity;			//　現在の移動の速度
    private float xVelocity;            //　現在の回転の速度
    private float yVelocity;            //　現在の回転の速度
    private float zVelocity;			//　現在の回転の速度



    // Start is called before the first frame update
    void Start()
    {
        //開始時間
        startTime = Time.time;
        //目的cubeの位置
        targetCube = cube[count].transform;
        //2点間の距離を代入
        distance = Vector3.Distance(transform.position, targetCube.position);
        Debug.Log("Debug : start");
        Vector3[] path = { cube[count].transform.position, cube[count + 1].transform.position, cube[count + 2].transform.position };
        //移動
        transform.DOLocalPath(path, allTime, PathType.CatmullRom)
        .SetEase(Ease.Linear)
        //.SetLookAt(1f, Vector3.forward)
        .SetOptions(false, AxisConstraint.Y);
    }

    // Update is called once per frame
    void Update()
    {
        //アトラクションと目的地cubeの距離
        remDistance = Vector3.Distance(transform.position, targetCube.position);
        //Debug
        //Debug.Log(remDistance);
        if (remDistance < 0.2)  //remDistanceは0にならない
        {
            count++;
            Debug.Log("Debug : count plus, Now is " + count);
            //最後まで進んだとき
            if (count == cube.Length - 1)  
            {
                //end
                Debug.Log("Debug : End");
            }
            //通過点代入
            //Vector3[] path = { cube[count].transform.position, cube[count + 1].transform.position, cube[count + 2].transform.position};
            //開始時間更新
            startTime = Time.time;
            //目的cubeの位置
            targetCube = cube[count].transform;
            //距離
            distance = Vector3.Distance(transform.position, targetCube.position);
            Vector3[] path = { cube[count].transform.position, cube[count + 1].transform.position, cube[count + 2].transform.position };
            //移動
            if(count % 2 == 0)
            {
                transform.DOLocalPath(path, allTime, PathType.CatmullRom)
                .SetEase(Ease.Linear)
                //.SetLookAt(1f, Vector3.forward)
                .SetOptions(false, AxisConstraint.Y);
            }
        }
        
        //　位置をスムーズに動かす
        //transform.position = Vector3.SmoothDamp (transform.position, targetCube.position, ref moveVelocity, moveSpeed * Time.deltaTime, maxSpeed);
        //　位置をスムーズに動かすSmoothStep版
        /*var t = (Time.time - startTime) / duration;
        var xPos = Mathf.SmoothStep(transform.position.x, targetCube.position.x, t);
        var yPos = Mathf.SmoothStep(transform.position.y, targetCube.position.y, t);
        var zPos = Mathf.SmoothStep(transform.position.z, targetCube.position.z, t);
        transform.position = new Vector3(xPos, yPos, zPos);*/

        //　カメラの角度をスムーズに動かす
        var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, targetCube.eulerAngles.x, ref xVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        var yRotate = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetCube.eulerAngles.y, ref yVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        var zRotate = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetCube.eulerAngles.z, ref zVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);
    }
}
