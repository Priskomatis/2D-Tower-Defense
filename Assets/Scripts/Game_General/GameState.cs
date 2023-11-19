using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {
    protected Game_Management gm;

    public GameState(Game_Management gm) {
        this.gm = gm;
    
    }

    public abstract void UpdateState();
    public virtual void OnStateEnter() { }
}
public class PlayingState : GameState
{
    public PlayingState(Game_Management gm) : base(gm) { }

    public override void UpdateState()
    {
        return;
    }
    public class GameOverState : GameState
    {
        public GameOverState(Game_Management gm) : base(gm) { }

        public override void UpdateState()
        {
            throw new System.NotImplementedException();
        }
        public override void OnStateEnter()
        {
            Debug.Log("Game Over!");
            return;
        }
    }

}
