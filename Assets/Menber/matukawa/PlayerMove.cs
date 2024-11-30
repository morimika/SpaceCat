using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float _cycle = 1;
    private float speed = 8.0f;
    public GameObject target;

    public Renderer _fadeTarget;

    private Vector3 mousePosition;
    private Vector3 objPosition;

    [SerializeField] GameObject enemyNiBikkuri;
    [SerializeField] GameObject fishNiHappy;

    [SerializeField]
    private ResultManager_Mori _re;

    [SerializeField]
    private GameObject _eff;

    private Rigidbody2D _rigi;

    private bool _isGoal = false;
    private void Start()
    {
       // CreateItems();
       _rigi= GetComponent<Rigidbody2D>();  

    }
    void Update()
    {
        // �X�^�[�g�ʒu�A�^�[�Q�b�g�̍��W�A���x
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // ��ʊO�ɏo���Ȃ�
        transform.position = new Vector2(
        //�G���A�w�肵�Ĉړ�����
        Mathf.Clamp(transform.position.x + moveX, -8.5f, 8.5f),
        Mathf.Clamp(transform.position.y + moveY, -10000f, 10000f)
        );

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
        if (other.gameObject.tag == "shark")
        {
            //GameOver��\������
            Debug.Log("shark");
            ResultManager_Mori.CrashValue = ResultManager_Mori.CrashValue + 1;
            Instantiate(_eff, transform.position, Quaternion.identity);
        }
        if (other.gameObject.tag == "cucuember")
        {
            //GameOver��\������
            Debug.Log("cucuember");

            Debug.Log("cucuember");
            ResultManager_Mori.UriValue = ResultManager_Mori.UriValue + 1;
            Instantiate(_eff, transform.position, Quaternion.identity);

        }
    }
}

