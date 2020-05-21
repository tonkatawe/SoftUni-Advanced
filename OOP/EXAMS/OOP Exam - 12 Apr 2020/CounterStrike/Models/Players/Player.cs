namespace CounterStrike.Models.Players
{
    using System;
    using CounterStrike.Utilities.Messages;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Players.Contracts;

   public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        private bool isAlive;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get => this.username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                if (this.gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive
        {
            get => this.isAlive;
            private set
            {
                if (this.health > 0)
                {
                    this.isAlive = true;
                }
                else
                {
                    this.isAlive = false;
                }
            }
        }

        public void TakeDamage(int points)
        {
            if (this.armor > 0)
            {
                var currentArmor = this.armor;
                this.armor -= points;
                points -= currentArmor;
            }

            if (this.armor <= 0 && points > 0)
            {
                var currentHealth = this.health;
                this.health -= points;
                points -= currentHealth;
            }

            if (this.health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
