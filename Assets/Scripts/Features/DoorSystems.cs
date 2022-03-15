using Systems.DoorMechanic;

namespace Features
{
    public class DoorMechanicSystems : Feature
    {
        public DoorMechanicSystems(Contexts contexts) : base("Door mechanic Systems")
        {
            Add(new GroundButtonPressSystem(contexts));
        }     
    }
}