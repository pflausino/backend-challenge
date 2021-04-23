using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.Entities
{
    public class City : Entity
    {
        public City(string name, string state)
        {
            Name = name;
            SetState(state);

        }

        public string Name { get; private set; }
        public string State { get; private set; }
        public string DisplayName { get => GetDisplayName();}

        public void SetState(string state)
        {
            State = state.ToUpper();

        }

        private string  GetDisplayName()
        {
            var displayName = $"{Name}-{State}";

            return displayName;

        }
    }
}