using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using NaughtyAttributes;

// Matsukawa
public class PlayerMove : MonoBehaviour
{
    // Playerの移動関係
    private float _speed = 8.0f;

    // エフェクト
    [SerializeField, Label("魚に当たった時のエフェクト")] GameObject _fishEffects;
    public Renderer _fadeTarget;

    // 他スクリプトの参照
    [SerializeField]
    private ResultManager_Mori _re;

    [SerializeField]
    private GameObject _eff;

    private Rigidbody2D _rigi;

    private bool _isGoal = false;
    private void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();  

    }
    void Update()
    {
        // スタート位置、ターゲットの座標、速度
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        // 画面外に出さない
        transform.position = new Vector2(
        //エリア指定して移動する
        Mathf.Clamp(transform.position.x + moveX, -2f, 2f),
        Mathf.Clamp(transform.position.y + moveY, -5f, 5f)
        );



        // リザルトへ行く処理
        if (this.gameObject.transform.position.y >= 0&&!_isGoal)
        {
            // _re.Resulu();
            PlayerLayer._doFollow = false;
            _isGoal = true;
            _rigi.velocity=Vector2.zero;
            _rigi.gravityScale = -0.02f;

            // 画面外に出さない
            transform.position = new Vector2(
            //エリア指定して移動する
            Mathf.Clamp(transform.position.x + moveX, -2f, 2f),
            Mathf.Clamp(transform.position.y + moveY, -6f, 1000f)
            );

            if (this.gameObject.transform.position.y == 1500)
            {
                // 位置が1500をになったら止まる
                _rigi.gravityScale = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //プレイヤーと目標のアイテムの距離を取得
        float _distance = Vector3.Distance(this.transform.position, other.transform.position);
        
        if (other.gameObject.tag == "Cucuember")
        {
            //GameOverを表示する
            Debug.Log("きゅうり");

            //ResultManager_Mori.UriValue = ResultManager_Mori.UriValue + 1;
            //Instantiate(_eff, transform.position, Quaternion.identity);

        }
        if (other.gameObject.tag == "Fish")
        {
            Vector3 _force = other.transform.position - this.gameObject.transform.position; // 力の方向を指定
            _rigi.AddForce(_force * 0.01f, ForceMode2D.Impulse); // 力を加えて移動

            Debug.Log(("魚発見") + _distance);
            //ResultManager_Mori.UriValue = ResultManager_Mori.UriValue + 1;
            //Instantiate(_eff, transform.position, Quaternion.identity);

        }

    }

    //きゅうりが画面内にいたら離れる
    //魚なら近づく
    //public void ItemDistance(GameObject targetObj)
    //{
    //    プレイヤーと目標のアイテムの距離を取得
    //    float _distance = Vector3.Distance(this.transform.position, targetObj.transform.position);

    //    if (_distance <= 18f && targetObj.tag == "Cucumber")
    //    {
    //        Addforce離れる
    //        Debug.Log(("きゅうり") + _distance);
    //    }
    //    else
    //    {
    //        Debug.Log("きゅうりなし");
    //    }

    //    if (_distance <= 18f && GameObject.Find("Fish"))
    //    {
    //        Addforce近づく
    //       Vector3 _force = targetObj.transform.position; // 力の方向を指定
    //        _rigi.AddForce(_force, ForceMode2D.Force); // 力を加えて移動

    //        Debug.Log(("魚発見") + _distance);
    //    }
    //    else
    //    {
    //        Debug.Log("さかななし");
    //    }
    //}
}

