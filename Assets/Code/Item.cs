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

    private Action _onCollect;
    
    public ItemType ItemType => itemType;

    public void Init(Action onCollectAction)
    {
        _onCollect = onCollectAction;
    }

    public void Collect(Vector3 startPosition, Transform collector)
    {
        transform.position = startPosition;
        transform.SetParent(collector);
        transform.DOLocalJump(Vector3.zero, jumpPower, 1, jumpTime).OnComplete(() => _onCollect?.Invoke());
    }

    public void TakeOut(Vector3 startPosition, Transform collector)
    {
        transform.position = startPosition;
        transform.SetParent(collector);
        transform.DOLocalJump(Vector3.zero, jumpPower, 1, jumpTime);
    }
}