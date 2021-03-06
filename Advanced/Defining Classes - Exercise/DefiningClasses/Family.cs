﻿using System.Threading.Channels;

namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Family
    {
        private HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        //methods
        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = this.members.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldest;

        }

        public void GetAllAboveThirty(Family members)
        {
            foreach (var member in this.members.Where(x => x.Age > 30).OrderBy(x =>x.Name))
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }

        }

    }
}