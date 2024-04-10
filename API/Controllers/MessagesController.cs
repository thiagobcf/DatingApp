using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MessagesController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessagesController(IUserRepository userRepository, IMessageRepository messageRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _userRepository = userRepository;

        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var username = User.GetUsername();

            if (username == createMessageDto.RecipentUsername.ToLower())
                return BadRequest("You cannot send messages to yourself");

            var sender = await _userRepository.GetUserByUsernameAsync(username);
            var recipent = await _userRepository.GetUserByUsernameAsync(createMessageDto.RecipentUsername);

            if (recipent == null) return NotFound();

            var message = new Message
            {
                Sender = sender,
                Recipient = recipent,
                SenderUsername = sender.UserName,
                RecipentUsername = recipent.UserName,
                Content = createMessageDto.Content
            };
            _messageRepository.AddMessage(message);

            if (await _messageRepository.SaveAllAsync()) return Ok(_mapper.Map<MessageDto>(message));

            return BadRequest("Failed to send message");
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<MessageDto>>> GetMessagesForUser([FromQuery]
            MessageParams messageParams)
        {
            messageParams.Username = User.GetUsername();
            var message = await _messageRepository.GetMessagesForUser(messageParams);
            Response.AddPaginationHeader(new PaginationHeader(message.CurrentPage, message.PageSize,
                message.TotalCount, message.TotalPages));
            return message;
        }
    }
}