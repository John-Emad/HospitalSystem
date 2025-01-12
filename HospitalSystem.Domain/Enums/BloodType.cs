using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Enums
{
    public class BloodTypeClass
    {
        public enum ABOBloodType
        {
            O,
            A,
            B,
            AB
        }

        // Enum for Rh factor
        public enum RhFactor
        {
            Positive,
            Negative
        }

        // Struct to represent a full blood type
        public struct BloodTypeStruct
        {
            public ABOBloodType ABO;
            public RhFactor Rh;

            public override string ToString()
            {
                return $"{ABO}{(Rh == RhFactor.Positive ? "+" : "-")}";
            }
        }

    }
}
