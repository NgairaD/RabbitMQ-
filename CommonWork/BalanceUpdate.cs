using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWork
{
    public class BalanceUpdate
    {
        public string TypeOfInstruction { get; set; }
        public decimal Amount { get; set; }

        public BalanceUpdate(string typeOfInstruction, decimal amount)
        {
            this.TypeOfInstruction = typeOfInstruction;
            this.Amount = amount;
        }

      
    }
}
