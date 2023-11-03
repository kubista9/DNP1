using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao _postDao;
    private readonly IUserDao _userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
	    User? user = await _userDao.GetByIdAsync(dto.OwnerId);
	    if (user == null)
	    {
		    throw new Exception($"UserId {dto.OwnerId} was not found.");
	    }

	    Post post = new Post(user, dto.Title, dto.Body);
	    ValidatePost(post);
	    Post newPost = await _postDao.CreateAsync(post);
	    return newPost;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParamsDto searchParams)
    {
	    return _postDao.GetAsync(searchParams);
    }

    public async Task<PostClearDto> GetByIdAsync(int id)
    {
	    Post? post = await _postDao.GetByIdAsync(id);
	    if (post == null)
	    {
		    throw new Exception($"PostId {id} not found");
	    }

	    return new PostClearDto(post.Id, post.Owner.Username, post.Title, post.Body);
    }



    private void ValidatePost(Post post)
    {
        //validation for private instance variables
    }
}
