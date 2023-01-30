namespace BugTracker_Backend.Services
{
    public class BTInviteService : IBTInviteService
    {
        private readonly ApplicationDbContext _context;

        public BTInviteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async bool AcceptInviteAsync(Guid? token, string userId, int companyId)
        {
            Invite invite = await _context.Invites.FirstOrDefaultAsync(i => i.CompanyToken == token);

            if(invite == null)
            {
                return false;
            }

            try
            {
                invite.isValid = false;
                invite.InviteeId = userId;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async AddNewInviteAsync(Invite invite)
        {
            try
            {
                invite.isValid = false;
                invite.InviteeId = userId;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async bool AddInviteAsync(Guid? token, string email int companyId)
        {
            try
            {
                await _context.Invites.AddAsync(invite);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool AnyInviteAsync(Guid token, string email, int companyId)
        {
            try
            {
                bool result = await _context.Invites.Where(i=> i.companyId == companyId)
                                                    .AnyAsync(i => i.CompanyToken == token && i.inviteeEmail == email); 
                                                    
                return invite;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<Invite> GetInviteAsync(int inviteId, int companyId)
        {
            try
            {
                Invite invite = await _context.Invites.Where(i=> i.companyId == companyId)
                                                    .Include(i => i.Company)
                                                    .Include(i => i.Project)
                                                    .Include(i => i.Invitor)
                                                    .FirstOrDefaultAsync(i => i.Id == inviteId);

                                                    
                return invite;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Invite> GetInviteAsync(Guid? token, string email, int companyId)
        {
            try
            {
                Invite invite = await _context.Invites.Where(i=> i.companyId == companyId)
                                                    .Include(i => i.Company)
                                                    .Include(i => i.Project)
                                                    .Include(i => i.Invitor)
                                                    .FirstOrDefaultAsync(i => i.CompanyToken == token && i.inviteeEmail == email);
                                                    
                return invite;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateInviteCodeAsync(Guid? token)
        {
            if(token == null)
            {
                return false;
            }

            bool result = false;

            Invite invite = await  _context.Invites.FirstOrDefaultAsync(i => i.CompanyToken == token);

            if(invite != null)
            {
                //determine invite date
                DateTime inviteDate = invite.InviteDate.DateTime;

                if(validDate)
                {
                    result = invite.isValid;
                }

                return result;
            }
        }
    }
}