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

    //�ne gelen a�aman�n i�levleri.
    private void StageSelected(CombatStage stage)
    {
        if (_currentStage != null)
        {
            _currentSlots.Clear();
        }

        _currentStage = stage;

        //�ne gelen a�aman�n mevcut slotlar� �ekildi. 
        List<EnemySlot> activeSlots = _currentStage.GetSlots();
        _currentSlots = activeSlots;

        //T�m slotlara t�klanabilirlik eklenir ve t�klan�lan slot se�ilir.
        foreach (EnemySlot slot in activeSlots)
        {
            slot.OnClickSlot += EnemySelected;
            slot.SlotActivated();
        }

        //Ba�lang��ta bir hedef se�ildi.
        EnemySelected(activeSlots[Mathf.FloorToInt((float)(activeSlots.Count - 1) / 2)]);
    }

    //Se�ilen slotun i�levleri.
    private void EnemySelected(EnemySlot slot)
    {
        _selectedEnemySlot = slot;
    }
}
