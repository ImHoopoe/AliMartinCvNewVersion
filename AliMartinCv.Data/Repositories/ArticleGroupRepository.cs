using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Data.Repositories
{
    public class ArticleGroupRepository : IArticleGroupRepository
    {
        private readonly AliMartinCvContext _context;
        public ArticleGroupRepository(AliMartinCvContext context)
        {
            _context = context;
        }



        public async Task<bool> CreateAsync(ArticleGroup articleGroup)
        {
            try
            {
                await _context.ArticleGroups.AddAsync(articleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(ArticleGroup articleGroup)
        {
            try
            {
                _context.ArticleGroups.Remove(articleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<ArticleGroup> GetArticleGroupAsync(int articleGroupId)
        {
            return await _context.ArticleGroups.FindAsync(articleGroupId);
        }

        public async Task<IEnumerable<ArticleGroup>> GetArticleGroupsAsync()
        {
           return await _context.ArticleGroups.ToListAsync();
        }

        public async Task<bool> UpdateAsync(ArticleGroup articleGroup)
        {
            try
            {
                _context.ArticleGroups.Update(articleGroup);
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
