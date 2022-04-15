using System;

namespace CRUD_In_MVC_New_Project.Models
{
    public class ErrorViewModel
    {
        public string Requestid { get; set; }

        public bool ShowRequestid => !string.IsNullOrEmpty(Requestid);
    }
}
