using System.Collections;

public class Lost : State
{
    public Lost(GameSystem gameSystem) : base(gameSystem)
    {
    }

    public override IEnumerator Start()
    {
        if (GameSystem.Interface.GetSliderValue() == 0)
        {

        }
        yield break;
    }
}