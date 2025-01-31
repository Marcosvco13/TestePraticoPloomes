﻿using TestePraticoPloomes.Context;

namespace TestePraticoPloomes.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
