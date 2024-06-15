using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    [BindProperties(SupportsGet = true)]
    public class Medicine
    {
        [Required]
        public string medicine_id { get; set; }
       
        public string medicine_name { get; set; }
        public string quantity { get; set; }
        public string dose{ get; set; }

        public string category { get; set; }
        public string price { get; set; }
    }


    

}
