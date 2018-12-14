using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.Models.Data
{
    class ProductInfoDb
    {
        /* staticなプロパティでインラインで初期化するとほぼsingletonとなる */
        public static ProductInfoDb Default { get; } = new ProductInfoDb();

        /* フィールドの時はスモールキャメル派とアンスコ派がいるがSE研はスモールキャメル */

        private readonly List<ProductInfo> productInfos = new List<ProductInfo>();

        public ProductInfoDb()
        {
            /* .AsReadOnlyすれば外部からcastでリストがよばれても取り出せなくなる */
            ProductInfos = productInfos.AsReadOnly();
        }

        public IReadOnlyList< ProductInfo>  ProductInfos { get;}

        public void Add(ProductInfo productInfo)
        {
            productInfos.Add(productInfo);
            var e = new DbChangedEventArgs(productInfo);
            AddChaged?.Invoke(this, e);
        }

        public void AddAsync(ProductInfo productInfo)
        {
            System.Threading.Thread.Sleep(3000);            
            productInfos.Add(productInfo);
            var e = new DbChangedEventArgs(productInfo);
            AddChaged?.Invoke(this, e);
            
        }


        public void Remove(ProductInfo productInfo)
        {
            productInfos.Remove(productInfo);
            var e = new DbChangedEventArgs(productInfo);
            RemoveChaged?.Invoke(this, e);
        }

        public void Remove(int id)
        {
            var removeData = this.ProductInfos.First(x => x.Id == id);
            Remove(removeData);
        }


        public void Update(int id, string name, string category, int price)
        {

            /* class は参照型(Cでいうポインタ的な)なのでプロパティで書けば変更される　　値型(struct)だとコピーにいれちゃうのでできない */
            var productInfo = new ProductInfo
            {
                Id = id,
                Name = name,
                Category = category,
                Price = price
            };

            Update(productInfo);
        }


        public void Update(ProductInfo productInfo)
        {

            /* class は参照型(Cでいうポインタ的な)なのでプロパティで書けば変更される　　値型(struct)だとコピーにいれちゃうのでできない */
            var found = productInfos.Find(x => x.Id == productInfo.Id);
            found.Name = productInfo.Name;
            found.Category = productInfo.Category;
            found.Price = productInfo.Price;

            var e = new DbChangedEventArgs(found);
            UpdateChaged?.Invoke(this, e);
        }
        /* イベントのネーミングルールは時制句を入れる(ed,ing) */
        public event EventHandler<DbChangedEventArgs> AddChaged;

        public event EventHandler<DbChangedEventArgs>  RemoveChaged;

        public event EventHandler<DbChangedEventArgs> UpdateChaged;
    }
}
