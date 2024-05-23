using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Controllers
{
    [Route("api/Trainer")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainer trainer;

        public TrainerController(ITrainer trainer)
        {
            this.trainer = trainer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var respone=await trainer.GetAllTrainers();
            if(respone==null)
                return NoContent();
            return Ok(respone);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id==0 || id==null)
                return BadRequest();
            var respone = await trainer.GetTrainerById(id);
            if (respone == null)
                return NoContent();
            return Ok(respone);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Trainer trainer1)
        {
            if(trainer==null)
                return BadRequest();
                var response = await trainer.AddTrainer(trainer1);
                if (response == null)
                    return BadRequest(trainer);
                return Created("Trainer", response);
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(Trainer newtrainer)
        {
            if(newtrainer==null)
                return BadRequest();
            var oldtrainer=await trainer.GetTrainerById(newtrainer.TrainerId);
            if(oldtrainer==null)
                return NotFound();
            else
            {
                oldtrainer.FirstnameName = newtrainer.FirstnameName;
                oldtrainer.LastName=newtrainer.LastName;    
                oldtrainer.Mobilenumber = newtrainer.Mobilenumber;
                oldtrainer.EmailId= newtrainer.EmailId;
                oldtrainer.Subject = newtrainer.Subject;
                oldtrainer.Active = newtrainer.Active;
                oldtrainer.UpdateBy = 1;
                oldtrainer.UpdateOn=DateTime.Now;
              bool response=  await trainer.UpdateTrainer(oldtrainer);
                if (!response)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
               
        }
        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            Trainer deltrainer =await trainer.GetTrainerById(id);
            if(deltrainer==null) 
                return NotFound();
            else
            {
                deltrainer.UpdateOn= DateTime.Now;
                deltrainer.UpdateBy= 1;
                deltrainer.Active = false;
                bool response = await trainer.DeleteTrainer(deltrainer);
                if(!response)
                    return BadRequest(response);
                else
                return Ok(response);//inspect this result what we get in this result
            }
        }
    }
}
