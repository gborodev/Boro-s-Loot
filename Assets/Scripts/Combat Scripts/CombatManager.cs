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
        }

        //Baþlangýçta bir hedef seçildi.
        //EnemySelected(activeSlots[Mathf.FloorToInt((float)(activeSlots.Count - 1) / 2)]);
    }

    //Seçilen slotun iþlevleri.
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
