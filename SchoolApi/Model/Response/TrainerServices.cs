using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Model.Response
{
    public class TrainerServices : ITrainer
    {
        private readonly SchoolContext Db;

        public TrainerServices(SchoolContext db)
        {
            this.Db = db;
        }
        async Task<Trainer> ITrainer.AddTrainer(Trainer trainer)
        {
            var response = await Db.Trainers.AddAsync(trainer);
            int status = await Db.SaveChangesAsync();
            if (status == 0)
                return null;
            else
                return response.Entity;
        }

        async Task<bool> ITrainer.DeleteTrainer(Trainer trainer)
        {
            int response = await Db.SaveChangesAsync();
            if (response == 0)
                return false;
            else
                return true;
        }

        async Task<IEnumerable<Trainer>> ITrainer.GetAllTrainers()
        {
            var response= await Db.Trainers.Where(trainer => trainer.Active == true).OrderByDescending(t => t.CreatedOn).ToListAsync();
            if(response.Count == 0 && response == null)
            {
                return null;
            }
            else
            {
                return response;
            }
        }

        async Task<Trainer> ITrainer.GetTrainerById(int trainerId)
        {
            var response = await Db.Trainers.Where(trainer => trainer.Active == true && trainer.TrainerId == trainerId).FirstOrDefaultAsync();
            if (response == null)
                return null;
            else
                return response;
        }

        async Task<bool> ITrainer.UpdateTrainer(Trainer trainer)
        {
            int response = await Db.SaveChangesAsync();
            if (response == 0)
                return false;
            else
                return true;
        }
    }
}
