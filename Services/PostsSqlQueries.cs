

namespace PostsApi.Services;

public class PostsSqlQueries
{   
    public const string CREATEPOST = 
    @"INSERT INTO 
    public.Posts (Content,Datetime) 
    VALUES (@Content, @DateTime) 
    RETURNING id";

    public const string SELECTFROMPOSTS = 
    @"SELECT id, content, datetime
    FROM public.Posts";

    public const string SELECTPOSTWHEREID = 
    @"SELECT id, content, datetime
    FROM public.Posts
    WHERE id=@id";

    public const string UPDATEPOSTWHEREID = 
    @"UPDATE public.Posts 
    SET Content=@Content, 
        Datetime=@DateTime 
    WHERE id=@Id";

    public const string DELETEPOSTWHEREID = 
    @"DELETE 
    FROM public.Posts
    WHERE id=@Id";

}