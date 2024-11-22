using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _enemyImage;
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
            }
        }
    }

    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;

        }
    }

    private int _armor;
    public int Armor
    {
        get => _armor;
        set
        {
            _armor = value;
        }
    }


    //Slotun týklanýlabilirlik eventi
    public event Action<EnemySlot> OnClickSlot;

    public void SlotActivated()
    {
        if (_enemyData is not null)
        {
            _healthImage.gameObject.SetActive(true);
            _armorImage.gameObject.SetActive(true);

            Health = _enemyData.BaseHealth;
            Armor = _enemyData.BaseArmor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnClickSlot?.Invoke(this);
        }
    }
}
