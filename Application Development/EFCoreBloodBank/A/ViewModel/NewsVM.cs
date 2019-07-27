using BloodBank.Classes;
using EFCoreBloodBank;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.ViewModel
{
    public class NewsVM
    {
        public ObservableCollection<News> NewsColl { get; set; }
        readonly MyDbContext _dbContext = new MyDbContext();
        public News news { get; set; }

        public NewsVM() { }

        public void AddNews(News news)
        {
            using (var db = new MyDbContext())
            {
                db.News.Add(news);
                db.SaveChanges();
            }
        }

        public void RetrieveAll()
        {
            using (var db = new MyDbContext())
            {
                NewsColl = new ObservableCollection<News>(db.News);
            }
        }

        public void RetrievebyId(int ID)
        {
            using (var db = new MyDbContext())
            {
                NewsColl = new ObservableCollection<News>(db.News.Where(b=>b.NewsId==ID));
            }
        }

        public void DeleteNews(int id)
        {
         using(var db = new MyDbContext())
            {
                News news = db.News.FirstOrDefault(x => x.NewsId == id);
                db.News.Remove(news);
                db.SaveChanges();

            }
        }

        public void UpdateNews(News naya)
        {
            using(var db=new MyDbContext())
            {
              
                db.News.Attach(naya);
                db.SaveChanges();
            }
        }
        

       
    }
  
    }
