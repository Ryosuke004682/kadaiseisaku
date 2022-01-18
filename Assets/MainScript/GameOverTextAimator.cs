using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverTextAimator : MonoBehaviour
{
    private void Start()
    {
        //初期座標を保持する
        var transformCache = transform;
        //上に移動させる
        var defaultPositioin = transformCache.localPosition;
        //移動のアニメーションを開始する
        transformCache.localPosition = new Vector3(0, 300f);

        transformCache.DOLocalMove(defaultPositioin, 1f)
        .SetEase(Ease.Linear).OnComplete(() => 
        {
            Debug.Log("Game Over!!");
            //シェイクアニメーション
            transformCache.DOShakePosition(1.5f,100);
        });
        //10秒待ってからタイトルシーンに移動する
        DOVirtual.DelayedCall(10, () => 
        {
            SceneManager.LoadScene("YTitleScene");
        });
        //DOVirtur.DelayedCall(秒数,() ) で、「何秒後かに何かする」という意味。


    }
}
