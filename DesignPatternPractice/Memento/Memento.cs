using MorganMWJ.DesignPatternPracitce.Prototype_Clone;
using System.Reflection.Metadata.Ecma335;

namespace DesignPatternPractice.Memento;


internal class GameClient
{
    private PlayerCharacter _player;
    private IList<IMemento<State>> _playerHistory;

    public GameClient()
    {
        _player = new PlayerCharacter();
        _playerHistory = new List<IMemento<State>>();
    }

    /// <summary>
    /// Go back in the saved history of the player/game state.
    /// </summary>
    /// <param name="resets">Number of saves to reset to. 
    /// resets=3 goes back to 3rd most recent save point.</param>
    public void UndoPlayerSave(int resets)
    {
        var hist = _playerHistory.Reverse();
        var stateToRestore = hist.ElementAt(resets-1);
        _player.Restore(stateToRestore);
    }

    internal void LevelUpAndSave()
    {
        // Save into history
        var oldState = _player.Save(); // new object with old state
        _playerHistory.Add(oldState);

        //Update state of originator (playercharacter)
        _player.LevelUp();
    }

    public override string ToString()
    {
        return _player.ToString();
    }
}


internal interface IMemento<T> where T : IDeepCloneable
{
    T State { get; }
}

internal class Memento<T> : IMemento<T> where T : IDeepCloneable
{
    private readonly T _state;

    public Memento(T state)
    {
        // deep clone this
        _state = (T) state.DeepClone();
    }

    public T State => _state;
}

internal class PlayerCharacter
{
    private State _state;

    public PlayerCharacter()
    {
        _state = new State
        {
            PlayerName = "Morgan",
            Level = 9,
            PlayerHealth = 270
        };

    }

    public IMemento<State> Save()
    {
        return new Memento<State>(_state);
    }

    public void Restore(IMemento<State> memento)
    {
        _state = memento.State;
    }

    internal void LevelUp()
    {
        _state.Level++;
        _state.PlayerHealth += 30;
    }

    public override string ToString()
    {
        return $"Player: {_state.PlayerName}, Level: {_state.Level}, Health: {_state.PlayerHealth}";
    }
}

/// <summary>
/// State of player - could be holding state of anything just POCO
/// </summary>

internal class State : IDeepCloneable
{
    internal int Level { get; set; }
    internal int PlayerHealth { get; set; }
    internal required string PlayerName { get; set; }

    public IDeepCloneable DeepClone()
    {
        return new State { PlayerName = PlayerName, PlayerHealth = PlayerHealth, Level=Level };
    }
}