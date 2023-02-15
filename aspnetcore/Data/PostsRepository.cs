using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace aspnetcore.Data
{
    internal static class PostsRepository
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        internal async static Task<Post> GetPostByAsync(int postid)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts
                    .FirstOrDefaultAsync(post => post.PostId == postid);
            }

        }

        internal async static Task<bool> CreatePostAsynk(Post postToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Posts.AddAsync(postToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostAsynk(Post postToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(postToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsynk(int postId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Post postToDelete = await GetPostByAsync(postId);
                    db.Remove(postToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

    }
}
