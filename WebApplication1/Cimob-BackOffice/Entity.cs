using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimob_BackOffice
{
    public class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private int entityId;
        public int EntityId
        {
            get
            {
                return entityId;
            }
            set
            {
                entityId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntityId"));
            }
        }

        private string entityName;
        public string EntityName
        {
            get
            {
                return entityName;
            }
            set
            {
                entityName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntityName"));
            }
        }

        override
        public string ToString()
        {
            return (EntityId + "- " + EntityName
                );
        }

        public Entity() : this(0, "N/A")
        {

        }

        public Entity(string name) : this(0, name)
        {

        }

        public Entity(int entityId, string name)
        {
            EntityId = entityId;
            EntityName = name;
        }

        public Entity(Entity entity)
        {
            EntityId = entity.entityId;
            EntityName = entity.entityName;

        }
    }
}
