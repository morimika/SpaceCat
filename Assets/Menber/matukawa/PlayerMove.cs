using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    protected float speed = 3.0f;
    private bool _isGameOver = false;
    public GameObject target;

    private void Start()
    {
        //スタート位置、ターゲットの座標、速度
        transform.position
            = Vector3.MoveTowards(transform.position, target.transform.position, speed);


    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // 画面外に出さない
        transform.position = new Vector2(
        //エリア指定して移動する
        Mathf.Clamp(transform.position.x + moveX, -8.5f, 8.5f),
        Mathf.Clamp(transform.position.y + moveY, -15f, 4.5f)
        );
    }
}
