using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _enemyImage;

    private EnemyData _enemyData;
    public EnemyData EnemyData
    {
        get => _enemyData;

        set
        {
            _enemyData = value;

            if (_enemyData is null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                _enemyImage.sprite = _enemyData.DataSprite;
            }
        }
    }

    public event Action<EnemySlot> OnClickSlot;

    private void Awake()
    {
        _enemyImage = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnClickSlot?.Invoke(this);
        }
    }
}
