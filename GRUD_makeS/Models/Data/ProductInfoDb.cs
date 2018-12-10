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

        }


        public void Remove(ProductInfo productInfo)
        {
            productInfos.Remove(productInfo);

        }

        public void Update(ProductInfo productInfo)
        {

            /* class は参照型(Cでいうポインタ的な)なのでプロパティで書けば変更される　　値型(struct)だとコピーにいれちゃうのでできない */
            var found = productInfos.Find(x => x.Id == productInfo.Id);
            found.Name = productInfo.Name;
            found.Category = productInfo.Category;
            found.Price = productInfo.Price;
        }


    }
}
