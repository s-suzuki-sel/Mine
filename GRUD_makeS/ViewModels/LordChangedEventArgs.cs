using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.ViewModels
{
    class LordChangedEventArgs :EventArgs
    {
        /* eventargsは基本readonly */
        public string ImagePath { get; }

        public LordChangedEventArgs(string imagePath)
        {
            /* 対象になったデータの情報を通知する */

            ImagePath = imagePath;


        }

    }
}
