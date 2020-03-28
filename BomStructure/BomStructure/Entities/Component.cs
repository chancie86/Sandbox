using System;
using System.Collections.Generic;
using System.Text;

namespace BomStructure.Entities
{
    public class Component
    {
        public Component(ComponentId id)
        {
            Id = id;
        }

        public ComponentId Id { get; }
    }
}
