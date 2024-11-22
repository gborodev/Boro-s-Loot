using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    private CombatStage _currentStage;

    private List<EnemySlot> _currentSlots = new List<EnemySlot>();
    private EnemySlot _selectedEnemySlot;

    private void Start()
    {
        GameEvents.StageEvents.OnStageSelected += StageSelected;
    }

    //Öne gelen aþamanýn iþlevleri.
    private void StageSelected(CombatStage stage)
    {
        if (_currentStage != null)
        {
            _currentSlots.Clear();
        }

        _currentStage = stage;

        //Öne gelen aþamanýn mevcut slotlarý çekildi. 
        List<EnemySlot> activeSlots = _currentStage.GetSlots();
        _currentSlots = activeSlots;

        //Tüm slotlara týklanabilirlik eklenir ve týklanýlan slot seçilir.
        foreach (EnemySlot slot in activeSlots)
        {
            slot.OnClickSlot += EnemySelected;
            slot.SlotActivated();
        }

        //Baþlangýçta bir hedef seçildi.
        EnemySelected(activeSlots[Mathf.FloorToInt((float)(activeSlots.Count - 1) / 2)]);
    }

    //Seçilen slotun iþlevleri.
    private void EnemySelected(EnemySlot slot)
    {
        _selectedEnemySlot = slot;
    }
}
