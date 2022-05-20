using System.Collections;

public abstract class State
{
    protected GameSystem GameSystem;

    public State(GameSystem gameSystem)
    {
        GameSystem = gameSystem;
    }

    public virtual IEnumerator Start()
    {

        yield break;
    }

    public virtual IEnumerator Attack()
    {

        yield break;
    }
}
