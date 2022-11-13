using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpPower;
    [SerializeField] private Ease ease;
    
    public UnityEvent onCollect { get; private set; }
    
    public ItemType ItemType => itemType;

    public void Init(Action onCollectAction)
    {
        onCollect = new UnityEvent();
        onCollect.AddListener(onCollectAction.Invoke);
    }

    public void Collect(Vector3 startPosition, Transform collector)
    {
        transform.position = startPosition;
        transform.SetParent(collector);
        transform.DOLocalJump(Vector3.zero, jumpPower, 1, jumpTime).OnComplete(onCollect.Invoke);
    }

    public void TakeOut(Vector3 startPosition, Transform collector)
    {
        transform.position = startPosition;
        transform.SetParent(collector);
        transform.DOLocalJump(Vector3.zero, jumpPower, 1, jumpTime);
    }
}