using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager_Mori : MonoBehaviour
{
    [SerializeField]
    private Text _titleTxt;
    [SerializeField]
    private Text _crashTxt;
    [SerializeField]
    private Text _fishTxt;
    [SerializeField]
    private Text _uriTxt;

    public static int CrashValue;
    public static int FishValue;
    public static int UriValue;

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
    [SerializeField, Button]
    private IEnumerator TextEnabled()
    {
        TitleTxt();
        yield return new WaitForSeconds(1);
        CrashTxt();
        yield return new WaitForSeconds(1);
        FishTxt();
        yield return new WaitForSeconds(1);
        UriTxt();
    }

    [SerializeField, Button]
    private void TitleTxt()
    {
        _titleTxt.DOText("��s����",1f,scrambleMode:ScrambleMode.All);
    }
    [SerializeField, Button]
    private void CrashTxt()
    {
        _crashTxt.DOText("�Ԃ�������\n"+CrashValue+"��", 1f, scrambleMode: ScrambleMode.All);
    }
    [SerializeField, Button]
    private void FishTxt()
    {
        _fishTxt.DOText("����H�ׂ���\n"+FishValue + "��", 1f, scrambleMode: ScrambleMode.All);
    }
    [SerializeField, Button]
    private void UriTxt()
    {
        _uriTxt.DOText("�L���E���ɋ�������\n"+ UriValue + "��", 1f, scrambleMode: ScrambleMode.All);
    }
}
