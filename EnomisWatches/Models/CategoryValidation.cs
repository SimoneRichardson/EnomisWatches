using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //step 1: add using for data annotations
namespace EnomisWatches.Models
{
    //steo3: add metadatatype
    [MetadataType(typeof(CategoryValidation))]
    public partial class Category { } //step3: create the
    
        
        
    
    public class CategoryValidation
    {
        //Step 4: get the properties from the .edmx>.tt file

        //Step 5: fill in the Data Annotations for the properties
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [Display(Name="Parent Category")]
        public Nullable<int> ParentID { get; set; }



        [Display(Img= "Parent Image")]
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        
        [Required, nvarchar(200)]
        public string ImageURL { get; set; }
        
        [Required, nvarchar
        public string Description { get; set; }
    }

}