using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sarfati.Core.Dto;
using Sarfati.Core.Enum;
using Sarfati.Core.Handlers;

namespace Sarfati.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly ILogger<ParentController> _logger;
        private readonly IMediator _mediator;

        public ParentController(ILogger<ParentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/addchild")]
        public async Task<ActionResult<AddChildResponse>> AddChild(AddChildDto dto)
        {
            string parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new AddChildRequest
            {
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                ParentId = parentId,
                Gender = dto.Gender,
                Avatar = dto.Avatar,
                Color = dto.Color,
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("/deletechild")]
        public async Task<ActionResult<bool>> DeleteChild(DeleteChildRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    
        [HttpPost]
        [Route("/generateChildToken")]
        public async Task<ActionResult<GenerateChildTokenResponse>> GenerateChildToken(GenerateChildTokenDto dto)
        {
            string parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new GenerateChildTokenRequest
            {
                ChildId = dto.ChildId,
                ParentId = parentId
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("/deleteparent")]
        public async Task<ActionResult<bool>> DeleteParent()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var userType = User.FindFirstValue(JwtRegisteredClaimNames.Typ);

            var result = await _mediator.Send(new DeleteParentRequest { Id = userId });
            return Ok(result);
        }
        [HttpPost]
        [Route("/updateParent")]
        public async Task<IActionResult> UpdateParent(UpdateParentDto dto)
        {
            var parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new UpdateParentRequest
            {
                ParentId = parentId,
                Avatar = dto.Avatar
            });
            return Ok(result);
        }

   
        //Shared API
        [HttpPost]
        [Route("/home")]
        public async Task<ActionResult<HomeResponse>> Home(HomeDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var userType = User.FindFirstValue(JwtRegisteredClaimNames.Typ);
            var result = await _mediator.Send(new HomeRequest
            {
                DeviceId = dto.DeviceId,
                Subscribe = dto.Subscribe,
                UserId = userId,
                UserType = userType
            });
            return Ok(result);
        }
        //Shared API
        [HttpGet]
        [Route("/getChildStatistics")]
        public async Task<ActionResult<GetChildStatisticsResponse>> GetChildStatistics(string childId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new GetChildStatisticsRequest { ChildId = childId });
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/reachOut")]
        public async Task<IActionResult> ReachOut(ReachOutDto dto)
        {
            string email = User.FindFirstValue(JwtRegisteredClaimNames.Email);

            var result = await _mediator.Send(new ReachOutRequest
            {
                Name = dto.Name,
                Message = dto.Message,
                Email = email,
                PhoneNumber = dto.PhoneNumber
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("/addtask")]
        public async Task<ActionResult<bool>> AddTask(AddTaskDto dto)
        {
            var parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new AddTaskRequest
            {
                Title = dto.Title,
                Duration = dto.Duration,
                Description = dto.Description,
                FK_ChildId = dto.FK_ChildId,
                FK_ParentId = parentId,
                Points = dto.Points,
                Color = dto.Color,
                Image = dto.Image,
                Cash = dto.Cash,
                Avatar = dto.Avatar,
                IsRepeat = dto.IsRepeat,
                Repetition = JsonConvert.SerializeObject(dto.Repetition),
                Type = (TaskType)dto.TaskType
            });
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/updatetask")]
        public async Task<ActionResult<bool>> UpdateTask(UpdateTaskDto dto)
        {
            var parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new UpdateTaskRequest
            {
                Title = dto.Title,
                TaskId = dto.TaskId,
                Duration = dto.Duration,
                Description = dto.Description,
                RemoveChildIds = dto.RemoveChildIds,
                Points = dto.Points,
                Color = dto.Color,
                Image = dto.Image,
                Cash = dto.Cash,
                Avatar = dto.Avatar,
                IsRepeat = dto.IsRepeat,
                Repetition = JsonConvert.SerializeObject(dto.Repetition),
                Type = dto.TaskType
            });
            return Ok(result);
        }
        [HttpPost]
        [Route("/deleteTask")]
        public async Task<IActionResult> DeleteTask(DeleteTaskDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new DeleteTaskRequest
            {
                TaskId = dto.TaskId,
                ParentId = userId
            });
            return Ok(result);
        }
        [HttpPost]
        [Route("/rejectTask")]
        public async Task<ActionResult> RejectTask(RejectTaskDto dto)
        {
            string userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            string userType = User.FindFirstValue(JwtRegisteredClaimNames.Typ);

            var result = await _mediator.Send(new RejectTaskRequest
            {
                UserId = userId,
                UserType = userType,
                TaskId = dto.TaskId,
                Notes = dto.Notes
            });
            return Ok();
        }

        [HttpPost]
        [Route("/approveTask")]
        public async Task<ActionResult> ApproveTask(ApproveTaskDto dto)
        {
            string parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            await _mediator.Send(new ApproveTaskRequest
            {
                UserId = parentId,
                TaskId = dto.TaskId,
            });

            return Ok();
        }
        [HttpPost]
        [Route("/changeTaskStatus")]
        public async Task<IActionResult> ChangeTaskStatus(ChangeTaskStatusDto dto)
        {
            string userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            string userType = User.FindFirstValue(JwtRegisteredClaimNames.Typ);
            var result = await _mediator.Send(new ChangeTaskStatusRequest
            {
                Status = (Enums)dto.Status,
                TaskId = dto.TaskId,
                UserId = userId,
                UserType = userType,
                Image = dto.Image
            });
            return Ok();
        }

        //Shared API

        [HttpGet]
        [Route("/getTaskInfo")]
        public async Task<ActionResult> GetTaskInfo(long taskId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new  { TaskId = taskId, UserId = userId });
            return Ok(result);
        }
        

        [HttpGet]
        [Route("/getChatHistory")]
        public async Task<ActionResult<GetChatHistoryResponse>> GetChatHistory(long taskChildId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            var result = await _mediator.Send(new GetChatHistoryRequest
            {
                TaskChildId = taskChildId,
                UserId = userId
            });
            return Ok(result);
        }


        [HttpGet]
        [Route("/getParentTasks")]
        public async Task<ActionResult<GetParentTasksResponse>> GetParentTasks()
        {
            string parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new GetParentTasksRequest { ParentId = parentId });
            return Ok(result);
        }



        [HttpPost]
        [Route("/addReward")]
        public async Task<ActionResult<bool>> AddReward(AddRewardDto dto)
        {
            string parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new AddRewardRequest
            {
                Name = dto.Name,
                Description = dto.Description,
                Points = dto.Points,
                FK_ChildId = dto.FK_ChildId,
                Avatar = dto.Avatar,
                Duration = dto.Duration,
                Color = dto.Color,
                ProductId = dto.ProductId,
                RewardType = dto.RewardType,
                FK_ParentId = parentId,
                ImageId = dto.ImageId == 0 ? null : dto.ImageId,
                Image = dto.Image,
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("/deleteReward")]
        public async Task<IActionResult> DeleteReward(DeleteRewardDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new DeleteRewardRequest
            {
                RewardId = dto.RewardId,
                ParentId = userId
            });
            return Ok(result);
        }

   
        [HttpPost]
        [Route("/updateReward")]
        public async Task<ActionResult<bool>> UpdateReward(UpdateRewardDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new UpdateRewardRequest
            {
                RewardId = dto.RewardId,
                Name = dto.Name,
                Description = dto.Description,
                Points = dto.Points,
                RedeemOrderId = dto.RedeemOrderId,
                ParentId = userId,
                RemoveChildIds = dto.RemoveChildIds
            });
            return Ok(result);
        }
        
        [HttpGet]
        [Route("/getRewardInfo")]
        public async Task<ActionResult> GetRewardInfo(long rewardId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            var result = await _mediator.Send(new  { RewardId = rewardId, UserId = userId  });
            return Ok(result);
        }

        [HttpGet]
        [Route("/getRewards")]
        public async Task<ActionResult> GetRewards()
        {
            var parentId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var result = await _mediator.Send(new  { ParentId = parentId });
            return Ok(result);
        }
        

    }
}