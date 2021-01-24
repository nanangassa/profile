using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace profile.Models
{
    public class CreateWallet
    {
            public string @private { get; set; }
            public string @public { get; set; }
            public string original_address { get; set; }
            public string wif { get; set; }
    }

}