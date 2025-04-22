using System;

namespace ZodiacApp
{
    [Serializable]
    public class ZNAK
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ZodiacSign { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, {ZodiacSign}, родился(ась) {BirthDate.ToShortDateString()}";
        }
    }
}