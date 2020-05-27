using System.Runtime.CompilerServices;
using System.Text;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Core
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Models.Presents;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories;
    using SantaWorkshop.Repositories.Contracts;
    using SantaWorkshop.Utilities.Messages;
    using SantaWorkshop.Core.Contracts;
    public class Controller : IController
    {
        private readonly IRepository<IDwarf> dwarfs;
        private readonly IRepository<IPresent> presents;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();

        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;
            if (dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);
            var result = String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            return result;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            IInstrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            var result = String.Format(OutputMessages.InstrumentAdded, power, dwarfName);
            return result;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            var result = String.Format(OutputMessages.PresentAdded, presentName);
            return result;
        }

        public string CraftPresent(string presentName)
        {
            var present = this.presents.FindByName(presentName);
            var dwarf = this.dwarfs.Models.OrderByDescending(x => x.Instruments.Sum(x => x.Power)).ThenByDescending(x=>x.Energy).FirstOrDefault(d => d.Energy >= 50);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            if (!present.IsDone())
            {
                this.workshop.Craft(present, dwarf);

            }
            if (dwarf.Energy == 0)
            {
                this.dwarfs.Remove(dwarf);
            }

            string result;
            if (present.IsDone())
            {
                result = String.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                result = String.Format(OutputMessages.PresentIsNotDone, presentName);
            }

            return result;

        }

        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.presents.Models.Count(x => x.IsDone())} presents are done");
            result.AppendLine($"Dwarfs info:");
            foreach (var dwarfs in this.dwarfs.Models)
            {
                result.AppendLine($"Name: {dwarfs.Name}");
                result.AppendLine($"Energy: {dwarfs.Energy}");
                result.AppendLine($"Instruments: {dwarfs.Instruments.Count(x => !x.IsBroken())} not broken left");
            }

            return result.ToString().TrimEnd();
        }
    }
}
