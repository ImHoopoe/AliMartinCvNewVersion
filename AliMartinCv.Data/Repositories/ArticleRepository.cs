using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AliMartinCvContext _context;
        public ArticleRepository(AliMartinCvContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateAsync(Article article)
        {
            try
            {
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Article article)
        {
            try
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<Article> GetArticleAsync(int articleId)
        {
            return await _context.Articles.Include(article=> article.ArticleGroup).SingleOrDefaultAsync(article => article.Id==articleId);
        }

        public async Task<Article> GetArticleAsync(string slug)
        {
            return await _context.Articles.SingleOrDefaultAsync(a=> a.Slug == slug);
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _context.Articles.Include(article=> article.ArticleGroup).ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Articles.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(Article article)
        {
            try
            {
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


    }
}
