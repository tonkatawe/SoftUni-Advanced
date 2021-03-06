﻿

using System.Collections.Generic;
using HAD.Contracts;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem, IRecipe
    {


        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems)
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {

            this.RequiredItems = requiredItems;
        }

        public IReadOnlyList<string> RequiredItems { get; private set; }

    }
}
