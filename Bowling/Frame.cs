namespace Bowling
{
    public class Frame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int ThirdRoll { get; set; }
        public int LastCommittedScoreFrame { get; set; }
        public int LatentScore { get; set; }
        public int Number { get; set; }
        public int NumberOfPinsKnockedDown { get; set; }
        public int RollNumber { get; set; }
        public bool IsMark { get; set; }
        public bool IsSpare { get; set; }
        public bool IsStrike { get; set; }
    }
}
