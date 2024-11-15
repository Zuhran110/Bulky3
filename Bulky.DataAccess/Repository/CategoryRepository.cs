﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;

public class CategoryRepository:Repository<Category>,ICetogaryRepository
{
    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Category Category)
    {
        _db.Categories.Update(Category);
    }
}
