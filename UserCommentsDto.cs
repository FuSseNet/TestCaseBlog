using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class UserCommentsDto
    {
        public string UserName { get; set; }
        public int NumberOfComments { get; set; } = 0;

        public UserCommentsDto(string username, int currentComment) {
            UserName = username;
            NumberOfComments += currentComment;
        }
    }
}
