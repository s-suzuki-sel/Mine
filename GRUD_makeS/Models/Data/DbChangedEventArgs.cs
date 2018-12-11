using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.Models.Data
{
    /* ルール：eventArgsを継承したら名前はxxeventArgsにする */
    class DbChangedEventArgs :EventArgs
    {
        /* eventargsは基本readonly */
        public ProductInfo ProductInfo { get; }

        public DbChangedEventArgs(ProductInfo productInfo)
        {
            /* 対象になったデータの情報を通知する */

            ProductInfo = productInfo;


        }

    }
}
