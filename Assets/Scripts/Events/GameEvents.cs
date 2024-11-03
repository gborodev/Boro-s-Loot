using System;

public static class GameEvents
{
    public static Action<StageData> OnRoomStart;

    public class SlotEvents
    {
        public static Action<EnemySlotContent> OnCompleteStage;
        public static Action<EnemySlotContent> OnInitializeStage;
    }
}
