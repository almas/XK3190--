using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Model
{
    public class OpersModel
    {
        public int Id { get; set; }

        public string userName { get; set; }
        public string OperName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isRepoter { get; set; }
        public bool stopped { get; set; }
        public string jobNumber { get; set; }

        public string isAdminStr { get { return isAdmin ? "是" : "否"; } }
        public string jobStation { get; set; }
    }
}
