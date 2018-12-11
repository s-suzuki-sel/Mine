using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRUD_makeS.Models.Data;

namespace GRUD_makeS.Models.Transactions
{
    class Updating
    {

        public readonly ProductInfoDb productInfoDb;

        public Updating(ProductInfoDb productInfoDb)
        {
            this.productInfoDb = productInfoDb;


        }
        public Updating()
            : this(ProductInfoDb.Default)
        {

           
        }



        public void Execute(int id ,string name,string category,int price)
        {
            productInfoDb.Update(id, name, category, price);


        }

    }
}
