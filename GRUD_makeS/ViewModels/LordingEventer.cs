using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.ViewModels
{
    class LordingEventer 
    {
        /* staticなプロパティでインラインで初期化するとほぼsingletonとなる */
        public static LordingEventer Default { get; } = new LordingEventer();

        public LordingEventer()
        {

        }

        public void Lord(string imagePath)
        {

            var e = new LordChangedEventArgs(imagePath);
            DataLorded?.Invoke(this, e);

        }
        /* イベントのネーミングルールは時制句を入れる(ed,ing) */
        public event EventHandler<LordChangedEventArgs> DataLorded;




    }
}