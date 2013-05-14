using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenSharkCP.DTO
{
    public class UserDTO
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        private Boolean follow;

        public Boolean Follow
        {
            get { return follow; }
            set { follow = value; }
        }
    }
}
