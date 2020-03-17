using System;
using System.Collections.Generic;
using System.Text;

namespace AliceHeroDay.Model.SuperHeroDay
{
    public class SuperHero
    {
        public int Id { get; set; }

        public string Universe { get; set; }

        public string RealName { get; set; }

        public string HeroicName { get; set; }

        public DateTime DebutDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string History { get; set; }

        public List<Facts> Facts { get; set; }

        public string DebutComicBook { get; set; }

        public int DebutComicBookNumber { get; set; }
    }
}
