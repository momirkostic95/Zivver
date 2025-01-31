using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zivver.App.DTO;
using Zivver.Repository.Model;

namespace Zivver.App.Extension;

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