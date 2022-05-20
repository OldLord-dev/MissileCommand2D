using System.Collections;


public class Won : State
{
    public Won(GameSystem gameSystem) : base(gameSystem)
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