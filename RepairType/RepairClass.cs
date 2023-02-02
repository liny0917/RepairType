using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairType
{
    public class RepairClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string SortOrder { get; set; }
        public bool IsActive {  get; set; }
        public string CreateUser {  get; set; }
        public DateTime CreatedTime {  get; set; }
        public string UpdateUser {  get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
