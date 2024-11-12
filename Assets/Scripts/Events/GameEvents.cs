namespace GameEvents
{

    public static class StageEvents
    {
        public delegate void StageStartedHandler();
        public static StageStartedHandler OnStageStarted;

        public delegate void StageSelectedHandler(CombatStage stage);
        public static StageSelectedHandler OnStageSelected;

        public delegate void StageCompletedHandler();
        public static StageCompletedHandler OnStageCompleted;
    }
}
