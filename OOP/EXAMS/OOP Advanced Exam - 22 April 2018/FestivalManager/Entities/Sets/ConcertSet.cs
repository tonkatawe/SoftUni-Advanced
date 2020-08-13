namespace FestivalManager.Entities.Sets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;

    public abstract class ConcertSet:ISet
    {
        private readonly ICollection<IPerformer> performers;
        private readonly ICollection<ISong> songs;

        protected ConcertSet(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.MaxDuration = maxDuration;

            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; protected set; }

        public TimeSpan MaxDuration { get; protected set; }

        public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers.ToList().AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.ToList().AsReadOnly();

        public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

        public void AddSong(ISong song)
        {
            //Here I'm not sure for the checking but if doesn't work I will change the 'if'
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.Performers.Any())
            {
                return false;
            }

            if (!this.Songs.Any())
            {
                return false;
            }

            var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(", ", this.Performers));

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"-- {song}");
            }

            var result = sb.ToString();
            return result;
        }
    }
}
