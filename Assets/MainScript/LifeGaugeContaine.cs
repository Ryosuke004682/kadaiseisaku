using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class LifeGaugeContaine : MonoBehaviour
{
   public static LifeGaugeContaine Instance
    {
        get { return _instance; }
    }

    private static LifeGaugeContaine _instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LifeGauge lifeGaugePrefab;

    private RectTransform rectTransform;
    private readonly Dictionary<MobStatus, LifeGauge>
        _statusLifeBarMap = new Dictionary<MobStatus, LifeGauge>();

    private void Start()
    {
        if (null != _instance) throw new Exception
                ("LifeBarContainer instance already exists.");
        
            _instance = this;
        rectTransform = GetComponent<RectTransform>();
    }
    public void Add(MobStatus status)
    {
        var lifeGauge = Instantiate(lifeGaugePrefab, transform);
        lifeGauge.Initialize(rectTransform, mainCamera, status);
        _statusLifeBarMap.Add(status,lifeGauge) ;
    }
    public void Remove(MobStatus status)
    {
        Destroy(_statusLifeBarMap[status].gameObject);
        _statusLifeBarMap.Remove(status);
    }



}
