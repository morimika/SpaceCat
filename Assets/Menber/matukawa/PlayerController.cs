using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using NaughtyAttributes;


public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;
    //public Renderer _fadeTarget;

    // エフェクト
    [SerializeField] GameObject enemyNiBikkuri;
    [SerializeField] GameObject fishNiHappy;

    // SE
    [SerializeField] AudioClip fishSE;
    [SerializeField] AudioClip cucumberSE;
    AudioSource audioSource = null;

    // きゅうりに当たった時、加算される重力の大きさ
    [SerializeField, Label("加算される重力の大きさ")] float cucumberCrush = 0.5f;
    // きゅうりに当たった時、減らされる重力の大きさ
    [SerializeField, Label("加算される重力の大きさ")] float fishCrush = -0.5f;

    [SerializeField]
    private ResultManager_Mori _re;

    private Rigidbody2D _rigi;

    private bool _isGoal = false;
    private void Start()
    {
       // CreateItems();
       _rigi= GetComponent<Rigidbody2D>();  
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        // スタート位置、ターゲットの座標、速度
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // 画面外に出さない
        transform.position = new Vector2(
        //エリア指定して移動する
        Mathf.Clamp(transform.position.x + moveX, -2.2f, 2.2f),
        Mathf.Clamp(transform.position.y + moveY, -10000f, 10000f)
        );

        // ゴールに到着したとき森ちゃんのリザルトへ飛ぶ   
        if (this.gameObject.transform.position.y >= 0&&!_isGoal)
        {
            _re.Resulu();
            PlayerLayer._doFollow = false;
            _isGoal = true;
            _rigi.velocity=Vector2.zero;
            _rigi.gravityScale = -0.02f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fish")
        {
            //GameOverを表示する
            Debug.Log("Fish");
            // 魚に当たった回数に＋１
            ResultManager_Mori.FishValue = ResultManager_Mori.FishValue + 1;
            // エフェクトが魚の位置で表示される
            Instantiate(fishNiHappy, other.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(fishSE);
            // 魚を消す
            Destroy(other.gameObject);

            // 重力が減らされて加速するはず
            _rigi.gravityScale = _rigi.gravityScale + fishCrush;
        }
        if (other.gameObject.tag == "Cucumber")
        {
            //GameOverを表示する
            Debug.Log("Cucumber");
            ResultManager_Mori.UriValue = ResultManager_Mori.UriValue + 1;
            Instantiate(enemyNiBikkuri, other.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(cucumberSE);
            Destroy(other.gameObject);

            // 重力が加算されて減速するはず
            _rigi.gravityScale = _rigi.gravityScale + cucumberCrush;
        }
    }
}

