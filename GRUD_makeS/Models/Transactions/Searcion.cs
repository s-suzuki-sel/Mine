using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRUD_makeS.Models.Data;

namespace GRUD_makeS.Models.Transactions
{
    class Searcion
    {
        private readonly ProductInfoDb productInfoDb;


        private Searcion(ProductInfoDb productInfoDb)
        {
            this.productInfoDb = productInfoDb;



        }
        /* thisは別のコンストラクタを呼び出す */
        public Searcion()
            : this(ProductInfoDb.Default)
        {


        }


        public void Execute(string genre , string searchWord)
        {


            productInfoDb.Search(genre,searchWord) ;
            

        }



    }
}
