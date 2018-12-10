using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRUD_makeS.Models.Data;


namespace GRUD_makeS.Models.Transactions
{
    class Creation
    {

        private readonly ProductInfoDb productInfoDb;


        public Creation(ProductInfoDb productInfoDb)
        {
            this.productInfoDb = productInfoDb;
            


        }


        public void Execute ()
        {
            var productinfo = new ProductInfo();

            productInfoDb.Add(productinfo);

        }



    }
}
