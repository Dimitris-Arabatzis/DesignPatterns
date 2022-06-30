using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    /// <summary>
    /// This is a better approach to MethodChain. 
    /// Uses Mediator pattern.
    /// </summary>
    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class Query
    {
        public string SoldierName;
        public Argument WhatToQuery;
        public int Value;

        public enum Argument
        {
            Attack, Defense
        }

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            SoldierName = creatureName;
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public class Soldier
    {
        private Game game; //Mediator
        public string Name;
        private int attack, defense;

        public Soldier(Game game, string name, int attack, int defense)
        {
            this.game = game;
            Name = name;
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }
        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(attack)}: {Attack}, {nameof(defense)}: {Defense}";
        }
    }

    public abstract class SoldierModifier : IDisposable
    {
        protected Game game;
        protected Soldier soldier;

        public SoldierModifier(Game game, Soldier soldier)
        {
            this.game = game;
            this.soldier = soldier;
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class SoldierDoubleAttackModifier : SoldierModifier
    {
        public SoldierDoubleAttackModifier(Game game, Soldier soldier ): base(game, soldier)
        {

        }

        protected override void Handle(object sender, Query q)
        {
            if (q.SoldierName == soldier.Name && q.WhatToQuery == Query.Argument.Attack)
                q.Value *= 2;
        }
    }

    public class SoldierIncreaseDefenseModifier : SoldierModifier
    {
        public SoldierIncreaseDefenseModifier(Game game, Soldier soldier) : base(game, soldier)
        {

        }

        protected override void Handle(object sender, Query q)
        {
            if (q.SoldierName == soldier.Name && q.WhatToQuery == Query.Argument.Defense)
                q.Value += 3;
        }
    }
}
