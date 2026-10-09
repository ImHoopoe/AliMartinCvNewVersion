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


        public async Task<bool> Create(Article article)
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

        public async Task<bool> Delete(Article article)
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

        public async Task<Article> GetArticle(int articleId)
        {
            return await _context.Articles.FindAsync(articleId);
        }

        public async Task<Article> GetArticle(string slug)
        {
            return await _context.Articles.SingleOrDefaultAsync(a=> a.Slug == slug);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<bool> Update(Article article)
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
