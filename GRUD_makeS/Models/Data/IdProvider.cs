using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.Models.Data
{
    class IdProvider
    {
        static int id;

        public static int GenerateId ()
        {
            id++;
            return id;

        }


    }
}
