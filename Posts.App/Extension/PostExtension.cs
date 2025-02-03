using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posts.App.DTO;
using Posts.Repository.Model;

namespace Posts.App.Extension;

public static class PostExtension
{
    public static PostDTO ToDTO(this Post model)
    {
        return new PostDTO
        {
            UserId = model.UserId,
            Id = model.Id,
            Body = model.Body,
            Title = model.Title
        };
    }
}