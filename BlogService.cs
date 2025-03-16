using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog
{
    public class BlogService
    {
        public static IList<UserCommentsDto> NumberOfCommentsPerUser(MyDbContext context)
        {
            return context.BlogPosts
                .SelectMany(post => post.Comments)
                .GroupBy(comment => comment.UserName)
                .Select(group => new UserCommentsDto(group.Key, group.Count()))
                .ToList();
        }

        public static IList<BlogPostDto> PostsOrderedByLastCommentDate(MyDbContext context)
        {

            var result = (from post in context.BlogPosts.OrderByDescending(post => post.Comments.Max(comment => comment.CreatedDate))
                          let lastComment = post.Comments.OrderByDescending(c => c.CreatedDate).FirstOrDefault()
                          select new BlogPostDto(post.Title, lastComment.CreatedDate, lastComment.Text)).ToList();

            return result;
        }

        public static IList<UserCommentsDto> NumberOfLastCommentsLeftByUser(MyDbContext context)
        {
            var result = (from post in context.BlogPosts
                      let lastComment = post.Comments.OrderByDescending(comment => comment.CreatedDate).FirstOrDefault()
                      where lastComment != null
                      group lastComment by lastComment.UserName into g
                      select new UserCommentsDto(g.Key, g.Count())).ToList();
            
            return result;
        }
    }
}
