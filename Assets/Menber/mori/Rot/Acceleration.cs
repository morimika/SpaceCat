using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField]
    private float speed = 80;

    private Rigidbody2D _rigidbody;
    private float time;
    private bool doOnceTimeReload = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        time = 0;
        doOnceTimeReload = false;
    }
    // Update is called once per frame
    void Update()
    {
        var dire = Vector2.zero;
        //acceleration�ŉ�]���擾�AUnity�Ō���z����]
        //-1������Ə��ɂȂ�
        //���{��0~0.035�A0~0.035
        dire.x = Input.acceleration.x;
        dire *= Time.deltaTime;
        //���x�ύX
        //_rigidbody.velocity = new Vector2(dire.x * speed * -1, _rigidbody.velocity.y);
        //�����x�ύX
        _rigidbody.AddForce(new Vector2(dire.x * speed, _rigidbody.gravityScale)
            , ForceMode2D.Force);

        //�X�^�[�g��
        if(PlayerLayer.IsGameTime)
        {
            //�ō����x�X�V
            if (ResultManager_Mori.VelocityValue < _rigidbody.velocity.y)
            {
                ResultManager_Mori.VelocityValue = _rigidbody.velocity.y;
            }
            //�^�C������
            time += Time.deltaTime;
        }
        //�^�C���̍X�V�������Ă���@���@�܂��X�V���Ă��Ȃ��Ƃ�
        else if (time != 0 && doOnceTimeReload == false)
        {
            ResultManager_Mori.TimeValue = (int)time;
            doOnceTimeReload = true;
        }
    }
}

