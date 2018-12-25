using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace GRUD_makeS.Models.Data
{
    /* ルール：eventArgsを継承したら名前はxxeventArgsにする */
    class SearchEventArgs : EventArgs
    {
        /* eventargsは基本readonly */
        public List<ProductInfo> ProductInfo { get; }

        public SearchEventArgs(List<ProductInfo> productInfos)
        {
            /* 対象になったデータの情報を通知する */

            ProductInfo = productInfos;


        }

        public static implicit operator ReactiveCollection<object>(SearchEventArgs v)
        {
            throw new NotImplementedException();
        }
    }
}
