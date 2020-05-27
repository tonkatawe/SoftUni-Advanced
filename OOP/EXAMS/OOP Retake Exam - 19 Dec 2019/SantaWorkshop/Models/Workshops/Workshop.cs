
namespace SantaWorkshop.Models.Workshops
{
    using System.Linq;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            var currentInstrument = dwarf.Instruments.FirstOrDefault(x => !x.IsBroken());
            if (dwarf.Energy > 0 && currentInstrument != null)
            {
                while (present.EnergyRequired > 0 && currentInstrument != null && dwarf.Energy > 0 && !currentInstrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    currentInstrument.Use();
                    if (currentInstrument.IsBroken())
                    {
                        currentInstrument = dwarf.Instruments.FirstOrDefault(x => !x.IsBroken());
                    }
                }
            }

        }
    }
}
