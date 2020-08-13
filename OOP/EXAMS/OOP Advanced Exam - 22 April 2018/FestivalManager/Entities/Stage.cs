
using System.Security.Cryptography.X509Certificates;

namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly ICollection<ISet> sets;
        private readonly ICollection<ISong> songs;
        private readonly ICollection<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.ToList().AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.ToList().AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.ToList().AsReadOnly();
        public IPerformer GetPerformer(string name) => this.performers.FirstOrDefault(x => x.Name == name);

        public ISong GetSong(string name) => this.songs.FirstOrDefault(x => x.Name == name);

        public ISet GetSet(string name) => this.sets.FirstOrDefault(x => x.Name == name);

        public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

        public void AddSong(ISong song) => this.songs.Add(song);

        public void AddSet(ISet performer) => this.sets.Add(performer);

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(x => x.Name == name);

            if (performer == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(x => x.Name == name);

            if (song==null)
            {
                return false;
            }
            return true;
        }

        public bool HasSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(x => x.Name == name);

            if (set == null)
            {
                return false;
            }

            return true;
        }
    }
}
