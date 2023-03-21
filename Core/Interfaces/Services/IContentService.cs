﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IContenService
    {
        Task<Content> GetContentByIdAsync(int id);
        Task<IEnumerable<Content>> GetContentByNameAsync(string name);
        Task<IEnumerable<Content>> GetContentsAsync();
        Task CreateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId);
        Task UpdateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId);
        Task DeleteContentAsync(int id);

    }
}
