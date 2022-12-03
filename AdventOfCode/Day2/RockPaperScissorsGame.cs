namespace AdventOfCode.Tests.Day2;

public class RockPaperScissorsGame
{
    public class Round
    {
        public struct Score
        {
            public readonly int Play1;
            public readonly int Play2;

            public Score(int play1, int play2)
            {
                Play1 = play1;
                Play2 = play2;
            }
        }

        public Score Points { get; }

        private readonly IPlay _play1;
        private readonly IPlay _play2;

        public Round(IPlay play1, IPlay play2)
        {
            _play1 = play1;
            _play2 = play2;
            Points = CalculateScore(play1, play2);
        }

        private Score CalculateScore(IPlay play1, IPlay play2)
        {
            var outcome = play1.Against(play2);

            const int maxPoints = (int)Play.Outcome.Win;
            var play1Points = (int)outcome;
            var play2Points = maxPoints - play1Points;

            return new Score(play1Points, play2Points);
        }
    }

    public interface IPlay
    {
        Play.Outcome Against(IPlay other);
    }

    public class Play: IPlay
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
        private IPlay CounterFor { get; set; }

        public Outcome Against(IPlay other)
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