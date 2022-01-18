using UnityEngine.UI;
using UnityEngine;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private RectTransform _parentRectTransform;
    private Camera _camera;
    private MobStatus _status;

    private void Update()
    {
        Refresh();
    }

    public void Initialize(RectTransform parentRectTramsform,
        Camera camera, MobStatus status)
    {
        _parentRectTransform = parentRectTramsform;
        _camera = camera;
        _status = status;
        Refresh();
    }

    private void Refresh()
    {
        fillImage.fillAmount = _status.Life / _status.LifeMax;
        var screenPoint = _camera.WorldToScreenPoint
            (_status.transform.position);

        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_parentRectTransform, screenPoint, null
            , out localPoint);

        transform.localPosition = localPoint + new Vector2(0, 80);
    }

}
