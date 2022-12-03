using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day2;

public class RockPaperScissorsGame
{
    public int TotalScorePlayer1 { get; }

    public RockPaperScissorsGame(IEnumerable<Round> rounds)
    {
        TotalScorePlayer1 = rounds.Sum(round => round.Points.Play1);
    }

    public static class StrategyGuide
    {
        private static readonly Dictionary<string, IPlay> _playAliases = new()
        {
            { "A", Play.Rock },
            { "B", Play.Paper },
            { "C", Play.Scissors }
        };

        private static readonly Dictionary<string, string> _counterAliases = new()
        {
            { "Y", "B" },
            { "X", "C" },
            { "Z", "A" }
        };

        public static Round[] ParseRoundsFrom(string strategyGuide)
        {
            return strategyGuide
                .SplitByEndOfLine()
                .Select(x => x.Split(' '))
                .Select(x => ToAround(x[0], x[1]))
                .ToArray();

            static Round ToAround(string playAlias, string counterAlias)
            {
                return new Round(_playAliases[playAlias], _playAliases[_counterAliases[counterAlias]]);
            }
        }
    }

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

        public IPlay Play1 {get;}
        public IPlay Play2 { get; }

        public Round(IPlay play1, IPlay play2)
        {
            Play1 = play1;
            Play2 = play2;
            Points = CalculateScore(play1, play2);
        }

        private Score CalculateScore(IPlay play1, IPlay play2)
        {
            var outcome = play1.Against(play2);

            const int maxPoints = (int)Play.Outcome.Win;
            var play1OutcomePoints = (int)outcome;
            var play2OutcomePoints = maxPoints - play1OutcomePoints;

            return new Score(play1OutcomePoints + play1.Points, play2OutcomePoints + play2.Points);
        }
    }

    public interface IPlay
    {
        Play.Outcome Against(IPlay other);
        int Points { get; }
    }

    public class Play : IPlay
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

        public int Points { get; }
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