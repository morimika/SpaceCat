using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Xml;

public class ResultManager_Mori : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titleTxt;
    [SerializeField]
    private TextMeshProUGUI _veloTxt;
    [SerializeField] 
    private TextMeshProUGUI _timeTxt;
    [SerializeField]
    private TextMeshProUGUI _fishTxt;
    [SerializeField]
    private TextMeshProUGUI _uriTxt;
    [SerializeField]
    private TextMeshProUGUI _crashTxt;

    /// <summary>
    /// Script:Acceleration�ŎZ�o
    /// �ō����x
    /// </summary>
    public static float VelocityValue = 0;
    /// <summary>
    /// Script:Acceleration�ŎZ�o
    /// ������������
    /// </summary>
    public static int TimeValue = 0;
    /// <summary>
    /// Script:
    /// ����H�ׂ���
    /// </summary>
    public static int FishValue = 0;
    /// <summary>
    /// Script:
    /// ���イ��ɋ�������
    /// </summary>
    public static int UriValue = 0;
    /// <summary>
    /// Script:
    /// ��Q���ɓ���������
    /// </summary>
    public static int CrashValue = 0;

    [SerializeField]
    private bool fuwafuwaMode = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLayer.DoFuwa = fuwafuwaMode;
    }
    public void Resulu()
    {
        StartCoroutine(TextEnabled());
    }


    [SerializeField, Button]
    public IEnumerator TextEnabled()
    {
        _titleTxt.text = "��s����";
        _veloTxt.text = "�ō����x�F" + VelocityValue + "m/s";
        _timeTxt.text = "�o�ߎ��ԁF" + TimeValue + "s";
        _fishTxt.text = "����H�ׂ���" + FishValue + "��";
        _uriTxt.text = "�L���E���ɋ�������"+ UriValue + "��";
        _crashTxt.text= "�Ԃ�������"+ CrashValue + "��";

        TxtAnim(_titleTxt);
        yield return new WaitForSeconds(1);
        TxtAnim(_titleTxt);
        yield return new WaitForSeconds(1);
        TxtAnim(_titleTxt);
        yield return new WaitForSeconds(1);
        TxtAnim(_titleTxt);
    }

    [SerializeField, Button]
    public void TxtAnim(TextMeshProUGUI tmPro)
    {
        StartCoroutine(Simple(tmPro));
    }

    private IEnumerator Simple(TextMeshProUGUI tmpText)
    {
        // �����̕\������0��(�e�L�X�g���\������Ȃ��Ȃ�)
        tmpText.maxVisibleCharacters = 0;

        // �e�L�X�g�̕����������[�v
        for (var i = 0; i < tmpText.text.Length; i++)
        {
            // �ꕶ�����Ƃ�0.2�b�ҋ@
            yield return new WaitForSeconds(0.2f);

            // �����̕\�����𑝂₵�Ă���
            tmpText.maxVisibleCharacters = i + 1;
        }
    }
}
