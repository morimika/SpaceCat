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
    /// Script:Accelerationで算出
    /// 最高速度
    /// </summary>
    public static float VelocityValue = 0;
    /// <summary>
    /// Script:Accelerationで算出
    /// かかった時間
    /// </summary>
    public static int TimeValue = 0;
    /// <summary>
    /// Script:
    /// 魚を食べた回数
    /// </summary>
    public static int FishValue = 0;
    /// <summary>
    /// Script:
    /// きゅうりに驚いた回数
    /// </summary>
    public static int UriValue = 0;
    /// <summary>
    /// Script:
    /// 障害物に当たった回数
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
        _titleTxt.text = "飛行結果";
        _veloTxt.text = "最高速度：" + VelocityValue + "m/s";
        _timeTxt.text = "経過時間：" + TimeValue + "s";
        _fishTxt.text = "魚を食べた回数" + FishValue + "回";
        _uriTxt.text = "キュウリに驚いた回数"+ UriValue + "回";
        _crashTxt.text= "ぶつかった回数"+ CrashValue + "回";

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
        // 文字の表示数を0に(テキストが表示されなくなる)
        tmpText.maxVisibleCharacters = 0;

        // テキストの文字数分ループ
        for (var i = 0; i < tmpText.text.Length; i++)
        {
            // 一文字ごとに0.2秒待機
            yield return new WaitForSeconds(0.2f);

            // 文字の表示数を増やしていく
            tmpText.maxVisibleCharacters = i + 1;
        }
    }
}
