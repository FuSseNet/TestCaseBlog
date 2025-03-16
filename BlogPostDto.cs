using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class BlogPostDto
    {
        public string PostName { get; set; }
        public DateTime DateLastComment { get; set; }
        public string LastCommentText { get; set; }

        public BlogPostDto(string postName, DateTime dateLastComment, string lastCommentText)
        {
            PostName = postName;
            DateLastComment = dateLastComment;
            LastCommentText = lastCommentText;
        }
    }
}
