using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.Models
{
    public class ItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }

    }
}
