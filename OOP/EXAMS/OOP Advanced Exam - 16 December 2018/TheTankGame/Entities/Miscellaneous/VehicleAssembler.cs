﻿using System.Reflection.Metadata.Ecma335;
using TheTankGame.Entities.Parts;

namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    //might be it can be change to only Assembler name but I will see after later
    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();

        public double TotalWeight
        {
            get
            {
                double totalWeight = 0;
                if (this.ArsenalParts.Count != 0)
                {
                    totalWeight += this.ArsenalParts.Sum(x => x.Weight);
                }

                if (this.EnduranceParts.Count != 0)
                {
                    totalWeight += this.EnduranceParts.Sum(x => x.Weight);
                }

                if (this.ShellParts.Count != 0)
                {
                    totalWeight += this.ShellParts.Sum(x => x.Weight);
                }

                return totalWeight;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                if (this.ArsenalParts.Count != 0)
                {
                    totalPrice += this.ArsenalParts.Sum(x => x.Price);
                }

                if (this.EnduranceParts.Count != 0)
                {
                    totalPrice += this.EnduranceParts.Sum(x => x.Price);
                }

                if (this.shellParts.Count != 0)
                {
                    totalPrice += this.ShellParts.Sum(x => x.Price);
                }
                return totalPrice;
            }

        }

        public long TotalAttackModification
             => this.ArsenalParts.Any() ? this.ArsenalParts.Sum(x => x.AttackModifier) : 0;

        public long TotalDefenseModification
             => this.ShellParts.Any() ? this.ShellParts.Sum(x => x.DefenseModifier) : 0;

        public long TotalHitPointModification
             => this.ShellParts.Any() ? this.ShellParts.Sum(x => x.DefenseModifier) : 0;

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.arsenalParts.Add((IAttackModifyingPart)arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.shellParts.Add((IDefenseModifyingPart)shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.enduranceParts.Add((IHitPointsModifyingPart)endurancePart);
        }
    }
}