using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day2;

public class RockPaperScissorsGame
{
    /// <summary>
    /// Your score.
    /// </summary>
    public int TotalScorePlayer2 { get; }

    public RockPaperScissorsGame(IEnumerable<Round> rounds)
    {
        TotalScorePlayer2 = rounds.Sum(round => round.Points.Player2);
    }

    /// <summary>
    /// Strategy guide with plays to achieve a specified outcome.
    /// </summary>
    public class StrategyGuideV2 : StrategyGuide
    {
        public StrategyGuideV2(string strategyGuide) : base(strategyGuide)
        {
        }

        private readonly Dictionary<string, Play.Outcome> _neededOutcomeAliases = new()
        {
            { "X", Play.Outcome.Loose },
            { "Y", Play.Outcome.Draw },
            { "Z", Play.Outcome.Win }
        };

        protected override Round ParseRoundFromLineInGuide(string[] lineInGuide)
        {
            var play1 = _playAliases[lineInGuide[0]];
            var outcome = _neededOutcomeAliases[lineInGuide[1]];

            IPlay playToMake;
            if (outcome == Play.Outcome.Draw)
            {
                playToMake = play1;
            }
            else if (outcome == Play.Outcome.Loose)
            {
                playToMake = play1.CounterFor;
            }
            else
            {
                playToMake = play1.CounterFor.CounterFor;
            }

            return new Round(play1, playToMake);
        }
    }

    /// <summary>
    /// Strategy guide with plays recommended to play.
    /// </summary>
    public class StrategyGuideV1 : StrategyGuide
    {
        public StrategyGuideV1(string strategyGuide) : base(strategyGuide)
        {
        }

        private readonly Dictionary<string, IPlay> _counterAliases = new()
        {
            { "X", Play.Rock },
            { "Y", Play.Paper },
            { "Z", Play.Scissors }
        };

        protected override Round ParseRoundFromLineInGuide(string[] lineInGuide)
        {
            return new Round(_playAliases[lineInGuide[0]], _counterAliases[lineInGuide[1]]);
        }
    }

    public abstract class StrategyGuide
    {
        public IEnumerable<Round> Rounds { get; }

        protected StrategyGuide(string strategyGuide)
        {
            Rounds = ParseRoundsFrom(strategyGuide);
        }

        protected static readonly Dictionary<string, IPlay> _playAliases = new()
        {
            { "A", Play.Rock },
            { "B", Play.Paper },
            { "C", Play.Scissors }
        };

        protected IEnumerable<Round> ParseRoundsFrom(string strategyGuide)
        {
            return strategyGuide
                .SplitByEndOfLine()
                .Select(x => x.Split(' '))
                .Select(ParseRoundFromLineInGuide)
                .ToArray();
        }

        protected abstract Round ParseRoundFromLineInGuide(string[] lineInGuide);
    }

    public class Round
    {
        public struct Score
        {
            public readonly int Play1;
            public readonly int Player2;

            public Score(int play1, int player2)
            {
                Play1 = play1;
                Player2 = player2;
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
        IPlay CounterFor { get; }
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
        public IPlay CounterFor { get; set; }

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