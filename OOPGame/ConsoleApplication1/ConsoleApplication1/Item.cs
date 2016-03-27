using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Item : IFoundOut
    {
        private readonly int _damage;
        private readonly string _name;
        private readonly int _points;
        private readonly int _healthpoints;

        //свойства определящи характеристиката на предметите
        public int Damage
        {
            get { return _damage; }
        }
        public string Name
        {
            get { return _name; }
        }
        public int Points
        {
            get { return _points; }
        }
        public int HealthPoints
        {
            get { return _healthpoints; }
        }
        



        //  конструктор
        public Item(int damage, string name, int points, int healthpoints)
        {
            _damage = damage;
            _name = name;
            _points = points;
            _healthpoints = healthpoints;
        }


        //Метод който се активира при намирането на предмет и се импламентира от интерфеса IFoundOut
        public abstract void Activate(Player player);
        
    }
}
