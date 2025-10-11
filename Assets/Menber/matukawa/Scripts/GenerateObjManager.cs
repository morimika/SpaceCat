using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjManager : MonoBehaviour
{
    public GameObject cucumber;
    public GameObject fish;
    // きゅうりの生成間隔
    public float interval;

    // きゅうりの生成時間最初・最大
    public float cucumberMinTime = 1;
    public float cucumberMaxTime = 3;

    // 魚の生成時間最初・最大
    public float fishMinTime = 3;
    public float fishMaxTime = 4;

    //きゅうりの経過時間
    private float cucumberTime = 0f;
    //魚の経過時間
    private float fishTime = 0f;

    //X座標の最小値
    public float xMinPosition = -2f;
    //X座標の最大値
    public float xMaxPosition = 2f;

    void Update()
    {
        fishTime += Time.deltaTime;
        if (fishTime > interval)
        {
            GeneratePrefabs(fish, fishMinTime, fishMaxTime);
        }

        cucumberTime += Time.deltaTime;
        if (cucumberTime > interval)
        {
            GeneratePrefabs(cucumber, cucumberMinTime, cucumberMaxTime);
        }
    }

    public void GeneratePrefabs(GameObject obj, float min, float max)
    {
        //インスタンス化
        GameObject createdCucumber = Instantiate(obj);
        //位置をランダムに設定する
        createdCucumber.transform.position = GetRandomPosition();
        //時間リセット
        fishTime = 0f;
        cucumberTime = 0f;
        //時間間隔を決定する
        interval = GetRandomTime(min, max);

        // もしオブジェクトのy座標が50離れたら消す
        if (obj.transform.position.y == this.transform.position.y - 90f)
        {
            Destroy(obj);
        }

    }

    //ランダムな時間を生成する関数
    private float GetRandomTime(float min, float max)
    {
        return Random.Range(min, max);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        //Vector3型のPositionを返す
        return new Vector3(x, this.transform.position.y, 0f);
    }
}
