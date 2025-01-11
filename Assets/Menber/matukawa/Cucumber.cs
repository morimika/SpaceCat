using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    public GameObject cucumber;
    public GameObject fish;
    // きゅうりの生成ばしょ
    public Transform generatePos;
    // きゅうりの生成間隔
    public float interval;
    // 生成時間最初・最大
    public float minTime = 0.5f;
    public float maxTime = 0.9f;
    private int count = 0;
    //経過時間
    private float time = 0f;
    //X座標の最小値
    public float xMinPosition = -2f;
    //X座標の最大値
    public float xMaxPosition = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > interval)
        {
            GeneratePrefabs(cucumber);
            GeneratePrefabs(fish);
        }

    }

    public void GeneratePrefabs(GameObject obj)
    {
        //ballをインスタンス化して発射
        GameObject createdCucumber = Instantiate(obj);
        //生成した弾の位置をランダムに設定する
        createdCucumber.transform.position = GetRandomPosition();
        //時間リセット
        time = 0f;
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        minTime = minTime * 1000 / (1000 + count);
        maxTime = maxTime * 1000 / (1000 + count);
        return Random.Range(minTime, maxTime);
    }
    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        //Vector3型のPositionを返す
        return new Vector3(x, 10f, 0f);
    }
}
