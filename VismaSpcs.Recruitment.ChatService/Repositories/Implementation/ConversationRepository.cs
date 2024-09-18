using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VismaSpcs.Recruitment.ChatService.Context;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Implementation
{
    public class ConversationRepository : GenericRepository<ConversationEntity>, IConversationRepository
    {
        private readonly ChatServiceDbContext _dbContext;

        public ConversationRepository(ChatServiceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ConversationEntity?> GetAsync(Expression<Func<ConversationEntity, bool>> predicate)
        {
            return await _dbContext.Set<ConversationEntity>()
                .Include(c => c.Messages)
                .Include(c => c.Participants)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<ConversationEntity> AddConversation(ConversationEntity conversation)
        {
            await _dbContext.Set<ConversationEntity>().AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            return conversation;
        }

        public async Task AddMessageToConversation(MessageEntity message)
        {
            var conversation = await GetAsync(c => c.Id == message.ConversationId);

            if (conversation != null)
            {
                conversation.Messages.Add(message);
                _dbContext.Update(conversation);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}