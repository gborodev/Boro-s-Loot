using System.Collections.Generic;

public class CombatManager : Singleton<CombatManager>
{
    private CombatStage _currentStage;

    private List<EnemySlot> _currentSlots = new List<EnemySlot>();
    private EnemySlot _currentEnemySlot;

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
        }

        //Ba�lang��ta bir hedef se�ildi.
        //EnemySelected(activeSlots[Mathf.FloorToInt((float)(activeSlots.Count - 1) / 2)]);
    }

    //Se�ilen slotun i�levleri.
    private void EnemySelected(EnemySlot slot)
    {
        _currentEnemySlot = slot;

        //Test. Silinecek
        if (_currentStage.IsCleared())
        {
            GameEvents.StageEvents.OnStageCleared?.Invoke(_currentStage);
            _currentStage = null;
        }
    }
}
