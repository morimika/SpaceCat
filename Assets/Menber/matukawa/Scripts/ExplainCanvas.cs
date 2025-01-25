using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using NaughtyAttributes;

public class ExplainCanvas : MonoBehaviour
{
    [Label("このスクリプトの使い方")] string st = "ゲームスタートボタンにつけて、クリックしたら[OnClickStart]が呼ばれるようにする";

    // 対象のテキスト
    [SerializeField] private TMP_Text _text1;

    // 次の文字を表示するまでの時間[s]
    [SerializeField] private float _delayDuration = 0.1f;

    private Coroutine _showCoroutine;

    private void OnClickStart()
    {
        Show();
    }

    public void Show()
    {
        // 前回の演出処理が走っていたら、停止
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        // １文字ずつ表示する演出のコルーチンを実行する
        _showCoroutine = StartCoroutine(ShowCoroutine(_text1));
    }

    // １文字ずつ表示する演出のコルーチン
    private IEnumerator ShowCoroutine(TMP_Text _text)
    {
        // テキストを表示
        _text.gameObject.SetActive(true);

        // 待機用コルーチン
        // GC Allocを最小化するためキャッシュしておく
        var delay = new WaitForSeconds(_delayDuration);

        // テキスト全体の長さ
        var length = _text.text.Length;

        // １文字ずつ表示する演出
        for (var i = 0; i < length; i++)
        {
            // 徐々に表示文字数を増やしていく
            _text.maxVisibleCharacters = i;

            // 一定時間待機
            yield return delay;
        }

        // 演出が終わったら全ての文字を表示する
        _text.maxVisibleCharacters = length;

        // しばらく文字を表示してからフェード
        yield return delay;

        FadeOutText();
        _showCoroutine = null;
    }

    public void FadeOutText()
    {
        // テキストをフェードアウトする
        _text1.DOFade(0f, 3f);
    }
}
