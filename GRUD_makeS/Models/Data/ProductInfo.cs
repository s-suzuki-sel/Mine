using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.Models.Data
{
    
    // DataGridに表示するデータ
    public class ProductInfo
    {
        /* Idを作る役目をもっていると、他で呼び出されたとき指定できない問題がある */
#if false
        private static int id;
        public int Id { get; } = id++;
#endif

        public int Id { get; set; } = IdProvider.GenerateId();
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

    }
    
}
