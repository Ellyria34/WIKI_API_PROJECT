using DTOs;
using IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Contexts;
using System.Data;


namespace Repositories.Repositories
{
    public class TopicRepository : TopicIRepository
    {
        private readonly WIKI_API_PROJECTDbContext _context;

        public TopicRepository(WIKI_API_PROJECTDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string topicname)
        {
            return await _context.Topics.AnyAsync(t => t.TopicName == topicname);
        }


        public async Task CreateAsync(CreateTopicDTO topicDTO)
        {
            if (topicDTO == null) throw new ArgumentNullException(nameof(topicDTO));
            else
            {
                if (await ExistsAsync(topicDTO.TopicName))
                {
                    throw new Exception("The topic name already exists in the database.");
                }

                Topic topic = new Topic
                {
                    TopicName = topicDTO.TopicName
                };
                await _context.Topics.AddAsync(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Topic>> GetAllTopicAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            Topic topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                return topic;
            }
            throw new ArgumentException();
        }


        public async Task DeleteTopicAsync(int id)
        {
            var nbRow = await _context.Topics.Where(t => t.TopicId == id)
                                                .ExecuteDeleteAsync();
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            var nbRow = await _context.Topics
                .Where(t => t.TopicId == topic.TopicId).ExecuteUpdateAsync(
                updates => updates
                    .SetProperty(t => t.TopicName, topic.TopicName));

            if (nbRow > 0)
                return topic;
            else throw new Exception();
        }
    }
}
