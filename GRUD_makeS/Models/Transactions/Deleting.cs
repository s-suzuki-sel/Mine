using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRUD_makeS.Models.Data;


namespace GRUD_makeS.Models.Transactions
{
    class Deleting
    {

        private readonly ProductInfoDb productInfoDb; 

        public Deleting(ProductInfoDb productInfoDb)
        {
            this.productInfoDb = productInfoDb;


        }
        public Deleting()
            :this(ProductInfoDb.Default)
        {

        }


        public void Execute(int id)
        {
            

            productInfoDb.Remove(id);

        }


    }
}
