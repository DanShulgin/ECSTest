using Entitas;
using Services;

public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base("Input Systems")
    {
        Add(new EmitInputSystem(contexts));
    }         
}