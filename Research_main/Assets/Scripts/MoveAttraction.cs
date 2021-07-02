using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAttraction : MonoBehaviour
{
    [SerializeField] public GameObject[] cube;
    [SerializeField] private float maxSpeed;	 //　最高速度
    [SerializeField] private float rotateSpeed;  // 回転速度
    [SerializeField] private float duration;	 //　カメラの移動間隔

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
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        //アトラクションと目的地cubeの距離
        remDistance = Vector3.Distance(transform.position, targetCube.position);
        Debug.Log(remDistance);
        if (remDistance < 0.01)  //remDistanceは0にならない
        {
            count++;
            //最後まで進んだとき
            if (count == cube.Length - 1)  
            {
                //end
                Debug.Log("Debug : End");
            }
            Debug.Log("Debug : count plus");
            //開始時間更新
            startTime = Time.time;
            //スタート位置更新
            //startPos = this.gameObject.transform;
            //目的cubeの位置
            targetCube = cube[count].transform;
            //次の2点間の距離
            distance = Vector3.Distance(transform.position, targetCube.position);
        }
        //　位置をスムーズに動かす
        var t = (Time.time - startTime) / duration;
        var xPos = Mathf.SmoothStep(transform.position.x, targetCube.position.x, t);
        var yPos = Mathf.SmoothStep(transform.position.y, targetCube.position.y, t);
        var zPos = Mathf.SmoothStep(transform.position.z, targetCube.position.z, t);
        transform.position = new Vector3(xPos, yPos, zPos);
        //ansform.position = Vector3.SmoothDamp(transform.position, targetCube.position, ref moveVelocity, speed * Time.deltaTime, maxSpeed);

        //　カメラの角度をスムーズに動かす
        var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, targetCube.eulerAngles.x, ref xVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        var yRotate = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetCube.eulerAngles.y, ref yVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        var zRotate = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetCube.eulerAngles.z, ref zVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
        transform.eulerAngles = new Vector3(xRotate, yRotate, zRotate);

        //現在の位置
        //present = ((Time.time - startTime) * speed) / distance;
        //オブジェクト移動
        //transform.position = Vector3.Lerp(startPos, cube[count].transform.position, present);
    }
}
