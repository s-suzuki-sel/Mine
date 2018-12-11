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
        private static int id;
        public int Id { get; } = id++;
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
    
}
