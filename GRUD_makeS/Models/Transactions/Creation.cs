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


        private Creation(ProductInfoDb productInfoDb)
        {
            this.productInfoDb = productInfoDb;
            


        }
        /* thisは別のコンストラクタを呼び出す */
        public Creation()
            :this(ProductInfoDb.Default)
        {


        }


        public void Execute(string name,string category ,int price)
        {
            var productinfo = new ProductInfo
            {
                Name = name,
                Category = category,
                Price = price
            };

            productInfoDb.Add(productinfo);

        }



    }
}
