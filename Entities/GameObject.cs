using System.Collections.Generic;

namespace NakaEngine.Entities
{
    public sealed class GameObject
    {
        public int ID
        {
            get;
            set;
        }

        public List<Component> Components
        {
            get;
            set;
        }
    }
}
