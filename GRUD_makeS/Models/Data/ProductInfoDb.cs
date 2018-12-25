﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Prism.Mvvm;


namespace GRUD_makeS.Models.Data
{
    class ProductInfoDb :BindableBase
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
        public int queue;
        public int execute;

        public int Queue
        {
            get => queue;
            set => SetProperty(ref queue, value);
        }

        public int Execute
        {
            get => execute;
            set => SetProperty(ref execute, value);
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
            Queue++;

            //System.Threading.Thread.Sleep(3000);            
            productInfos.Add(productInfo);
            var e = new DbChangedEventArgs(productInfo);

            Execute++;

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

        public void Search(string genre, string searchWord)
        {
            Clear.Invoke(this, EventArgs.Empty);

            switch (genre)
            {
                case "Name":
                              
                        var searchName = productInfos.Where(x => x.Name == searchWord).ToArray();

                        for (int i = 0; i < searchName.Length; i++)
                        {
                            var nameElement = searchName.ElementAt(i);
                            var eName = new DbChangedEventArgs(nameElement);
                            SearchChanged?.Invoke(this, eName);
                        }                    


                    break;

                case "Category":
                    var searchCategory = productInfos.Where(x => x.Category == searchWord).ToArray();
                    for (int i = 0; i< searchCategory.Length; i++)
                    {
                        var categoryElement = searchCategory.ElementAt(i);
                        var eCategory = new DbChangedEventArgs(categoryElement);
                        SearchChanged?.Invoke(this, eCategory);

                    }
                    break;

                case "Price":
                    var searchPrice = productInfos.Where(x => x.Price == int.Parse(searchWord)).ToArray();
                    for (int i = 0; i < searchPrice.Length; i++)
                    {
                        var priceElement = searchPrice.ElementAt(i);
                        var ePrice = new DbChangedEventArgs(priceElement);
                        SearchChanged?.Invoke(this, ePrice);

                    }
                    break;
            }



        }




        /* イベントのネーミングルールは時制句を入れる(ed,ing) */
        public event EventHandler<DbChangedEventArgs> AddChaged;

        public event EventHandler<DbChangedEventArgs>  RemoveChaged;

        public event EventHandler<DbChangedEventArgs> UpdateChaged;

        public event EventHandler<DbChangedEventArgs> SearchChanged;

        public event EventHandler<EventArgs> Clear;

    }
}
