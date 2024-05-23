namespace SchoolApi.Model.IResponse
{
    public interface ITrainer
    {
        public Task<IEnumerable<Trainer>> GetAllTrainers();
        public Task<Trainer> GetTrainerById(int trainerId);
        public Task<Trainer> AddTrainer(Trainer trainer);
        public Task<bool> UpdateTrainer(Trainer trainer);
        public Task<bool> DeleteTrainer(Trainer trainer);
    }
}
