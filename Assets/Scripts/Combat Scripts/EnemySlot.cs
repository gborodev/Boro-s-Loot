using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySlot : MonoBehaviour, IPointerClickHandler
{
    private Image _enemyImage;
    private Image _healthImage;
    private Image _armorImage;

    //Slotun aþamaya göre görünürlük deðeri
    public Color SlotColor
    {
        get => _enemyImage.color;
        set
        {
            _enemyImage.color = value;
        }
    }

    //Mevcut Slot Data
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
                _enemyImage.SetNativeSize();
            }

            _healthImage.gameObject.SetActive(false);
            _armorImage.gameObject.SetActive(false);
        }
    }

    public int Health
    {
        set
        {


        }
    }


    //Slotun týklanýlabilirlik eventi
    public event Action<EnemySlot> OnClickSlot;

    private void Awake()
    {
        _enemyImage = GetComponent<Image>();

        _healthImage = transform.GetChild(0).GetComponent<Image>();
        _armorImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnClickSlot?.Invoke(this);
        }
    }
}
