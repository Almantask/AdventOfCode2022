namespace AdventOfCode.Tests.Day2;

public class RockPaperScissorsGame
{
    public class Play
    {
        public static readonly Play Rock;
        public static readonly Play Paper;
        public static readonly Play Scissors;

        static Play()
        {
            Rock = new Play(1);
            Paper = new Play(2);
            Scissors = new Play(3);

            Rock.CounterFor = Scissors;
            Paper.CounterFor = Rock;
            Scissors.CounterFor = Paper;
        }

        // Prevent anyone creating copies of this.
        private Play(int points)
        {
            Points = points;
        }

        /// <summary>
        /// Win = 6, Draw = 3, Lose = 0 (pts).
        /// </summary>
        public enum Outcome
        {
            Win = 6,
            Draw = 3,
            Loose = 0
        }

        public int Points { get; private set; }
        private Play CounterFor { get; set; }

        public Outcome Against(Play other)
        {
            if (other == this)
            {
                return Outcome.Draw;
            }

            if (other == CounterFor)
            {
                return Outcome.Win;
            }

            return Outcome.Loose;
        }
    }
}